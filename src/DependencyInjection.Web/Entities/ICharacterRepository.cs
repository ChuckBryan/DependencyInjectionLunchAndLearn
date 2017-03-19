namespace DependencyInjection.Web.Entities
{
    using System.Collections.Generic;

    public interface ICharacterRepository
    {
        IList<Character> GetAll();
        Character GetCharacter(int id);
        void Add(Character character);
    }
}