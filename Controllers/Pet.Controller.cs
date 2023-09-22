using midterm_project.Models;
using midterm_project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace midterm_project.Controllers;

public class PetController : Controller
{
    private readonly ILogger<PetController> _logger;
    private readonly IPetRepository _petRepository;

    public PetController(ILogger<PetController> logger, IPetRepository repository)
    {
        _logger = logger;
        _petRepository = repository;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View(_petRepository.GetAllFish());
    }

[HttpGet]
public IActionResult Detail(int id)
{
    var fish = _petRepository.GetFishById(id);

    if (fish == null)
    {
        return RedirectToAction("List");
    }

    return View(fish);
}

[HttpPost]
public IActionResult Update(Fish fish)
{
    if (!ModelState.IsValid)
    {
        return View(fish);
    }

    var updatedFish = _petRepository.UpdateFish(fish);
    return RedirectToAction("Detail", new { id = updatedFish.Id });
}

   
    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Fish fish)
    {
        if (!ModelState.IsValid)
        {
            return View(fish);
        }

        _petRepository.CreateFish(fish);

        return RedirectToAction("Detail", new { id = fish.Id});
    }

[HttpGet]
public IActionResult Edit(int id)
{
    var fish = _petRepository.GetFishById(id);

    if (fish == null)
    {
        return RedirectToAction("List");
    }

    return View(fish);
}

[HttpPost]
public IActionResult Edit(Fish fish)
{
    if (!ModelState.IsValid)
    {
        return View(fish);
    }

    var updatedFish = _petRepository.UpdateFish(fish);
    return RedirectToAction("Detail", new { id = updatedFish.Id });
}


    public IActionResult Delete(int id)
    {
        _petRepository.DeleteFishById(id);

        return RedirectToAction("List");
    }

}
