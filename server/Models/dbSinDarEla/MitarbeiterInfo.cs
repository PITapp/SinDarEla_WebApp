using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterInfos")]
  public partial class MitarbeiterInfo
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterInfoID
    {
      get;
      set;
    }
    public int MitarbeiterID
    {
      get;
      set;
    }

    public Mitarbeiter Mitarbeiter { get; set; }
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
