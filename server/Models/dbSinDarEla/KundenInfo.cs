using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenInfos")]
  public partial class KundenInfo
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenInfoID
    {
      get;
      set;
    }
    public int KundenID
    {
      get;
      set;
    }

    public Kunden Kunden { get; set; }
    public DateTime InfoDatum
    {
      get;
      set;
    }
    public string InfoTitel
    {
      get;
      set;
    }
    public string InfoText
    {
      get;
      set;
    }
  }
}
