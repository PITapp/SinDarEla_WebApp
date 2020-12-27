using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterArten")]
  public partial class MitarbeiterArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterArtID
    {
      get;
      set;
    }


    public ICollection<Mitarbeiter> Mitarbeiters { get; set; }
    public string MitarbeiterArt
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
