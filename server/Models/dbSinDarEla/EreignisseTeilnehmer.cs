using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("EreignisseTeilnehmer")]
  public partial class EreignisseTeilnehmer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EreignisseTeilnehmerID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }

    public Base Base { get; set; }
    public int EreignisID
    {
      get;
      set;
    }

    public Ereignisse Ereignisse { get; set; }
    public string StatusCode
    {
      get;
      set;
    }

    public EreignisseTeilnehmerStatus EreignisseTeilnehmerStatus { get; set; }
    public string Nachricht
    {
      get;
      set;
    }
  }
}
