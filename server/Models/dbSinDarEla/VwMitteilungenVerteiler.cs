using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitteilungenVerteiler")]
  public partial class VwMitteilungenVerteiler
  {
    public int MitteilungVerteilerID
    {
      get;
      set;
    }
    [Key]
    public int MitteilungID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public string Gelesen
    {
      get;
      set;
    }
    public string GelesenAm
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
  }
}
