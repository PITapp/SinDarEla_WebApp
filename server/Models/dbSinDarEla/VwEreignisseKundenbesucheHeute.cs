using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseKundenbesucheHeute")]
  public partial class VwEreignisseKundenbesucheHeute
  {
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
    public DateTime Ende
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string TitelAnzeige
    {
      get;
      set;
    }
  }
}
