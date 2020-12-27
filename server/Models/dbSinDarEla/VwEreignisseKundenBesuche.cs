using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseKundenBesuche")]
  public partial class VwEreignisseKundenBesuche
  {
    public int EreignisID
    {
      get;
      set;
    }
    [Key]
    public string EreignisArtCode
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public int? KundenID
    {
      get;
      set;
    }
    public int? KundenLeistungArtID
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
    public Int64? Minuten
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string TitelDatumZeit
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string Bemerkungen
    {
      get;
      set;
    }
    public int? GefuehlSituation01
    {
      get;
      set;
    }
    public int? GefuehlSituation02
    {
      get;
      set;
    }
    public int? GefuehlSituation03
    {
      get;
      set;
    }
    public int? GefuehlSituation04
    {
      get;
      set;
    }
    public int? GefuehlSituation05
    {
      get;
      set;
    }
    public int? GefuehlSituation06
    {
      get;
      set;
    }
    public int? KundenFahrtMinuten
    {
      get;
      set;
    }
    public int? KundenFahrtKM
    {
      get;
      set;
    }
    public int? BetreuerAnAbReiseMinuten
    {
      get;
      set;
    }
    public int? BetreuerAnAbReiseKM
    {
      get;
      set;
    }
    public DateTime BesuchAm
    {
      get;
      set;
    }
    public string BesuchVon
    {
      get;
      set;
    }
    public string BesuchBis
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
    public string NameVorNach
    {
      get;
      set;
    }
    public string NameKuerzel
    {
      get;
      set;
    }
  }
}
