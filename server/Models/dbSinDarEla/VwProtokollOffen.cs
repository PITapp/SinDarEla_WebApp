using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwProtokollOffen")]
  public partial class VwProtokollOffen
  {
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public Int64 ProtokollOffen
    {
      get;
      set;
    }
  }
}
