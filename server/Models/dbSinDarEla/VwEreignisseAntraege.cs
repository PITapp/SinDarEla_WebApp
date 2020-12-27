using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseAntraege")]
  public partial class VwEreignisseAntraege
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
    public string Mitarbeiter
    {
      get;
      set;
    }
    public string EreignisText
    {
      get;
      set;
    }
    public string SonderurlaubArt
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public DateTime Start
    {
      get;
      set;
    }
    public int? StartJahr
    {
      get;
      set;
    }
    public DateTime Ende
    {
      get;
      set;
    }
    public Int64? Tage
    {
      get;
      set;
    }
    public double StundenUrlaub
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
    public string Bearbeiter
    {
      get;
      set;
    }
  }
}
