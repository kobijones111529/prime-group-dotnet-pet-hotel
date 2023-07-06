using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetHotel;

public class PetOwner
{
    [Required]
    public string EmailAddress { get; set; }

    public string Name { get; set; }

    [NotMapped]
    public int PetCount { get; set; }

    [JsonIgnore]
    public List<Pet> Pets { get; set; }
}
