using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwKundenHauptbetreuer")]
  public partial class VwKundenHauptbetreuer
  {
    public int KundenLeistungenBetreuerID
    {
      get;
      set;
    }
    public int KundenLeistungID
    {
      get;
      set;
    }
    public int KundenID
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
    public string NameGesamt
    {
      get;
      set;
    }
    public string LeistungArt
    {
      get;
      set;
    }
    public string LeistungSchluessel
    {
      get;
      set;
    }
  }
}
