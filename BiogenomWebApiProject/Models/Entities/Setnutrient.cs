using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("setnutrients")]
public partial class Setnutrient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("physicalactivitylevel")]
    public int Physicalactivitylevel { get; set; }

    [Column("highlimitnorm")]
    [Precision(8, 2)]
    public decimal Highlimitnorm { get; set; }

    [Column("lowerlimitnorm")]
    [Precision(8, 2)]
    public decimal Lowerlimitnorm { get; set; }

    [Column("id_foods_nutrients")]
    public int IdFoodsNutrients { get; set; }

    [Column("id_physicalactivitylevels")]
    public int IdPhysicalactivitylevels { get; set; }

    [ForeignKey("IdFoodsNutrients")]
    [InverseProperty("Setnutrients")]
    public virtual FoodsNutrient IdFoodsNutrientsNavigation { get; set; } = null!;

    [ForeignKey("IdPhysicalactivitylevels")]
    [InverseProperty("Setnutrients")]
    public virtual Physicalactivitylevel IdPhysicalactivitylevelsNavigation { get; set; } = null!;
}
