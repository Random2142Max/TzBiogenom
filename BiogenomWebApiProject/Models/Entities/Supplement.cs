using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("supplements")]
public partial class Supplement
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("countnutrients")]
    [Precision(8, 2)]
    public decimal Countnutrients { get; set; }

    [Column("unitofmeasurementnutrients")]
    [StringLength(5)]
    public string Unitofmeasurementnutrients { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("application")]
    public string? Application { get; set; }

    [InverseProperty("IdSupplementsNavigation")]
    public virtual ICollection<NutrientsSupplement> NutrientsSupplements { get; set; } = new List<NutrientsSupplement>();

    [InverseProperty("IdSupplementsNavigation")]
    public virtual ICollection<SupplementsReview> SupplementsReviews { get; set; } = new List<SupplementsReview>();
}
