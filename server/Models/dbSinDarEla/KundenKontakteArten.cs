using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenKontakteArten")]
  public partial class KundenKontakteArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenKontaktArtID
    {
      get;
      set;
    }


    public ICollection<KundenKontakte> KundenKontaktes { get; set; }
    public string Bezeichnung
    {
      get;
      set;
    }
    public string Gruppe
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
  }
}
