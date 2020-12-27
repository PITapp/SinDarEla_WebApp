using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("EreignisseTeilnehmerStatus")]
  public partial class EreignisseTeilnehmerStatus
  {
    [Key]
    public string StatusCode
    {
      get;
      set;
    }


    public ICollection<EreignisseTeilnehmer> EreignisseTeilnehmers { get; set; }
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
    public string VerwendenFuer
    {
      get;
      set;
    }
  }
}
