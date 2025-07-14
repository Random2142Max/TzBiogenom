using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Column("genre")]
    public bool Genre { get; set; }

    [Column("datebirth")]
    public DateOnly Datebirth { get; set; }

    [Column("height")]
    public int Height { get; set; }

    [Column("weight")]
    [Precision(4, 2)]
    public decimal Weight { get; set; }

    [Column("email")]
    [StringLength(40)]
    public string Email { get; set; } = null!;

    [Column("phonenumber")]
    [StringLength(16)]
    public string? Phonenumber { get; set; }

    [Column("promocode")]
    [StringLength(40)]
    public string? Promocode { get; set; }

    [Column("confirmationcode")]
    public int? Confirmationcode { get; set; }

    [InverseProperty("IdUsersNavigation")]
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    [InverseProperty("IdUsersNavigation")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
