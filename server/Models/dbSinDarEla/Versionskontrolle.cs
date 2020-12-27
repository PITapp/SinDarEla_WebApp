using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("Versionskontrolle")]
  public partial class Versionskontrolle
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VersionskontrolleID
    {
      get;
      set;
    }
    public DateTime ErstelltAm
    {
      get;
      set;
    }
    public string Versionsnummer
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
  }
}
