using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("KundenKontakte")]
  public partial class KundenKontakte
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenKontaktID
    {
      get;
      set;
    }


    public ICollection<KundenLeistungenBescheide> KundenLeistungenBescheides { get; set; }
    public int BaseID
    {
      get;
      set;
    }

    public Base Base { get; set; }
    public int KundenID
    {
      get;
      set;
    }

    public Kunden Kunden { get; set; }
    public int KundenKontaktArtID
    {
      get;
      set;
    }

    public KundenKontakteArten KundenKontakteArten { get; set; }
    public bool Hauptansprechpartner
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
