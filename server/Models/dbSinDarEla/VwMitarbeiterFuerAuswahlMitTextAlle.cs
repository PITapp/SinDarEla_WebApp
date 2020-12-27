using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterFuerAuswahlMitTextAlle")]
  public partial class VwMitarbeiterFuerAuswahlMitTextAlle
  {
    [Key]
    public Int64 MitarbeiterID
    {
      get;
      set;
    }
    public Int64 BaseID
    {
      get;
      set;
    }
    public Int64 MitarbeiterArtID
    {
      get;
      set;
    }
    public Int64 MitarbeiterStatusID
    {
      get;
      set;
    }
    public Int64 MitarbeiterTaetigkeitenArtID
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
    public string NameKuerzel
    {
      get;
      set;
    }
  }
}
