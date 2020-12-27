using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("Dokumente")]
  public partial class Dokumente
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DokumentID
    {
      get;
      set;
    }


    public ICollection<MitarbeiterFortbildungen> MitarbeiterFortbildungens { get; set; }

    public ICollection<Mitteilungen> Mitteilungens { get; set; }
    public int DokumenteKategorieID
    {
      get;
      set;
    }

    public DokumenteKategorien DokumenteKategorien { get; set; }
    public int? KundenID
    {
      get;
      set;
    }

    public Kunden Kunden { get; set; }
    public int? MitarbeiterID
    {
      get;
      set;
    }

    public Mitarbeiter Mitarbeiter { get; set; }
    public string Titel
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string DokumentURL
    {
      get;
      set;
    }
  }
}
