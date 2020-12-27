using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterFortbildungenSummenJahrArten")]
  public partial class VwMitarbeiterFortbildungenSummenJahrArten
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
    public string Titel
    {
      get;
      set;
    }
    public int? Sortierung
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
