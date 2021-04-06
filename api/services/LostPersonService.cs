using System.Collections.Generic;
using System.Linq;
using api.Entities;

namespace api
{
    public interface ILostPerson
    {
        public List<Lost> GetAllLost();
    }
    
    public class LostPersonService: ILostPerson
    {
        private readonly LostDbContext _dbContext;

        public LostPersonService(LostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Lost> GetAllLost()
        {
            var lostPersons = _dbContext.Lost.ToList();
            return lostPersons;
        } 
    }
}