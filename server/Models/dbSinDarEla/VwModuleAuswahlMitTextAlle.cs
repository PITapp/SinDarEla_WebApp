using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwModuleAuswahlMitTextAlle")]
  public partial class VwModuleAuswahlMitTextAlle
  {
    [Key]
    public Int64 ModulID
    {
      get;
      set;
    }
    public string ModulName
    {
      get;
      set;
    }
    public Int64? Sortierung
    {
      get;
      set;
    }
  }
}
