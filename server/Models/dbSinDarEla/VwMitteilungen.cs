using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitteilungen")]
  public partial class VwMitteilungen
  {
    public int MitteilungID
    {
      get;
      set;
    }
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public string Ersteller
    {
      get;
      set;
    }
    public DateTime Am
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public Int64 DokumentID
    {
      get;
      set;
    }
    public string DokumentTitel
    {
      get;
      set;
    }
    public string DokumentURL
    {
      get;
      set;
    }
  }
}
