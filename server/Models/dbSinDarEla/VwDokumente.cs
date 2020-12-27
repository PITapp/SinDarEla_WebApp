using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwDokumente")]
  public partial class VwDokumente
  {
    public int DokumentID
    {
      get;
      set;
    }
    [Key]
    public int DokumenteKategorieID
    {
      get;
      set;
    }
    public string Kategorie
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
    public string DokumentURL
    {
      get;
      set;
    }
  }
}
