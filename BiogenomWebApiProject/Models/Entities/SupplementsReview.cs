using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWebApiProject.Models;

[Table("supplements_reviews")]
public partial class SupplementsReview
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_supplements")]
    public int IdSupplements { get; set; }

    [Column("id_reviews")]
    public int IdReviews { get; set; }

    [ForeignKey("IdReviews")]
    [InverseProperty("SupplementsReviews")]
    public virtual Review IdReviewsNavigation { get; set; } = null!;

    [ForeignKey("IdSupplements")]
    [InverseProperty("SupplementsReviews")]
    public virtual Supplement IdSupplementsNavigation { get; set; } = null!;
}
