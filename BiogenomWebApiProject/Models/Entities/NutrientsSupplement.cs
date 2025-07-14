using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("nutrients_supplements")]
public partial class NutrientsSupplement
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_nutrients")]
    public int IdNutrients { get; set; }

    [Column("id_supplements")]
    public int IdSupplements { get; set; }

    [ForeignKey("IdNutrients")]
    [InverseProperty("NutrientsSupplements")]
    public virtual Nutrient IdNutrientsNavigation { get; set; } = null!;

    [ForeignKey("IdSupplements")]
    [InverseProperty("NutrientsSupplements")]
    public virtual Supplement IdSupplementsNavigation { get; set; } = null!;

    [InverseProperty("IdNutrientsSupplementsNavigation")]
    public virtual ICollection<Newconsumption> Newconsumptions { get; set; } = new List<Newconsumption>();
}
