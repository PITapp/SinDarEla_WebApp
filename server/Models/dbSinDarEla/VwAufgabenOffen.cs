using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwAufgabenOffen")]
  public partial class VwAufgabenOffen
  {
    [Key]
    public int? ZustaendigBaseID
    {
      get;
      set;
    }
    public Int64 AufgabenOffen
    {
      get;
      set;
    }
  }
}
