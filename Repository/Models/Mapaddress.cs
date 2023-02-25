using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiMap.Repository.Models;

//[Table("mapaddress")]
public class Mapaddress
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("address")]
    [StringLength(100)]
    public string Address { get; set; } = null!;

    [Column("latitude")]
    public double Latitude { get; set; }

    [Column("longitude")]
    public double Longitude { get; set; }
}
