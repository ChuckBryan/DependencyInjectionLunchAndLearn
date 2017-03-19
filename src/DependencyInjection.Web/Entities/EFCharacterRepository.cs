namespace DependencyInjection.Web.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class EFCharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EFCharacterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Character> GetAll()
        {
            return _dbContext.Characters.ToList();
        }

        public Character GetCharacter(int id)
        {
            return _dbContext.Characters.Single(s => s.Id == id);
        }

        public void Add(Character character)
        {
            _dbContext.Characters.Add(character);
            _dbContext.SaveChanges();
        }
    }
}