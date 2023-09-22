namespace midterm_project.Models;

using System.ComponentModel.DataAnnotations;

public class Fish
{

    public int Id { get; set; }
    [Required]
    [Display(Name = "Pet Name")]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Description")]
    public string Description { get; set; }
    [Required]
    [Display(Name = "Color")]
    public string Color { get; set; }
    [Required]
    [Display(Name = "Image Url")]
    public string Url { get; set; }

}
