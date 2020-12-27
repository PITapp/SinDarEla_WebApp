using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwBenutzerModule")]
  public partial class VwBenutzerModule
  {
    public int BenutzerID
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
    public string ModulName
    {
      get;
      set;
    }
    public string ActionLabel
    {
      get;
      set;
    }
    public string ActionLabelMitAbstandLinks
    {
      get;
      set;
    }
    public string ActionIcon
    {
      get;
      set;
    }
    public string ActionLink
    {
      get;
      set;
    }
    public string ActionTask
    {
      get;
      set;
    }
    public string UserRole
    {
      get;
      set;
    }
    public string ItemBadge
    {
      get;
      set;
    }
    public string SubActions
    {
      get;
      set;
    }
  }
}
