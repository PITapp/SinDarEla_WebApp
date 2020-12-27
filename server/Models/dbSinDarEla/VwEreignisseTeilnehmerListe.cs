using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwEreignisseTeilnehmerListe")]
  public partial class VwEreignisseTeilnehmerListe
  {
    public int EreignisseTeilnehmerID
    {
      get;
      set;
    }
    [Key]
    public int EreignisID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public string StatusCode
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
    public string NameVorNach
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
