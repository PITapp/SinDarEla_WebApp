using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwBaseStatistik")]
  public partial class VwBaseStatistik
  {
    [Key]
    public Int64 AnzahlBase
    {
      get;
      set;
    }
    public Int64 AnzahlKunden
    {
      get;
      set;
    }
    public Int64 AnzahlMitarbeiter
    {
      get;
      set;
    }
    public Int64 AnzahlBenutzer
    {
      get;
      set;
    }
  }
}
