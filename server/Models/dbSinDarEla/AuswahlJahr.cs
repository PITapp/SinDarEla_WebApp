using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("AuswahlJahr")]
  public partial class AuswahlJahr
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuswahlJahrID
    {
      get;
      set;
    }
    public int Jahr
    {
      get;
      set;
    }
  }
}
