using HeroesAPI.Collections;

namespace HeroesAPI.Repositories;

public interface IHeroRepository
{
    Task<List<Hero>> GetAllAsync();
    Task<Hero> GetByIdAsync(string id);
    Task CreateAsync(Hero hero);
    Task UpdateAsync(Hero hero);
    Task DeleteAsync(string id);
}