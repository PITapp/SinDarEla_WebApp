using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("AbrechnungBasis")]
  public partial class AbrechnungBasis
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AbrechnungBasisID
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
    public int? Jahr
    {
      get;
      set;
    }
    public int? Monat
    {
      get;
      set;
    }
    public bool? Gesperrt
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
  }
}
