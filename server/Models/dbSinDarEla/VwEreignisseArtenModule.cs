using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseArtenModule")]
  public partial class VwEreignisseArtenModule
  {
    [Key]
    public string NameModul
    {
      get;
      set;
    }
    public string EreignisArtCode
    {
      get;
      set;
    }
    public string Bezeichnung
    {
      get;
      set;
    }
    public string Kurzzeichen
    {
      get;
      set;
    }
    public int? SortierungTermineDienstplan
    {
      get;
      set;
    }
  }
}
