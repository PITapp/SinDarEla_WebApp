using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterTaetigkeitenArten")]
  public partial class MitarbeiterTaetigkeitenArten
  {
    [Key]
    public int MitarbeiterTaetigkeitenArtID
    {
      get;
      set;
    }


    public ICollection<MitarbeiterTaetigkeiten> MitarbeiterTaetigkeitens { get; set; }
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
    public int? Sortierung
    {
      get;
      set;
    }
  }
}
