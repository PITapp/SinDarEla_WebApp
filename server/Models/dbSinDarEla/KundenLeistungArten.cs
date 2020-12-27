using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenLeistungArten")]
  public partial class KundenLeistungArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungArtID
    {
      get;
      set;
    }


    public ICollection<AbrechnungKundenReststunden> AbrechnungKundenReststundens { get; set; }

    public ICollection<Ereignisse> Ereignisses { get; set; }

    public ICollection<KundenLeistungen> KundenLeistungens { get; set; }
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
  }
}
