using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseModulMitarbeiter")]
  public partial class VwEreignisseModulMitarbeiter
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
