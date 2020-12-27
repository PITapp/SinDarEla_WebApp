using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("BaseBanken")]
  public partial class BaseBanken
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BankID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }

    public Base Base { get; set; }
    public string NameBank
    {
      get;
      set;
    }
    public string Kontonummer
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
  }
}
