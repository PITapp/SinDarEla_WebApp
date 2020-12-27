using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterTaetigkeiten")]
  public partial class VwMitarbeiterTaetigkeiten
  {
    [Key]
    public int MitarbeiterID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public int MitarbeiterTaetigkeitenArtID
    {
      get;
      set;
    }
    public string TaetigkeitArt
    {
      get;
      set;
    }
    public string LeistungSchluessel
    {
      get;
      set;
    }
  }
}
