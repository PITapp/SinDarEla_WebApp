using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterSonderurlaubEinfach")]
  public partial class VwMitarbeiterSonderurlaubEinfach
  {
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public int? Jahr
    {
      get;
      set;
    }
    public decimal? Verbrauch
    {
      get;
      set;
    }
    public decimal? Plan
    {
      get;
      set;
    }
  }
}
