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
    public class AnimalController : ControllerBase
    {

        private readonly IAnimalRepo _animal;

        public AnimalController(IAnimalRepo animal)
        {
            _animal = animal;
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetAnimalById([FromRoute] int id)
        {
            var animal = _animal.GetById(id);
            return new AnimalResponse(animal);
        }

        [HttpPost("create")]
        public IActionResult AddAnimal([FromBody] AnimalDetail newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var animal = _animal.Create(newAnimal);
            var url = Url.Action("GetAnimalById", new { id = animal.Id });
            var animalResponse = new AnimalResponse(animal);
            return Created(url, animalResponse);

        }

        [HttpGet("")]
        public ActionResult<List<AnimalType>> ListAnimal()
        {
            var animalList = _animal.ListofTypes();
            return animalList;
        }
    }
}