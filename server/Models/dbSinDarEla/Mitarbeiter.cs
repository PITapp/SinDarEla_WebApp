using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("Mitarbeiter")]
  public partial class Mitarbeiter
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterID
    {
      get;
      set;
    }


    public ICollection<Dokumente> Dokumentes { get; set; }

    public ICollection<MitarbeiterFortbildungen> MitarbeiterFortbildungens { get; set; }

    public ICollection<MitarbeiterInfo> MitarbeiterInfos { get; set; }

    public ICollection<MitarbeiterKundenbudget> MitarbeiterKundenbudgets { get; set; }

    public ICollection<MitarbeiterTaetigkeiten> MitarbeiterTaetigkeitens { get; set; }

    public ICollection<MitarbeiterUrlaub> MitarbeiterUrlaubs { get; set; }

    public ICollection<MitarbeiterUrlaubKumuliertAnspruch> MitarbeiterUrlaubKumuliertAnspruches { get; set; }

    public ICollection<MitarbeiterUrlaubKumuliertDienstzeiten> MitarbeiterUrlaubKumuliertDienstzeitens { get; set; }

    public ICollection<MitarbeiterVerlaufDienstzeiten> MitarbeiterVerlaufDienstzeitens { get; set; }

    public ICollection<MitarbeiterVerlaufGehalt> MitarbeiterVerlaufGehalts { get; set; }

    public ICollection<MitarbeiterVerlaufNormalarbeitszeit> MitarbeiterVerlaufNormalarbeitszeits { get; set; }
    public int BaseID
    {
      get;
      set;
    }

    public Base Base { get; set; }
    public int MitarbeiterArtID
    {
      get;
      set;
    }

    public MitarbeiterArten MitarbeiterArten { get; set; }
    public int MitarbeiterStatusID
    {
      get;
      set;
    }

    public MitarbeiterStatus MitarbeiterStatus { get; set; }
    public DateTime? ArbeitsrechtEintritt
    {
      get;
      set;
    }
    public DateTime? ArbeitsrechtAustritt
    {
      get;
      set;
    }
    public DateTime? LetzterEintritt
    {
      get;
      set;
    }
    public DateTime? LetzterAustritt
    {
      get;
      set;
    }
    public string Notfallkontakt
    {
      get;
      set;
    }
    public string NotfallkontaktTelefon
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
    public string InfoGF
    {
      get;
      set;
    }
  }
}
