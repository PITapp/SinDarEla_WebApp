using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitteilungenVerteiler")]
  public partial class MitteilungenVerteiler
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitteilungVerteilerID
    {
      get;
      set;
    }
    public int MitteilungID
    {
      get;
      set;
    }

    public Mitteilungen Mitteilungen { get; set; }
    public int BaseID
    {
      get;
      set;
    }

    public Base Base { get; set; }
    public bool? Gelesen
    {
      get;
      set;
    }
    public DateTime? GelesenAm
    {
      get;
      set;
    }
    public string Kommentar
    {
      get;
      set;
    }
  }
}
