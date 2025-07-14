using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("assessments")]
public partial class Assessment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("datetimeofstart", TypeName = "timestamp without time zone")]
    public DateTime Datetimeofstart { get; set; }

    [Column("isend")]
    public bool Isend { get; set; }

    [Column("id_users")]
    public int IdUsers { get; set; }

    [InverseProperty("IdAssessmentsNavigation")]
    public virtual ICollection<Currentdailyconsumption> Currentdailyconsumptions { get; set; } = new List<Currentdailyconsumption>();

    [ForeignKey("IdUsers")]
    [InverseProperty("Assessments")]
    public virtual User IdUsersNavigation { get; set; } = null!;
}
