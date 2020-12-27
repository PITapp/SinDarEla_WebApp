using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseModulDienstplanMobile")]
  public partial class VwEreignisseModulDienstplanMobile
  {
    public int id
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
    public string title
    {
      get;
      set;
    }
    public string description
    {
      get;
      set;
    }
    public int? allDay
    {
      get;
      set;
    }
    public DateTime start
    {
      get;
      set;
    }
    public int? startJahr
    {
      get;
      set;
    }
    public int? startQuartal
    {
      get;
      set;
    }
    public int? startMonat
    {
      get;
      set;
    }
    public int? startWoche
    {
      get;
      set;
    }
    public int? startTag
    {
      get;
      set;
    }
    public int? startStunde
    {
      get;
      set;
    }
    public int? startMinute
    {
      get;
      set;
    }
    public string startTagKurz
    {
      get;
      set;
    }
    public string startTagTitel
    {
      get;
      set;
    }
    public string startMonatKurz
    {
      get;
      set;
    }
    public string startMonatTitel
    {
      get;
      set;
    }
    public string startMonatTitelJahr
    {
      get;
      set;
    }
    public int? startJahrMonat
    {
      get;
      set;
    }
    public string startZeit
    {
      get;
      set;
    }
    public string startZeitspanne
    {
      get;
      set;
    }
    public string startTitelDientplanWoche
    {
      get;
      set;
    }
    public DateTime end
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public Int64 KundenID
    {
      get;
      set;
    }
    public Int64 KundenLeistungArtID
    {
      get;
      set;
    }
    public string Verwendung
    {
      get;
      set;
    }
    public string Gruppe
    {
      get;
      set;
    }
    public string Ebene
    {
      get;
      set;
    }
    public string Bezeichnung
    {
      get;
      set;
    }
    public string Kurzzeichen
    {
      get;
      set;
    }
    public string VerwendenFuer
    {
      get;
      set;
    }
    public int? Sortierung
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
    public string Name
    {
      get;
      set;
    }
    public int? MitarbeiterID
    {
      get;
      set;
    }
  }
}
