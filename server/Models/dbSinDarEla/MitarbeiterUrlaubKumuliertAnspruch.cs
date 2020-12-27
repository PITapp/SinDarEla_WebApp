using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterUrlaubKumuliertAnspruch")]
  public partial class MitarbeiterUrlaubKumuliertAnspruch
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterUrlaubKumuliertAnspruchID
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
    public int Jahre
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
    public int AnspruchTage
    {
      get;
      set;
    }
    public double AnspruchWochen
    {
      get;
      set;
    }
    public DateTime? AnspruchBerechnetAb
    {
      get;
      set;
    }
    public DateTime? AnspruchAb
    {
      get;
      set;
    }
    public int? AnspruchJahrVon
    {
      get;
      set;
    }
    public int? AnspruchJahrBis
    {
      get;
      set;
    }
  }
}
