using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterVerlaufDienstzeiten")]
  public partial class VwMitarbeiterVerlaufDienstzeiten
  {
    public int MitarbeiterVerlaufDienstzeitenID
    {
      get;
      set;
    }
    [Key]
    public int MitarbeiterVerlaufDienstzeitenArtID
    {
      get;
      set;
    }
    public int MitarbeiterID
    {
      get;
      set;
    }
    public DateTime Von
    {
      get;
      set;
    }
    public string Bis
    {
      get;
      set;
    }
    public string Bis2
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
    public Int64? AnzahlTage
    {
      get;
      set;
    }
    public Int64? AnzahlMonate
    {
      get;
      set;
    }
    public Int64? AnzahlJahre
    {
      get;
      set;
    }
    public int BisIstNull
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }
    public bool? DienstzeitRechnen
    {
      get;
      set;
    }
    public Int64 Referenz_MitarbeiterStatusID
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
