using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenUndBetreuerUndLeistungenAuswahl")]
  public partial class VwKundenUndBetreuerUndLeistungenAuswahl
  {
    public int KundenID
    {
      get;
      set;
    }
    [Key]
    public int KundeBaseID
    {
      get;
      set;
    }
    public string KundeNameGesamt
    {
      get;
      set;
    }
    public int BetreuerBaseID
    {
      get;
      set;
    }
    public string BetreuerNameGesamt
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
    public string LeistungArtUndSchluessel
    {
      get;
      set;
    }
  }
}
