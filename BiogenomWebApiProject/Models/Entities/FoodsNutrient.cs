using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("foods_nutrients")]
public partial class FoodsNutrient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("countnutrients")]
    [Precision(8, 2)]
    public decimal Countnutrients { get; set; }

    [Column("unitofmeasurementnutrients")]
    [StringLength(5)]
    public string Unitofmeasurementnutrients { get; set; } = null!;

    [Column("id_nutrients")]
    public int IdNutrients { get; set; }

    [Column("id_foods")]
    public int IdFoods { get; set; }

    [ForeignKey("IdFoods")]
    [InverseProperty("FoodsNutrients")]
    public virtual Food IdFoodsNavigation { get; set; } = null!;

    [ForeignKey("IdNutrients")]
    [InverseProperty("FoodsNutrients")]
    public virtual Nutrient IdNutrientsNavigation { get; set; } = null!;

    [InverseProperty("IdFoodsNutrientsNavigation")]
    public virtual ICollection<Setnutrient> Setnutrients { get; set; } = new List<Setnutrient>();
}
