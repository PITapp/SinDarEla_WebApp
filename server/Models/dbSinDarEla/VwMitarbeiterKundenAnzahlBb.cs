using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterKundenAnzahlBB")]
  public partial class VwMitarbeiterKundenAnzahlBb
  {
    public int MitarbeiterID
    {
      get;
      set;
    }
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public Int64 AnzahlvonKundenID
    {
      get;
      set;
    }
  }
}
