using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterFortbildungenSummenJahr")]
  public partial class VwMitarbeiterFortbildungenSummenJahr
  {
    [Key]
    public int MitarbeiterID
    {
      get;
      set;
    }
    public int? Jahr
    {
      get;
      set;
    }
    public double? SummeKosten
    {
      get;
      set;
    }
  }
}
