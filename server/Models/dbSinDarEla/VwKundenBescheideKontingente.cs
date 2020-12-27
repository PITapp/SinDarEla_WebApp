using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenBescheideKontingente")]
  public partial class VwKundenBescheideKontingente
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
    public string Kunde
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
    public DateTime? Von
    {
      get;
      set;
    }
    public DateTime? Bis
    {
      get;
      set;
    }
    public int? Stunden
    {
      get;
      set;
    }
    public string StundenArt
    {
      get;
      set;
    }
    public string Geschaeftszahl
    {
      get;
      set;
    }
    public bool? Selbstkostenbefreiung
    {
      get;
      set;
    }
    public DateTime? BeantragtAm
    {
      get;
      set;
    }
  }
}
