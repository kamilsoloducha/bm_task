using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using MvcTest.Models;
using TestMvc.Data;

namespace MvcTest.Controllers;

public class StudentController : Controller
{
    private readonly DataContext context;
    private readonly IHtmlLocalizer<StudentController> localizer;

    public StudentController(DataContext context, IHtmlLocalizer<StudentController> localizer)
    {
        this.context = context;
        this.localizer = localizer;
    }

    public async Task<IActionResult> Index()
    {
        var test = localizer.GetAllStrings();
        var students = await context.Students.ToListAsync();

        var viewModel = new StudentIndexViewModel();
        viewModel.Students = students;

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return View(student);

        await context.Students.AddAsync(student, token);
        await context.SaveChangesAsync(token);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return LocalRedirect(returnUrl);
    }

}