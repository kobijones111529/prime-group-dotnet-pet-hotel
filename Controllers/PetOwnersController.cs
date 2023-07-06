using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace PetHotel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetOwnersController : ControllerBase
{
    private readonly ApplicationContext _context;
    public PetOwnersController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<ExistingPetOwner> GetPets()
    {
        return _context.PetOwners;
    }

    [HttpGet("{id}")]
    public ActionResult<ExistingPetOwner> GetbyId(int id)
    {
        ExistingPetOwner petOwnerWeWant = _context.PetOwners.SingleOrDefault(petOwner => petOwner.Id == id);

        if (petOwnerWeWant is null)
        {
            return NotFound();
        }

        return petOwnerWeWant;
    }

    [HttpPost]
    public IActionResult Post(PetOwner petOwner)
    {
        ExistingPetOwner newPetOwner = new ExistingPetOwner(petOwner);
        _context.Add(newPetOwner);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetbyId), new { id = newPetOwner.Id }, newPetOwner);
    }

    // private ActionResult<ExistingPetOwner> ActuallyPost(ExistingPetOwner petOwner) {
    //     _context.Add(new ExistingPetOwner(petOwner));
    //     _context.SaveChanges();
    //     return Created("/api/PetOwner", petOwner);
    // }

    // [HttpPost]
    // public ActionResult<ExistingPetOwner> Post(PetOwner petOwner)
    // {
    //     return ActuallyPost(new ExistingPetOwner(petOwner));

    //     // _context.Add(new ExistingPetOwner(petOwner));
    //     // _context.SaveChanges();
    //     // return Created("/api/PetOwner", petOwner);
    // }
}
