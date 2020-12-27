using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwAbrechnungBasisReststunden")]
  public partial class VwAbrechnungBasisReststunden
  {
    public int AbrechnungBasisID
    {
      get;
      set;
    }
    [Key]
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
    public string MonatText
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
