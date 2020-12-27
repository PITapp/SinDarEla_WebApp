using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenLeistungenBescheide")]
  public partial class VwKundenLeistungenBescheide
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
    public int KundenLeistungenBescheidID
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
    public string Von
    {
      get;
      set;
    }
    public string Bis
    {
      get;
      set;
    }
    public string BescheidTitel
    {
      get;
      set;
    }
    public string Stunden
    {
      get;
      set;
    }
    public string StundenArt
    {
      get;
      set;
    }
    public string LeistungTitel
    {
      get;
      set;
    }
    public string Geschaeftszahl
    {
      get;
      set;
    }
    public string Selbstkostenbefreiung
    {
      get;
      set;
    }
    public string BeantragtAm
    {
      get;
      set;
    }
    public string KundenKontaktID
    {
      get;
      set;
    }
    public string Ergaenzungsbescheid
    {
      get;
      set;
    }
    public string ErgaenzungsbescheidInfo
    {
      get;
      set;
    }
    public string Ablaufdatum
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
