using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("vwMitarbeiter")]
  public partial class VwMitarbeiter
  {
    public int MitarbeiterID
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
    public int MitarbeiterArtID
    {
      get;
      set;
    }
    public string MitarbeiterArt
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }
    public string ArbeitsrechtEintritt
    {
      get;
      set;
    }
    public string ArbeitsrechtAustritt
    {
      get;
      set;
    }
    public string LetzterEintritt
    {
      get;
      set;
    }
    public string LetzterAustritt
    {
      get;
      set;
    }
    public string Notfallkontakt
    {
      get;
      set;
    }
    public string NotfallkontaktTelefon
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
    public string InfoGF
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
    public string BaseInfo
    {
      get;
      set;
    }
  }
}
