using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseArtenMitTextAlle")]
  public partial class VwEreignisseArtenMitTextAlle
  {
    [Key]
    public string EreignisArtCode
    {
      get;
      set;
    }
    public string BisEreignisArtCode
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
    public Int64? TermineDienstplan
    {
      get;
      set;
    }
    public Int64? TermineManagement
    {
      get;
      set;
    }
    public Int64? SortierungTermineDienstplan
    {
      get;
      set;
    }
    public Int64? SortierungTermineManagement
    {
      get;
      set;
    }
  }
}
