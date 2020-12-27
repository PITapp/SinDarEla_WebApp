using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("BaseAnreden")]
  public partial class BaseAnreden
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnredeID
    {
      get;
      set;
    }


    public ICollection<Base> Bases { get; set; }

    public ICollection<BaseKontakte> BaseKontaktes { get; set; }
    public string Anrede
    {
      get;
      set;
    }
  }
}
