using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("newconsumptions")]
public partial class Newconsumption
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_currentdailyconsumptions")]
    public int IdCurrentdailyconsumptions { get; set; }

    [Column("id_nutrients_supplements")]
    public int IdNutrientsSupplements { get; set; }

    [ForeignKey("IdCurrentdailyconsumptions")]
    [InverseProperty("Newconsumptions")]
    public virtual Currentdailyconsumption IdCurrentdailyconsumptionsNavigation { get; set; } = null!;

    [ForeignKey("IdNutrientsSupplements")]
    [InverseProperty("Newconsumptions")]
    public virtual NutrientsSupplement IdNutrientsSupplementsNavigation { get; set; } = null!;
}
