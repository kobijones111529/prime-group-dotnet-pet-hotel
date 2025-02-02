using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetHotel.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetHotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    private readonly ApplicationContext _context;
    public PetsController(ApplicationContext context)
    {
        _context = context;
    }

    // This is just a stub for GET / to prevent any weird frontend errors that 
    // occur when the route is missing in this controller
    [HttpGet]
    public IEnumerable<Pet> GetPets()
    {
        return _context.Pets;
    }

    [HttpGet("{id}")]
    public ActionResult<Pet> GetPet(int id)
    {
        Pet petWeWant = _context.Pets.SingleOrDefault(pet => pet.Id == id);

        if (petWeWant is null)
        {
            return NotFound();
        }

        return petWeWant;
    }

    [HttpPost]
    public Pet CreatePet(Pet newPet)
    {
        _context.Add(newPet);
        _context.SaveChanges();
        return newPet;
    }

    [HttpPut("{id}")]
    public Pet Put(int id, Pet pet)
    {
        pet.Id = id;

        _context.Update(pet);

        _context.SaveChanges();

        return pet;
    }


}

// [HttpGet]
// [Route("test")]
// public IEnumerable<Pet> GetPets() {
//     PetOwner blaine = new PetOwner{
//         name = "Blaine"
//     };

//     Pet newPet1 = new Pet {
//         name = "Big Dog",
//         petOwner = blaine,
//         color = PetColorType.Black,
//         breed = PetBreedType.Poodle,
//     };

//     Pet newPet2 = new Pet {
//         name = "Little Dog",
//         petOwner = blaine,
//         color = PetColorType.Golden,
//         breed = PetBreedType.Labrador,
//     };

//     return new List<Pet>{ newPet1, newPet2};
// }
