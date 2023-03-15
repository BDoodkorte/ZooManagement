using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ZooManagement.Repositories
{
    public interface IAnimalRepo
    {
        AnimalDetail Create(AnimalDetail animal);
        AnimalDetail GetById(int id);
        List<AnimalType> ListofTypes();
        IEnumerable<AnimalDetail> SearchFeed(AnimalSearchRequest search);
        int Count(AnimalSearchRequest search);
    }

    public class AnimalRepo : IAnimalRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public AnimalDetail Create(AnimalDetail animal)
        {
            var insertResult = _context.Animal.Add(new AnimalDetail
            {
                Name = animal.Name,
                Sex = animal.Sex,
                DOB = animal.DOB,
                DateAcquired = animal.DateAcquired,
                Type = animal.Type
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }

        public AnimalDetail GetById(int id)
        {
            return _context.Animal
                .Single(animal => animal.Id == id);
        }

        public List<AnimalType> ListofTypes()
        {
            var TypeList = _context.AnimalType.ToList();
            return TypeList;
        }


         public IEnumerable<AnimalDetail> SearchFeed(AnimalSearchRequest search)
        {
            return _context.Animal
                .OrderByDescending(p => p.Type.Species)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }
        
        public int Count(AnimalSearchRequest search)
        {
            return _context.Animal
                .Count();
        }
    }
}
