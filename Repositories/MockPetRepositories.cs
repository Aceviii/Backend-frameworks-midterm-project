
using midterm_project.Migrations;
using midterm_project.Models;

namespace midterm_project.Repositories;

public class MockPetRepository : IPetRepository
{
    private readonly PetDbContext _context;

    public MockPetRepository(PetDbContext context)
    {
        _context = context;
    }

    public Fish CreateFish(Fish newFish)
    {
        _context.Fish.Add(newFish);
        _context.SaveChanges();
        return newFish;
    }

    public void DeleteFishById(int Id)
    {
        var fish = _context.Fish.Find(Id);
        if (fish != null)
        {
            _context.Fish.Remove(fish);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Fish> GetAllFish()
    {
        return _context.Fish.ToList();
    }

    public Fish GetFishById(int Id)
    {
        return _context.Fish.SingleOrDefault(c => c.Id == Id);
    }

    public Fish UpdateFish(Fish newFish)
    {
        var originalFish = _context.Fish.Find(newFish.Id);
        if (originalFish != null)
        {
            originalFish.Name = newFish.Name;
            originalFish.Description = newFish.Description;
            originalFish.Color = newFish.Color;
            originalFish.Url = newFish.Url;
            _context.SaveChanges();
        }
        return originalFish;
    }
}
