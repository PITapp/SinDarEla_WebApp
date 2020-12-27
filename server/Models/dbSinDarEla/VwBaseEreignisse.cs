using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwBaseEreignisse")]
  public partial class VwBaseEreignisse
  {
    public int EreignisID
    {
      get;
      set;
    }
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public DateTime Start
    {
      get;
      set;
    }
    public string StartText
    {
      get;
      set;
    }
    public string Zeit
    {
      get;
      set;
    }
    public string ZeitText
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
  }
}
