using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitteilungenOffen")]
  public partial class VwMitteilungenOffen
  {
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public Int64 MitteilungenOffen
    {
      get;
      set;
    }
  }
}
