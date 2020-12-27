using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwDashboardTermineGeplant")]
  public partial class VwDashboardTermineGeplant
  {
    public int EreignisID
    {
      get;
      set;
    }
    [Key]
    public string EreignisArtCode
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public Int64? KundenID
    {
      get;
      set;
    }
    public string Jahr
    {
      get;
      set;
    }
    public string Am
    {
      get;
      set;
    }
    public string Von
    {
      get;
      set;
    }
    public string Bis
    {
      get;
      set;
    }
    public Int64? Minuten
    {
      get;
      set;
    }
    public string Stunden
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
  }
}
