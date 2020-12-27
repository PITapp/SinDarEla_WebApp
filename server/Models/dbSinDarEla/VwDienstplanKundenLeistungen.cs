using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwDienstplanKundenLeistungen")]
  public partial class VwDienstplanKundenLeistungen
  {
    public int KundenID
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
    public string Name1
    {
      get;
      set;
    }
    public string Name2
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
    public string LeistungArt
    {
      get;
      set;
    }
    public string LeistungSchluessel
    {
      get;
      set;
    }
    public int Anspruch
    {
      get;
      set;
    }
    public int Verbrauch
    {
      get;
      set;
    }
    public int Rest
    {
      get;
      set;
    }
    public int KundenbesucheErledigt
    {
      get;
      set;
    }
    public int KundenbesucheGeplant
    {
      get;
      set;
    }
    public int KundenbesucheOffen
    {
      get;
      set;
    }
  }
}
