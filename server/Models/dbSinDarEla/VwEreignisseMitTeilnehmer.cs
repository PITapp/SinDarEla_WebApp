using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseMitTeilnehmer")]
  public partial class VwEreignisseMitTeilnehmer
  {
    public int id
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    [Key]
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
    public int? allDay
    {
      get;
      set;
    }
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
    public string title2
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
    public string Beschreibung
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
    public string Nachricht
    {
      get;
      set;
    }
  }
}
