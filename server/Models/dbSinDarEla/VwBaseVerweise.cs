using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwBaseVerweise")]
  public partial class VwBaseVerweise
  {
    [Key]
    public string Ebene
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public int? KundenID
    {
      get;
      set;
    }
    public int? MitarbeiterID
    {
      get;
      set;
    }
    public int? BenutzerID
    {
      get;
      set;
    }
  }
}
