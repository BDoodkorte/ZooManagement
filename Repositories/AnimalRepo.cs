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
        AnimalDetail Create(AnimalDetail post);

    }

    public class PostsRepo : IAnimalRepo
    {
        private readonly ZooManagementDbContext _context;

        public PostsRepo(ZooManagementDbContext context)
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
    }
}
