using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenBetreuer")]
  public partial class VwKundenBetreuer
  {
    public int KundenLeistungenBetreuerID
    {
      get;
      set;
    }
    [Key]
    public int KundenLeistungID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public int KundenLeistungenBetreuerArtID
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
    public string Betreuungsart
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
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
  }
}
