using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("currentdailyconsumptions")]
public partial class Currentdailyconsumption
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("datetimeoffilling", TypeName = "timestamp without time zone")]
    public DateTime Datetimeoffilling { get; set; }

    [Column("id_assessments")]
    public int IdAssessments { get; set; }

    [ForeignKey("IdAssessments")]
    [InverseProperty("Currentdailyconsumptions")]
    public virtual Assessment IdAssessmentsNavigation { get; set; } = null!;

    [InverseProperty("IdCurrentdailyconsumptionsNavigation")]
    public virtual ICollection<Newconsumption> Newconsumptions { get; set; } = new List<Newconsumption>();
}
