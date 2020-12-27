using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwGeburtstage")]
  public partial class VwGeburtstage
  {
    public int BaseID
    {
      get;
      set;
    }
    [Key]
    public string Name1
    {
      get;
      set;
    }
    public string Name2
    {
      get;
      set;
    }
    public string Strasse
    {
      get;
      set;
    }
    public string PLZ
    {
      get;
      set;
    }
    public string Ort
    {
      get;
      set;
    }
    public string Telefon1
    {
      get;
      set;
    }
    public string EMail1
    {
      get;
      set;
    }
    public string NameNV
    {
      get;
      set;
    }
    public string NameVN
    {
      get;
      set;
    }
    public string BildURL
    {
      get;
      set;
    }
    public DateTime? Geburtsdatum
    {
      get;
      set;
    }
    public int? Jahr
    {
      get;
      set;
    }
    public int? Monat
    {
      get;
      set;
    }
    public int? Tag
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
    public string GeburtstagKurz
    {
      get;
      set;
    }
    public int? GeburtstagAlter
    {
      get;
      set;
    }
    public decimal? GeburtstagAlterGenau
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
  }
}
