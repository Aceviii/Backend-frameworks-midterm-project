using midterm_project.Models;

namespace midterm_project.Repositories;

public interface IPetRepository
{
    IEnumerable<Fish> GetAllFish();
    Fish GetFishById(int Id);
    Fish CreateFish(Fish newFish);
    Fish UpdateFish(Fish newFish);
    void DeleteFishById(int Id);
}