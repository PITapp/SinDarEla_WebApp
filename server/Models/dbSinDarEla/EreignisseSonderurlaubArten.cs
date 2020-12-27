using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("EreignisseSonderurlaubArten")]
  public partial class EreignisseSonderurlaubArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EreignisSonderurlaubArtID
    {
      get;
      set;
    }


    public ICollection<Ereignisse> Ereignisses { get; set; }
    public string Bezeichnung
    {
      get;
      set;
    }
    public string FreieTage
    {
      get;
      set;
    }
    public string FreieTageZusatz
    {
      get;
      set;
    }
    public int? Sortierung
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
