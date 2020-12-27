using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterFortbildungenArten")]
  public partial class MitarbeiterFortbildungenArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FortbildungArtID
    {
      get;
      set;
    }


    public ICollection<MitarbeiterFortbildungen> MitarbeiterFortbildungens { get; set; }
    public string Titel
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
