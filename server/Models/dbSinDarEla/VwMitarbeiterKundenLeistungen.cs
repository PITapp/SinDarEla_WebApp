using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterKundenLeistungen")]
  public partial class VwMitarbeiterKundenLeistungen
  {
    public int MitarbeiterID
    {
      get;
      set;
    }
    [Key]
    public int MitarbeiterBaseID
    {
      get;
      set;
    }
    public int KundenID
    {
      get;
      set;
    }
    public int KundenBaseID
    {
      get;
      set;
    }
    public string NameGesamt
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
    public string Betreuungsart
    {
      get;
      set;
    }
  }
}
