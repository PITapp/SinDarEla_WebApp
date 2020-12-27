using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("BaseKontakte")]
  public partial class BaseKontakte
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KontaktID
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
    public int? AnredeID
    {
      get;
      set;
    }

    public BaseAnreden BaseAnreden { get; set; }
    public string NameKontakt
    {
      get;
      set;
    }
    public string Handy
    {
      get;
      set;
    }
    public string Telefon
    {
      get;
      set;
    }
    public string EMail
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
