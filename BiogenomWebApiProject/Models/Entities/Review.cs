using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("reviews")]
public partial class Review
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("text")]
    public string Text { get; set; } = null!;

    [Column("datetime")]
    public DateOnly Datetime { get; set; }

    [Column("id_users")]
    public int IdUsers { get; set; }

    [ForeignKey("IdUsers")]
    [InverseProperty("Reviews")]
    public virtual User IdUsersNavigation { get; set; } = null!;

    [InverseProperty("IdReviewsNavigation")]
    public virtual ICollection<SupplementsReview> SupplementsReviews { get; set; } = new List<SupplementsReview>();
}
