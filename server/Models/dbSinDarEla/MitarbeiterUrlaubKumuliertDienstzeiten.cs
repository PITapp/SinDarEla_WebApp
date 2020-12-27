using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterUrlaubKumuliertDienstzeiten")]
  public partial class MitarbeiterUrlaubKumuliertDienstzeiten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterUrlaubKumuliertDienstzeitenID
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
    public int Sortierung
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
    public string DienstzeitCode
    {
      get;
      set;
    }
    public string DienstzeitAnrechnungInfo
    {
      get;
      set;
    }
    public double? DienstzeitBerechnet
    {
      get;
      set;
    }
    public double? DienstzeitAnrechnung
    {
      get;
      set;
    }
  }
}
