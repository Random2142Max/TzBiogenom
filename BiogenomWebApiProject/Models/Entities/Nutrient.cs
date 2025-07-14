using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("nutrients")]
public partial class Nutrient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("importanceforhealth")]
    public string? Importanceforhealth { get; set; }

    [Column("manifestationofdeficit")]
    public string? Manifestationofdeficit { get; set; }

    [Column("prevention")]
    public string? Prevention { get; set; }

    [Column("consumptionrecommendations")]
    public string? Consumptionrecommendations { get; set; }

    [InverseProperty("IdNutrientsNavigation")]
    public virtual ICollection<FoodsNutrient> FoodsNutrients { get; set; } = new List<FoodsNutrient>();

    [InverseProperty("IdNutrientsNavigation")]
    public virtual ICollection<NutrientsSupplement> NutrientsSupplements { get; set; } = new List<NutrientsSupplement>();
}
