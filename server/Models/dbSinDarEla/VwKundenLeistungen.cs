using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenLeistungen")]
  public partial class VwKundenLeistungen
  {
    public int KundenLeistungID
    {
      get;
      set;
    }
    [Key]
    public int KundenID
    {
      get;
      set;
    }
    public int KundenLeistungArtID
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
    public string LeistungArtTitel
    {
      get;
      set;
    }
    public string LeistungTitel
    {
      get;
      set;
    }
    public int LeistungMinuten
    {
      get;
      set;
    }
    public string KontingentTitel
    {
      get;
      set;
    }
    public int KontingentAnpruch
    {
      get;
      set;
    }
    public int KontingentVerbrauch
    {
      get;
      set;
    }
    public int KontingentRest
    {
      get;
      set;
    }
  }
}
