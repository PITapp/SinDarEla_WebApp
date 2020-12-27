using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("BenutzerRollen")]
  public partial class BenutzerRollen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BenutzerRolleID
    {
      get;
      set;
    }


    public ICollection<Benutzer> Benutzers { get; set; }
    public string Bezeichnung
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
  }
}
