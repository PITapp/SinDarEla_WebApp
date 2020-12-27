using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwBenutzerAuswahlNeue")]
  public partial class VwBenutzerAuswahlNeue
  {
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
  }
}
