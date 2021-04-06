using System;
using System.Collections.Generic;
using System.Linq;
using api.Entities;
using api.Models;

namespace api
{
    public class DbSeeder
    {
        private readonly LostDbContext _dbContext;

        public DbSeeder(LostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Lost.Any())
                {
                    var losts = GetLosts();
                    _dbContext.Lost.AddRange(losts);
                    _dbContext.SaveChanges();
                }
                
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }

        private IEnumerable<Lost> GetLosts()
        {
            var lost = new List<Lost>()
            {
                new Lost()
                {
                    FirstName = "Michal",
                    SecondName = "Pietrucha",
                    City="Warsaw",
                    Age = 18,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Adam",
                    SecondName = "Kowalski",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Adam",
                    SecondName = "Kowalski",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Jadwiga",
                    SecondName = "Trzebicka",
                    City="Krakow",
                    Age = 55,
                    Gender = LostGender.Woman.ToString(),
                    LastTimeSaw = DateTime.Now,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Jan",
                    SecondName = "Wolski",
                    City="Warsaw",
                    Age = 15,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Monika",
                    SecondName = "Trąbacz",
                    City="Warsaw",
                    Age = 71,
                    Gender = LostGender.Woman.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 2",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 3",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 4",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 5",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 5",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 6",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 7",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 8",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 9",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
                new Lost()
                {
                    FirstName = "Test",
                    SecondName = "Test 10",
                    City="Warsaw",
                    Age = 32,
                    Gender = LostGender.Man.ToString(),
                    LastTimeSaw = DateTime.Today,
                    Nationality = "Poland",
                    
                },
            };

            return lost;
        }
    }
}