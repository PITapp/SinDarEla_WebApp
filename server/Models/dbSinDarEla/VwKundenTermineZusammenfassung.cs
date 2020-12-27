using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenTermineZusammenfassung")]
  public partial class VwKundenTermineZusammenfassung
  {
    [Key]
    public int? KundenID
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
