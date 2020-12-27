using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("Kunden")]
  public partial class Kunden
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenID
    {
      get;
      set;
    }


    public ICollection<AbrechnungKundenReststunden> AbrechnungKundenReststundens { get; set; }

    public ICollection<Dokumente> Dokumentes { get; set; }

    public ICollection<Ereignisse> Ereignisses { get; set; }

    public ICollection<KundenInfo> KundenInfos { get; set; }

    public ICollection<KundenKontakte> KundenKontaktes { get; set; }

    public ICollection<KundenLeistungen> KundenLeistungens { get; set; }
    public int BaseID
    {
      get;
      set;
    }

    public Base Base { get; set; }
    public int KundenStatusID
    {
      get;
      set;
    }

    public KundenStatus KundenStatus { get; set; }
    public DateTime Betreuungsbeginn
    {
      get;
      set;
    }
    public string Vorbemerkungen
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
