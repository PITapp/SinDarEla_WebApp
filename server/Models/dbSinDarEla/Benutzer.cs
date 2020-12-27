using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("Benutzer")]
  public partial class Benutzer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BenutzerID
    {
      get;
      set;
    }


    public ICollection<BenutzerModule> BenutzerModules { get; set; }

    public ICollection<BenutzerProtokoll> BenutzerProtokolls { get; set; }
    public int BaseID
    {
      get;
      set;
    }

    public Base Base { get; set; }
    public int BenutzerRolleID
    {
      get;
      set;
    }

    public BenutzerRollen BenutzerRollen { get; set; }
    public string Benutzername
    {
      get;
      set;
    }
    public string Kennwort
    {
      get;
      set;
    }
    public string Initialen
    {
      get;
      set;
    }
    public bool? Sperren
    {
      get;
      set;
    }
    public string BenutzerInfo
    {
      get;
      set;
    }
    public DateTime? Angemeldet
    {
      get;
      set;
    }
    public DateTime? Abgemeldet
    {
      get;
      set;
    }
    public int? LetzteKundenID
    {
      get;
      set;
    }
    public int? LetzteMitarbeiterID
    {
      get;
      set;
    }
    public int? LetzteBaseID
    {
      get;
      set;
    }
    public int? LetzteBenutzerID
    {
      get;
      set;
    }
  }
}
