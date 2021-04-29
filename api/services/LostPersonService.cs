using System.Collections.Generic;
using System.Linq;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public interface ILostPerson
    {
        public List<Lost> GetAllLost();
        public List<Lost> GetSelected(int take, int skip);
        void CreateLostPerson(Lost lost);
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


        public List<Lost> GetSelected(int take, int skip)
        {
            var lostPersons = _dbContext
                .Lost                
                .Include(u => u.AddedBy)
                .Skip(skip)
                .Take(take)
                .ToList();
            

            return lostPersons;
        }

        public void CreateLostPerson(Lost lost)
        {
            _dbContext.Lost.Add(lost);
            _dbContext.SaveChanges();
        }
    }
}