using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterArtenMitTextAlle")]
  public partial class VwMitarbeiterArtenMitTextAlle
  {
    [Key]
    public Int64 MitarbeiterArtID
    {
      get;
      set;
    }
    public Int64 BisMitarbeiterArtID
    {
      get;
      set;
    }
    public string MitarbeiterArt
    {
      get;
      set;
    }
    public Int64? Sortierung
    {
      get;
      set;
    }
  }
}
