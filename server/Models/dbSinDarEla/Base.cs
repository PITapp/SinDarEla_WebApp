using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("Base")]
  public partial class Base
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BaseID
    {
      get;
      set;
    }


    public ICollection<Aufgaben> Aufgabens { get; set; }

    public ICollection<Aufgaben> Aufgabens1 { get; set; }

    public ICollection<BaseBanken> BaseBankens { get; set; }

    public ICollection<BaseKontakte> BaseKontaktes { get; set; }

    public ICollection<Benutzer> Benutzers { get; set; }

    public ICollection<Ereignisse> Ereignisses { get; set; }

    public ICollection<EreignisseTeilnehmer> EreignisseTeilnehmers { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; }

    public ICollection<Kunden> Kundens { get; set; }

    public ICollection<KundenKontakte> KundenKontaktes { get; set; }

    public ICollection<KundenLeistungenBetreuer> KundenLeistungenBetreuers { get; set; }

    public ICollection<Mitarbeiter> Mitarbeiters { get; set; }

    public ICollection<Mitteilungen> Mitteilungens { get; set; }

    public ICollection<MitteilungenVerteiler> MitteilungenVerteilers { get; set; }

    public ICollection<Protokoll> Protokolls { get; set; }
    public int? AnredeID
    {
      get;
      set;
    }

    public BaseAnreden BaseAnreden { get; set; }
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
    public string NameVorNach
    {
      get;
      set;
    }
    public string NameKuerzel
    {
      get;
      set;
    }
    public string TitelVorne
    {
      get;
      set;
    }
    public string TitelHinten
    {
      get;
      set;
    }
    public string Strasse
    {
      get;
      set;
    }
    public string PLZ
    {
      get;
      set;
    }
    public string Ort
    {
      get;
      set;
    }
    public DateTime? Geburtsdatum
    {
      get;
      set;
    }
    public string Versicherungsnummer
    {
      get;
      set;
    }
    public string Staatsangehoerigkeit
    {
      get;
      set;
    }
    public string Telefon1
    {
      get;
      set;
    }
    public string Telefon2
    {
      get;
      set;
    }
    public string EMail1
    {
      get;
      set;
    }
    public string EMail2
    {
      get;
      set;
    }
    public string Webseite
    {
      get;
      set;
    }
    public string BildURL
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
