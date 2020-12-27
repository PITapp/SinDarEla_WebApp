using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterTermineZusammenfassung")]
  public partial class VwMitarbeiterTermineZusammenfassung
  {
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public int MitarbeiterID
    {
      get;
      set;
    }
    public string Jahr
    {
      get;
      set;
    }
    public Int64 AnzahlTermine
    {
      get;
      set;
    }
    public string SummeStunden
    {
      get;
      set;
    }
  }
}
