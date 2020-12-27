using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterFortbildungen")]
  public partial class MitarbeiterFortbildungen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterFortbildungID
    {
      get;
      set;
    }
    public int? DokumentID
    {
      get;
      set;
    }

    public Dokumente Dokumente { get; set; }
    public int MitarbeiterID
    {
      get;
      set;
    }

    public Mitarbeiter Mitarbeiter { get; set; }
    public int FortbildungArtID
    {
      get;
      set;
    }

    public MitarbeiterFortbildungenArten MitarbeiterFortbildungenArten { get; set; }
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
    public string Veranstalter
    {
      get;
      set;
    }
    public double? Kosten
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
