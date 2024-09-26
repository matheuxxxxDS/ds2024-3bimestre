using HeroesAPI.Collections;
using MongoDB.Driver;

namespace HeroesAPI.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly IMongoCollection<Hero> _collection;
    public HeroRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Hero>("heroes");
    }

    public async Task CreateAsync(Hero hero) =>
        await _collection.InsertOneAsync(hero);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(p => p.Id == id);

    public async Task<List<Hero>> GetAllAsync() =>
        await _collection.Find(p => true).ToListAsync();

    public async Task<Hero> GetByIdAsync(string id) =>
        await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(Hero hero) =>
        await _collection.ReplaceOneAsync(p => p.Id == hero.Id, hero);
}