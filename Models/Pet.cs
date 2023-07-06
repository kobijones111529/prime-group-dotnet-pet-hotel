using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace PetHotel;

public enum PetBreedType
{
    Beagle,     // 0
    Boxer,      // 1
    Bulldog,    // 2
    Labrador,   // 3
    Poodle,     // 4
    Retriever,  // 5
    Sheperd,    // 6
    Terrier     // 7
}

public enum PetColorType
{
    White,      // 0
    Black,      // 1
    Golden,     // 2
    Tricolor,   // 3
    Spotted     // 4
}

public class Pet
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetColorType PetColor { get; set; }

    public DateTime? CheckedInAt { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetBreedType PetBreed { get; set; }

    [Required]
    [ForeignKey("petOwner")]
    public int PetOwnerId { get; set; }
}
