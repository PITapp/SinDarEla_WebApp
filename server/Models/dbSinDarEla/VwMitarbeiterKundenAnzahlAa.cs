using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterKundenAnzahlAA")]
  public partial class VwMitarbeiterKundenAnzahlAa
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
    public int KundenID
    {
      get;
      set;
    }
  }
}
