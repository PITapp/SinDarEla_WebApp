using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterStatus")]
  public partial class MitarbeiterStatus
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterStatusID
    {
      get;
      set;
    }


    public ICollection<Mitarbeiter> Mitarbeiters { get; set; }
    public string Status
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
