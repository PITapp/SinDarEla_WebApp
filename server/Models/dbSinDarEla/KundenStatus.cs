using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenStatus")]
  public partial class KundenStatus
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenStatusID
    {
      get;
      set;
    }


    public ICollection<Kunden> Kundens { get; set; }
    public string Status
    {
      get;
      set;
    }
  }
}
