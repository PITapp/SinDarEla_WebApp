using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseAlles")]
  public partial class VwEreignisseAlle
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
    public int? EreignisSonderurlaubArtID
    {
      get;
      set;
    }
    public string EreignisBezeichnung
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public string BesitzerNameGesamt
    {
      get;
      set;
    }
    public string BesitzerNameVorNach
    {
      get;
      set;
    }
    public string BesitzerNameKuerzel
    {
      get;
      set;
    }
    public int? KundenID
    {
      get;
      set;
    }
    public int? KundeBaseID
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
    public int? KundenLeistungArtID
    {
      get;
      set;
    }
    public string KundeLeistungArt
    {
      get;
      set;
    }
    public string KundeLeistungSchluessel
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
    public DateTime end
    {
      get;
      set;
    }
    public DateTime? endKorrigiert
    {
      get;
      set;
    }
    public int? GanzerTag
    {
      get;
      set;
    }
    public int? allDay
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string title
    {
      get;
      set;
    }
    public string titleModulDashboard
    {
      get;
      set;
    }
    public string titleModulDienstplan
    {
      get;
      set;
    }
    public string titleModulMitarbeiter
    {
      get;
      set;
    }
    public string titleModulKunden
    {
      get;
      set;
    }
    public string titleModulManagement
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string description
    {
      get;
      set;
    }
    public double StundenUrlaub
    {
      get;
      set;
    }
    public DateTime? BeantragtAm
    {
      get;
      set;
    }
    public DateTime? GenehmigtAm
    {
      get;
      set;
    }
    public DateTime? AbgelehntAm
    {
      get;
      set;
    }
    public string Begruendung
    {
      get;
      set;
    }
    public string StatusAntrag
    {
      get;
      set;
    }
    public string Verwendung
    {
      get;
      set;
    }
    public int? Gesperrt
    {
      get;
      set;
    }
    public string color
    {
      get;
      set;
    }
    public string textColor
    {
      get;
      set;
    }
    public int? EreignisseTeilnehmerID
    {
      get;
      set;
    }
    public int? TeilnehmerBaseID
    {
      get;
      set;
    }
    public string TeilnehmerNameGesamt
    {
      get;
      set;
    }
    public string TeilnehmerNameVorNach
    {
      get;
      set;
    }
    public string TeilnehmerNameKuerzel
    {
      get;
      set;
    }
    public string TeilnehmerStatusCode
    {
      get;
      set;
    }
    public string TeilnehmerStatusCodeTitel
    {
      get;
      set;
    }
  }
}
