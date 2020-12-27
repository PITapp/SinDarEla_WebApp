using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenLeistungenKontingente")]
  public partial class VwKundenLeistungenKontingente
  {
    public int KundenLeistungID
    {
      get;
      set;
    }
    [Key]
    public int KundenID
    {
      get;
      set;
    }
    public int KundenLeistungArtID
    {
      get;
      set;
    }
    public string LeistungArt
    {
      get;
      set;
    }
    public string LeistungSchluessel
    {
      get;
      set;
    }
    public int KundenLeistungenBescheideKontingentID
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
    public string KontingentTitel
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
    public string KontingentTitelStunden
    {
      get;
      set;
    }
    public string KontingentTitelBisStunden
    {
      get;
      set;
    }
    public string KontingentTitelBisStundenKurz
    {
      get;
      set;
    }
    public string KontingentTitelRest
    {
      get;
      set;
    }
    public string StatusCode
    {
      get;
      set;
    }
    public string StatusTitel
    {
      get;
      set;
    }
    public int? StatusSortierung
    {
      get;
      set;
    }
  }
}
