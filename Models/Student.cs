using MvcTest.Resources;
using System.ComponentModel.DataAnnotations;

namespace MvcTest.Models;

public class Student
{
    public long Id { get; set; }
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    [MaxLength(20, ErrorMessage = "Name has to be shorter then 20")]
    [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NickNameRequired")]
    [Display(ResourceType =typeof(Resource), Name = "NickName")]
    public string NickName { get; set; }

    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
}
