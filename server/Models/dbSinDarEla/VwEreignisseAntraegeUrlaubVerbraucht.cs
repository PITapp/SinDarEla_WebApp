using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseAntraegeUrlaubVerbraucht")]
  public partial class VwEreignisseAntraegeUrlaubVerbraucht
  {
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public string EreignisArtCode
    {
      get;
      set;
    }
    public decimal? Tage
    {
      get;
      set;
    }
  }
}
