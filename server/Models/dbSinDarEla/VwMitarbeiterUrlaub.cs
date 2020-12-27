using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterUrlaub")]
  public partial class VwMitarbeiterUrlaub
  {
    public int MitarbeiterUrlaubID
    {
      get;
      set;
    }
    [Key]
    public int MitarbeiterID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
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
