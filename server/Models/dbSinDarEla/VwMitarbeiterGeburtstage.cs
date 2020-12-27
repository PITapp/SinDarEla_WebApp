using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterGeburtstage")]
  public partial class VwMitarbeiterGeburtstage
  {
    public string Art
    {
      get;
      set;
    }
    public string ArtKurz
    {
      get;
      set;
    }
    public int BetreuerBaseID
    {
      get;
      set;
    }
    public int TabelleID
    {
      get;
      set;
    }
    [Key]
    public int BaseID
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
    public string GeborenTag
    {
      get;
      set;
    }
    public string GeborenMonat
    {
      get;
      set;
    }
    public string GeborenJahr
    {
      get;
      set;
    }
    public DateTime? GeborenDiesesJahr
    {
      get;
      set;
    }
    public string WochentagKurz
    {
      get;
      set;
    }
    public string WochentagLang
    {
      get;
      set;
    }
    public string GeborenKurz
    {
      get;
      set;
    }
    public string GeborenLang
    {
      get;
      set;
    }
    public int? GeborenAlter
    {
      get;
      set;
    }
    public string GeborenStatus
    {
      get;
      set;
    }
    public string GeborenZeigen
    {
      get;
      set;
    }
    public string GeborenZeigenZeichen
    {
      get;
      set;
    }
  }
}
