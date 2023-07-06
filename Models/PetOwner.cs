using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHotel;

public class PetOwner
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string EmailAddress { get; set; }

    public string Name { get; set; }

    [NotMapped]
    [JsonIgnore]
    public int PetCount { get; set; }
}
