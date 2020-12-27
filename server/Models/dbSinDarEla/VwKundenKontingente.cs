using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenKontingente")]
  public partial class VwKundenKontingente
  {
    public int KundenLeistungenBescheideKontingentID
    {
      get;
      set;
    }
    [Key]
    public int KundenLeistungenBescheidID
    {
      get;
      set;
    }
    public DateTime KontingentVon
    {
      get;
      set;
    }
    public DateTime KontingentBis
    {
      get;
      set;
    }
    public double? Anspruch
    {
      get;
      set;
    }
    public double? Verbrauch
    {
      get;
      set;
    }
    public double? Rest
    {
      get;
      set;
    }
    public string KontingentTitel
    {
      get;
      set;
    }
    public int KundenLeistungID
    {
      get;
      set;
    }
    public string StatusCode
    {
      get;
      set;
    }
  }
}
