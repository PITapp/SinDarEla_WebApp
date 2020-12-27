using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterKundenbudget")]
  public partial class MitarbeiterKundenbudget
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterKundenbudgetID
    {
      get;
      set;
    }
    public int MitarbeiterID
    {
      get;
      set;
    }

    public Mitarbeiter Mitarbeiter { get; set; }
    public int KundenbudgetKategorieID
    {
      get;
      set;
    }

    public MitarbeiterKundenbudgetKategorien MitarbeiterKundenbudgetKategorien { get; set; }
    public DateTime AusgabeAm
    {
      get;
      set;
    }
    public string AusgabeText
    {
      get;
      set;
    }
    public double AusgabeBetrag
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
  }
}
