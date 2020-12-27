using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterAuswahlTermin")]
  public partial class VwMitarbeiterAuswahlTermin
  {
    public int MitarbeiterID
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
    public string NameGesamt
    {
      get;
      set;
    }
    public int MitarbeiterStatusID
    {
      get;
      set;
    }
  }
}
