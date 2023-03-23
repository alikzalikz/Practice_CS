using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

[Keyless]
public partial class Territory
{
    [Required]
    [Column(TypeName = "nvarchar] (20")]
    public string TerritoryId { get; set; } = null!;

    [Required]
    [Column(TypeName = "nchar] (50")]
    public string TerritoryDescription { get; set; } = null!;

    [Column(TypeName = "INT")]
    public int RegionId { get; set; }
}
