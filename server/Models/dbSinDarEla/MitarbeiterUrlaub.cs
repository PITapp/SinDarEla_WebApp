using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("MitarbeiterUrlaub")]
  public partial class MitarbeiterUrlaub
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterUrlaubID
    {
      get;
      set;
    }


    public ICollection<MitarbeiterUrlaubDetail> MitarbeiterUrlaubDetails { get; set; }
    public int MitarbeiterID
    {
      get;
      set;
    }

    public Mitarbeiter Mitarbeiter { get; set; }
    public int Jahr
    {
      get;
      set;
    }
    public int AnspruchJahrTage
    {
      get;
      set;
    }
    public double AnspruchJahrWochen
    {
      get;
      set;
    }
    public double RestVorjahr
    {
      get;
      set;
    }
    public double AnspruchJahr
    {
      get;
      set;
    }
    public double AnspruchGesamt
    {
      get;
      set;
    }
    public double Verbraucht
    {
      get;
      set;
    }
    public double Geplant
    {
      get;
      set;
    }
    public double RestJahr
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
