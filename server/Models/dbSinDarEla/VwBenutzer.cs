using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwBenutzer")]
  public partial class VwBenutzer
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
    public int BenutzerRolleID
    {
      get;
      set;
    }
    public string BenutzerRolle
    {
      get;
      set;
    }
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
    public string Sperren
    {
      get;
      set;
    }
    public string Angemeldet
    {
      get;
      set;
    }
    public string Abgemeldet
    {
      get;
      set;
    }
    public string BenutzerInfo
    {
      get;
      set;
    }
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
    public int? AnredeID
    {
      get;
      set;
    }
    public string Anrede
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
    public string Geburtsdatum
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
