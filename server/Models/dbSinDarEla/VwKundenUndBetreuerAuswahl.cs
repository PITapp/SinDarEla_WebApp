using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenUndBetreuerAuswahl")]
  public partial class VwKundenUndBetreuerAuswahl
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
    public string KundeNameVorNach
    {
      get;
      set;
    }
    public string KundeNameKuerzel
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
    public string BetreuerNameVorNach
    {
      get;
      set;
    }
    public string BetreuerNameKuerzel
    {
      get;
      set;
    }
  }
}
