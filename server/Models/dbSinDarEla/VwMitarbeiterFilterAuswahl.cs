using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterFilterAuswahl")]
  public partial class VwMitarbeiterFilterAuswahl
  {
    [Key]
    public int ID
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string Gruppe
    {
      get;
      set;
    }
    public Int64 SortierungGruppe
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
  }
}
