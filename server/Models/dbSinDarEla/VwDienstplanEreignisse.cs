using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwDienstplanEreignisse")]
  public partial class VwDienstplanEreignisse
  {
    public int EreignisID
    {
      get;
      set;
    }
    [Key]
    public string EreignisArtCode
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public DateTime Start
    {
      get;
      set;
    }
    public DateTime Ende
    {
      get;
      set;
    }
    public Int64? KundenID
    {
      get;
      set;
    }
    public string Zeit
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
  }
}
