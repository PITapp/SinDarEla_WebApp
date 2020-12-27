using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseModulDienstplanListe")]
  public partial class VwEreignisseModulDienstplanListe
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
    public string EreignisArtTitel
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
    public Int64 KundenID
    {
      get;
      set;
    }
    public string KundeNameGesamt
    {
      get;
      set;
    }
    public Int64 KundenLeistungArtID
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
    public DateTime? VonDatum
    {
      get;
      set;
    }
    public string VonZeit
    {
      get;
      set;
    }
    public DateTime? BisDatum
    {
      get;
      set;
    }
    public string BisZeit
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
    public int? GanzerTag
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string BeantragtAm
    {
      get;
      set;
    }
    public string GenehmigtAm
    {
      get;
      set;
    }
    public string AbgelehntAm
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
    public Int64 Gesperrt
    {
      get;
      set;
    }
  }
}
