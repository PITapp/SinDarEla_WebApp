using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterVerlaufDienstzeiten")]
  public partial class MitarbeiterVerlaufDienstzeiten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterVerlaufDienstzeitenID
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
    public int MitarbeiterVerlaufDienstzeitenArtID
    {
      get;
      set;
    }

    public MitarbeiterVerlaufDienstzeitenArten MitarbeiterVerlaufDienstzeitenArten { get; set; }
    public DateTime Von
    {
      get;
      set;
    }
    public DateTime? Bis
    {
      get;
      set;
    }
    public int? AnzahlTage
    {
      get;
      set;
    }
    public int? AnzahlMonate
    {
      get;
      set;
    }
    public int? AnzahlJahre
    {
      get;
      set;
    }
    public double? AnzahlJahreKomma
    {
      get;
      set;
    }
    public int? AnzahlBisLeer
    {
      get;
      set;
    }
    public string AnzahlText
    {
      get;
      set;
    }
    public bool? AnrechnungGehalt
    {
      get;
      set;
    }
    public bool? AnrechnungUrlaub
    {
      get;
      set;
    }
    public int? Sortierung
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
