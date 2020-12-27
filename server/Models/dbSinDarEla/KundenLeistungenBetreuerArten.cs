using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenLeistungenBetreuerArten")]
  public partial class KundenLeistungenBetreuerArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungenBetreuerArtID
    {
      get;
      set;
    }


    public ICollection<KundenLeistungenBetreuer> KundenLeistungenBetreuers { get; set; }
    public string Bezeichnung
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
