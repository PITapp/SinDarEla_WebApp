using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenLeistungen")]
  public partial class KundenLeistungen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungID
    {
      get;
      set;
    }


    public ICollection<KundenLeistungenBescheide> KundenLeistungenBescheides { get; set; }

    public ICollection<KundenLeistungenBetreuer> KundenLeistungenBetreuers { get; set; }
    public int KundenID
    {
      get;
      set;
    }

    public Kunden Kunden { get; set; }
    public int KundenLeistungArtID
    {
      get;
      set;
    }

    public KundenLeistungArten KundenLeistungArten { get; set; }
  }
}
