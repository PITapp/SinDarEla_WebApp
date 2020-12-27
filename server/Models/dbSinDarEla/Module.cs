using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("Module")]
  public partial class Module
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ModulID
    {
      get;
      set;
    }


    public ICollection<BenutzerModule> BenutzerModules { get; set; }
    public string ModulName
    {
      get;
      set;
    }
    public string Gruppe
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string ActionLabel
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
    public int? ItemBadge
    {
      get;
      set;
    }
    public string SubActions
    {
      get;
      set;
    }
    public string VerwendenFuer
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
    public bool? ImDashboard
    {
      get;
      set;
    }
    public int? ImDashboardSortierung
    {
      get;
      set;
    }
    public bool? ImLeftMenue
    {
      get;
      set;
    }
    public int? ImLeftMenueSortierung
    {
      get;
      set;
    }
  }
}
