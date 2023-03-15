using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models;
using ZooManagement.Repositories;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("/animal")]
    public class AnimalListController : ControllerBase
    {

        private readonly IAnimalRepo _animal;

        public AnimalListController(IAnimalRepo animal)
        {
            _animal = animal;
        }

        [HttpGet("list")]


        public ActionResult<AnimalModel> GetAnimalList([FromQuery] AnimalSearchRequest searchRequest)
        {
            var posts = _animal.SearchFeed(searchRequest);
            var postCount = _animal.Count(searchRequest);
            return AnimalModel.Create(searchRequest, posts, postCount);
        }

        // Paginated search
        // Page size and page number
        // Input query string (includes search query)
        // Filtered search query: species, classification, age (number not DOB), date Acquired. 

        // order list alphabetically by species, but allow for frontend to change this. 
    }
}