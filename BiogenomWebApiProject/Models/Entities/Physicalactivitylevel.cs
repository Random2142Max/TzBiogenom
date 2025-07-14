using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("physicalactivitylevels")]
public partial class Physicalactivitylevel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

    [InverseProperty("IdPhysicalactivitylevelsNavigation")]
    public virtual ICollection<Setnutrient> Setnutrients { get; set; } = new List<Setnutrient>();
}
