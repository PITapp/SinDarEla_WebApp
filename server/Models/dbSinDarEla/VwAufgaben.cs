using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwAufgaben")]
  public partial class VwAufgaben
  {
    public int AufgabeID
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
    public Int64 ZustaendigBaseID
    {
      get;
      set;
    }
    public string Zustaendig
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
    public string FaelligBis
    {
      get;
      set;
    }
    public string Erledigt
    {
      get;
      set;
    }
    public string ErledigtAm
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
