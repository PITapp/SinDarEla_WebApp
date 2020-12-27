using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenEreignisse")]
  public partial class VwKundenEreignisse
  {
    public int EreignisID
    {
      get;
      set;
    }
    public int? KundenID
    {
      get;
      set;
    }
    [Key]
    public DateTime Start
    {
      get;
      set;
    }
    public DateTime Ende
    {
      get;
      set;
    }
    public string Zeit
    {
      get;
      set;
    }
    public string ZeitSpanne
    {
      get;
      set;
    }
    public Int64? Minuten
    {
      get;
      set;
    }
    public string Stunden
    {
      get;
      set;
    }
    public Int64? Tage
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
  }
}
