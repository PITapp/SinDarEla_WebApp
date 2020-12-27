using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("AuswahlMonat")]
  public partial class AuswahlMonat
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuswahlMonatID
    {
      get;
      set;
    }
    public int MonatZahl
    {
      get;
      set;
    }
    public string MonatText
    {
      get;
      set;
    }
  }
}
