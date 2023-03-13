// using Microsoft.AspNetCore.Mvc;
// using ZooManagement.Models;
// using ZooManagement.Repositories;
// using System.Net.Http.Headers;
// using System.Net.Http;
// using System.Text;
// using System;

// namespace ZooManagement.Controllers
// {
//     [Route("/animal")]
//     public class AnimalController : ControllerBase
//     {

//         private readonly IAnimalRepo _animal;

//         public AnimalController(IAnimalRepo animal)
//         {
//             _animal = animal;
//         }

//         [HttpGet("{id}")]
//         public IActionResult GetAnimalById([FromRoute] int id)
//         {

//         }

//         [HttpPost("create")]
//         public IActionResult AddAnimal([FromBody] AnimalDetail newPost)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             var post = _animal.Create(newPost);
//             var url = Url.Action("GetById", new { id = post.Id });
//             var postResponse = new PostResponse(post);
//             return Created(url, postResponse);

//         }

//         [HttpGet("")]
//         public IActionResult ListAnimal()
//         {

//         }
//     }
// }