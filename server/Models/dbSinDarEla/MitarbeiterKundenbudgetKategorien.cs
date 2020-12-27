using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterKundenbudgetKategorien")]
  public partial class MitarbeiterKundenbudgetKategorien
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenbudgetKategorieID
    {
      get;
      set;
    }


    public ICollection<MitarbeiterKundenbudget> MitarbeiterKundenbudgets { get; set; }
    public string Titel
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
