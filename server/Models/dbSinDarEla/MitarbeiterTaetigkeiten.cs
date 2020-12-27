using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterTaetigkeiten")]
  public partial class MitarbeiterTaetigkeiten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterTaetigkeitenID
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
    public int MitarbeiterTaetigkeitenArtID
    {
      get;
      set;
    }

    public MitarbeiterTaetigkeitenArten MitarbeiterTaetigkeitenArten { get; set; }
  }
}
