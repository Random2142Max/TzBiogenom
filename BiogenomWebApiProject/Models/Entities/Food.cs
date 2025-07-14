using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("foods")]
public partial class Food
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("quantityperday")]
    public int? Quantityperday { get; set; }

    [Column("standarddivisions")]
    [StringLength(25)]
    public string Standarddivisions { get; set; } = null!;

    [Column("unitofmeasurement")]
    [StringLength(5)]
    public string Unitofmeasurement { get; set; } = null!;

    // Позже будет реализован enum [byte], секций продуктов/еды (Алкоголь, ...)
    [Column("typeoffoodsection")]
    public short Typeoffoodsection { get; set; }

    [InverseProperty("IdFoodsNavigation")]
    public virtual ICollection<FoodsNutrient> FoodsNutrients { get; set; } = new List<FoodsNutrient>();
}
