using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenLeistungenBescheideStatus")]
  public partial class KundenLeistungenBescheideStatus
  {
    [Key]
    public string StatusCode
    {
      get;
      set;
    }


    public ICollection<KundenLeistungenBescheide> KundenLeistungenBescheides { get; set; }
    public string Bezeichnung
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
