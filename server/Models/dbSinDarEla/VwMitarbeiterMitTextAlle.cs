using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiterMitTextAlle")]
  public partial class VwMitarbeiterMitTextAlle
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
    public Int64 BisBaseID
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
