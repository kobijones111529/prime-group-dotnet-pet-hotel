using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetHotel;

public class ExistingPetOwner : PetOwner
{
    [Required]
    public int Id { get; set; }

    public ExistingPetOwner() { }

    public ExistingPetOwner(PetOwner petOwner) {
        this.EmailAddress = petOwner.EmailAddress;
        this.Name = petOwner.Name;
    }
}
