export interface AbrechnungBasis {
  AbrechnungBasisID: number;
  Art: string;
  Jahr: number;
  Monat: number;
  Gesperrt: boolean;
  Info: string;
}

export interface AbrechnungKundenReststunden {
  AbrechnungKundenReststundenID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  AbrechnungBasisID: number;
  BaseID: number;
  KundenLeistungID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  KundenLeistungenBescheidID: number;
  Von: string;
  Bis: string;
  Stunden: number;
  StundenArt: string;
  Selbstkostenbefreiung: boolean;
  KundenLeistungenBescheideKontingentID: number;
  KontingentVon: string;
  KontingentBis: string;
  Anspruch: number;
  Reststunden: number;
  NichtAbgerechnet: number;
  Offen: number;
  Info: string;
}

export interface Aufgaben {
  AufgabeID: number;
  BaseID: number;
  ZustaendigBaseID: number;
  Am: string;
  Titel: string;
  Beschreibung: string;
  FaelligBis: string;
  Erledigt: boolean;
  ErledigtAm: string;
  Info: string;
}

export interface AuswahlJahr {
  AuswahlJahrID: number;
  Jahr: number;
}

export interface AuswahlMonat {
  AuswahlMonatID: number;
  MonatZahl: number;
  MonatText: string;
}

export interface Base {
  BaseID: number;
  AnredeID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  Info: string;
}

export interface BaseAnreden {
  AnredeID: number;
  Anrede: string;
}

export interface BaseBanken {
  BankID: number;
  BaseID: number;
  NameBank: string;
  Kontonummer: string;
  Info: string;
}

export interface BaseKontakte {
  KontaktID: number;
  BaseID: number;
  AnredeID: number;
  NameKontakt: string;
  Handy: string;
  Telefon: string;
  EMail: string;
  Info: string;
}

export interface Benutzer {
  BenutzerID: number;
  AspNetUsers_Id: string;
  BaseID: number;
  BenutzerRolleID: number;
  Benutzername: string;
  Kennwort: string;
  Initialen: string;
  EMail: string;
  Sperren: boolean;
  BenutzerInfo: string;
  Angemeldet: string;
  Abgemeldet: string;
  LetzteKundenID: number;
  LetzteMitarbeiterID: number;
  LetzteBaseID: number;
  LetzteBenutzerID: number;
}

export interface BenutzerModule {
  BenutzerModuleID: number;
  BenutzerID: number;
  ModulID: number;
  ErlaubtNeu: boolean;
  ErlaubtAendern: boolean;
  ErlaubtLoeschen: boolean;
  Info: string;
}

export interface BenutzerProtokoll {
  BenutzerProtokollID: number;
  BenutzerID: number;
  Art: string;
  TimeStamp: string;
}

export interface BenutzerRollen {
  BenutzerRolleID: number;
  Bezeichnung: string;
  Info: string;
}

export interface Debugg {
  DebuggID: number;
  Variable: string;
  VariableWert: string;
  Sortierung1: number;
  Sortierung2: number;
}

export interface Dokumente {
  DokumentID: number;
  DokumenteKategorieID: number;
  KundenID: number;
  MitarbeiterID: number;
  Titel: string;
  Beschreibung: string;
  DokumentURL: string;
}

export interface DokumenteKategorien {
  DokumenteKategorieID: number;
  Titel: string;
}

export interface Ereignisse {
  EreignisID: number;
  BaseID: number;
  EreignisArtCode: string;
  EreignisSonderurlaubArtID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  Start: string;
  Ende: string;
  GanzerTag: number;
  Titel: string;
  Beschreibung: string;
  BeantragtAm: string;
  BearbeiterBaseID: number;
  GenehmigtAm: string;
  AbgelehntAm: string;
  Begruendung: string;
  StatusAntrag: string;
  Verwendung: string;
  Gesperrt: number;
  Wert01: number;
  Bemerkungen: string;
  GefuehlSituation01: number;
  GefuehlSituation02: number;
  GefuehlSituation03: number;
  GefuehlSituation04: number;
  GefuehlSituation05: number;
  GefuehlSituation06: number;
  KundenFahrtMinuten: number;
  KundenFahrtKM: number;
  BetreuerAnAbReiseMinuten: number;
  BetreuerAnAbReiseKM: number;
}

export interface EreignisseArten {
  EreignisArtCode: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  TerminGanzerTag: boolean;
  Beantragungspflicht: boolean;
  Begruendungspflicht: boolean;
  TeilnehmerErfassen: boolean;
  KundeErfassen: boolean;
  FarbeName: string;
  FarbeHintergrund: string;
  FarbeText: string;
  FarbeName2: string;
  FarbeHintergrund2: string;
  FarbeText2: string;
  VerwendenFuer: string;
  Sortierung: number;
  TermineDienstplan: boolean;
  TermineManagement: boolean;
  SortierungTermineDienstplan: number;
  SortierungTermineManagement: number;
}

export interface EreignisseSonderurlaubArten {
  EreignisSonderurlaubArtID: number;
  Bezeichnung: string;
  FreieTage: string;
  FreieTageZusatz: string;
  Sortierung: number;
  Info: string;
}

export interface EreignisseTeilnehmer {
  EreignisseTeilnehmerID: number;
  BaseID: number;
  EreignisID: number;
  StatusCode: string;
  Nachricht: string;
}

export interface EreignisseTeilnehmerStatus {
  StatusCode: string;
  Titel: string;
  Sortierung: number;
  VerwendenFuer: string;
}

export interface Feedback {
  FeedbackID: number;
  BaseID: number;
  ErstelltAm: string;
  Modul: string;
  Titel: string;
  Beschreibung: string;
  Erledigt: boolean;
  ErledigtAm: string;
}

export interface Kunden {
  KundenID: number;
  BaseID: number;
  KundenStatusID: number;
  Betreuungsbeginn: string;
  Vorbemerkungen: string;
  Info: string;
}

export interface KundenInfo {
  KundenInfoID: number;
  KundenID: number;
  InfoDatum: string;
  InfoTitel: string;
  InfoText: string;
}

export interface KundenKontakte {
  KundenKontaktID: number;
  BaseID: number;
  KundenID: number;
  KundenKontaktArtID: number;
  Hauptansprechpartner: boolean;
  Info: string;
}

export interface KundenKontakteArten {
  KundenKontaktArtID: number;
  Bezeichnung: string;
  Gruppe: string;
  Sortierung: number;
}

export interface KundenLeistungArten {
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
}

export interface KundenLeistungen {
  KundenLeistungID: number;
  KundenID: number;
  KundenLeistungArtID: number;
}

export interface KundenLeistungenBescheide {
  KundenLeistungenBescheidID: number;
  KundenKontaktID: number;
  KundenLeistungID: number;
  StatusCode: string;
  Von: string;
  Bis: string;
  Stunden: number;
  StundenArt: string;
  Geschaeftszahl: string;
  Selbstkostenbefreiung: boolean;
  BeantragtAm: string;
  Ergaenzungsbescheid: boolean;
  ErgaenzungsbescheidInfo: string;
  Ablaufdatum: string;
  Info: string;
}

export interface KundenLeistungenBescheideKontingente {
  KundenLeistungenBescheideKontingentID: number;
  KundenLeistungenBescheidID: number;
  KontingentVon: string;
  KontingentBis: string;
  Anspruch: number;
  Verbrauch: number;
  Rest: number;
}

export interface KundenLeistungenBescheideStatus {
  StatusCode: string;
  Bezeichnung: string;
  Sortierung: number;
}

export interface KundenLeistungenBetreuer {
  KundenLeistungenBetreuerID: number;
  BaseID: number;
  KundenLeistungenBetreuerArtID: number;
  KundenLeistungID: number;
  Info: string;
}

export interface KundenLeistungenBetreuerArten {
  KundenLeistungenBetreuerArtID: number;
  Bezeichnung: string;
  Sortierung: number;
}

export interface KundenStatus {
  KundenStatusID: number;
  Status: string;
}

export interface Mitarbeiter {
  MitarbeiterID: number;
  BaseID: number;
  MitarbeiterArtID: number;
  MitarbeiterStatusID: number;
  ArbeitsrechtEintritt: string;
  ArbeitsrechtAustritt: string;
  LetzterEintritt: string;
  LetzterAustritt: string;
  Notfallkontakt: string;
  NotfallkontaktTelefon: string;
  Info: string;
  InfoGF: string;
}

export interface MitarbeiterArten {
  MitarbeiterArtID: number;
  MitarbeiterArt: string;
  Sortierung: number;
}

export interface MitarbeiterFortbildungen {
  MitarbeiterFortbildungID: number;
  DokumentID: number;
  MitarbeiterID: number;
  FortbildungArtID: number;
  Von: string;
  Bis: string;
  Veranstalter: string;
  Kosten: number;
  Info: string;
}

export interface MitarbeiterFortbildungenArten {
  FortbildungArtID: number;
  Titel: string;
  Sortierung: number;
}

export interface MitarbeiterInfo {
  MitarbeiterInfoID: number;
  MitarbeiterID: number;
  InfoDatum: string;
  InfoTitel: string;
  InfoText: string;
}

export interface MitarbeiterKundenbudget {
  MitarbeiterKundenbudgetID: number;
  MitarbeiterID: number;
  KundenbudgetKategorieID: number;
  AusgabeAm: string;
  AusgabeText: string;
  AusgabeBetrag: number;
  Info: string;
}

export interface MitarbeiterKundenbudgetKategorien {
  KundenbudgetKategorieID: number;
  Titel: string;
  Sortierung: number;
}

export interface MitarbeiterStatus {
  MitarbeiterStatusID: number;
  Status: string;
  Sortierung: number;
}

export interface MitarbeiterTaetigkeiten {
  MitarbeiterTaetigkeitenID: number;
  MitarbeiterID: number;
  MitarbeiterTaetigkeitenArtID: number;
}

export interface MitarbeiterTaetigkeitenArten {
  MitarbeiterTaetigkeitenArtID: number;
  TaetigkeitArt: string;
  LeistungSchluessel: string;
  Sortierung: number;
}

export interface MitarbeiterUrlaub {
  MitarbeiterUrlaubID: number;
  MitarbeiterID: number;
  Jahr: number;
  AnspruchJahrTage: number;
  AnspruchJahrWochen: number;
  RestVorjahr: number;
  AnspruchJahr: number;
  AnspruchGesamt: number;
  Verbraucht: number;
  Geplant: number;
  RestJahr: number;
  Info: string;
}

export interface MitarbeiterUrlaubDetail {
  MitarbeiterUrlaubDetailsID: number;
  MitarbeiterUrlaubID: number;
  Art: string;
  Von: string;
  Bis: string;
  Tage: number;
  StundenDetail: number;
  StundenNormalarbeitszeit: number;
  Wochentage: number;
  Info: string;
}

export interface MitarbeiterUrlaubKumuliertAnspruch {
  MitarbeiterUrlaubKumuliertAnspruchID: number;
  MitarbeiterID: number;
  Jahre: number;
  Art: string;
  AnspruchTage: number;
  AnspruchWochen: number;
  AnspruchBerechnetAb: string;
  AnspruchAb: string;
  AnspruchJahrVon: number;
  AnspruchJahrBis: number;
}

export interface MitarbeiterUrlaubKumuliertDienstzeiten {
  MitarbeiterUrlaubKumuliertDienstzeitenID: number;
  MitarbeiterID: number;
  Sortierung: number;
  Art: string;
  DienstzeitCode: string;
  DienstzeitAnrechnungInfo: string;
  DienstzeitBerechnet: number;
  DienstzeitAnrechnung: number;
}

export interface MitarbeiterVerlaufDienstzeiten {
  MitarbeiterVerlaufDienstzeitenID: number;
  MitarbeiterID: number;
  MitarbeiterVerlaufDienstzeitenArtID: number;
  Von: string;
  Bis: string;
  AnzahlTage: number;
  AnzahlMonate: number;
  AnzahlJahre: number;
  AnzahlJahreKomma: number;
  AnzahlBisLeer: number;
  AnzahlText: string;
  AnrechnungGehalt: boolean;
  AnrechnungUrlaub: boolean;
  Sortierung: number;
  Info: string;
}

export interface MitarbeiterVerlaufDienstzeitenArten {
  MitarbeiterVerlaufDienstzeitenArtID: number;
  Status: string;
  DienstzeitRechnen: boolean;
  DienstzeitGruppe: string;
  Referenz_MitarbeiterStatusID: number;
  Sortierung: number;
}

export interface MitarbeiterVerlaufGehalt {
  MitarbeiterVerlaufGehaltID: number;
  MitarbeiterID: number;
  Von: string;
  Bis: string;
  Verwendungsgruppe: number;
  Gehaltsstufe: number;
  Info: string;
}

export interface MitarbeiterVerlaufNormalarbeitszeit {
  MitarbeiterVerlaufNormalarbeitszeitID: number;
  MitarbeiterID: number;
  Von: string;
  Bis: string;
  Stunden: number;
  Wochentage: number;
  Info: string;
}

export interface Mitteilungen {
  MitteilungID: number;
  BaseID: number;
  DokumentID: number;
  Am: string;
  Titel: string;
  Beschreibung: string;
}

export interface MitteilungenVerteiler {
  MitteilungVerteilerID: number;
  MitteilungID: number;
  BaseID: number;
  Gelesen: boolean;
  GelesenAm: string;
  Kommentar: string;
}

export interface Module {
  ModulID: number;
  ModulName: string;
  Gruppe: string;
  Beschreibung: string;
  ActionLabel: string;
  ActionIcon: string;
  ActionLink: string;
  ActionTask: string;
  UserRole: string;
  ItemBadge: number;
  SubActions: string;
  VerwendenFuer: string;
  Sortierung: number;
  ImDashboard: boolean;
  ImDashboardSortierung: number;
  ImLeftMenue: boolean;
  ImLeftMenueSortierung: number;
}

export interface Protokoll {
  ProtokollID: number;
  BaseID: number;
  ErstelltAm: string;
  Art: string;
  Bereich: string;
  Titel: string;
  Beschreibung: string;
  ManagementZeigen: number;
  LinkID: number;
  Gelesen: boolean;
  GelesenAm: string;
}

export interface RegelnAbwesenheiten {
  RegelnAbwesenheitenID: number;
  RegelBezeichnung: string;
  RegelWert: number;
  RegelInfo: string;
  Beschreibung: string;
}

export interface TextbausteineHtml {
  TextbausteinID: number;
  Code: string;
  Titel: string;
  Inhalt: string;
  Sortierung: number;
}

export interface Versionskontrolle {
  VersionskontrolleID: number;
  ErstelltAm: string;
  Versionsnummer: string;
  Beschreibung: string;
}

export interface VwAbrechnungBasisReststunden {
  AbrechnungBasisID: number;
  Art: string;
  Jahr: number;
  Monat: number;
  MonatText: string;
  Gesperrt: boolean;
  Info: string;
}

export interface VwAbrechnungKundenReststunden {
  AbrechnungKundenReststundenID: number;
  AbrechnungBasisID: number;
  KundenID: number;
  BaseID: number;
  NameGesamt: string;
  KundenLeistungID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  KundenLeistungArtID: number;
  KundenLeistungenBescheidID: number;
  Von: string;
  Bis: string;
  Stunden: number;
  StundenArt: string;
  Selbstkostenbefreiung: boolean;
  KundenLeistungenBescheideKontingentID: number;
  KontingentVon: string;
  KontingentBis: string;
  Anspruch: number;
  Reststunden: number;
  NichtAbgerechnet: number;
  Offen: number;
  Info: string;
}

export interface VwAufgaben {
  AufgabeID: number;
  BaseID: number;
  Ersteller: string;
  ZustaendigBaseID: number;
  Zustaendig: string;
  Am: string;
  Titel: string;
  Beschreibung: string;
  FaelligBis: string;
  Erledigt: string;
  ErledigtAm: string;
  Info: string;
}

export interface VwAufgabenOffen {
  ZustaendigBaseID: number;
  AufgabenOffen: number;
}

export interface VwBase {
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwBaseBenutzer {
  BenutzerID: number;
  Benutzername: string;
  Initialen: string;
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwBaseEreignisse {
  EreignisID: number;
  BaseID: number;
  Start: string;
  StartText: string;
  Zeit: string;
  ZeitText: string;
  Titel: string;
}

export interface VwBaseKontakte {
  MitarbeiterID: number;
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwBaseKunden {
  KundenID: number;
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwBaseMitarbeiter {
  MitarbeiterID: number;
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwBaseStatistik {
  AnzahlBase: number;
  AnzahlKunden: number;
  AnzahlMitarbeiter: number;
  AnzahlBenutzer: number;
}

export interface VwBaseSuchen {
  BaseID: number;
  NameGesamt: string;
}

export interface VwBaseUndKunden {
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  AnredeID: number;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  Info: string;
  KundenID: number;
  KundenStatusID: number;
  Betreuungsbeginn: string;
  Vorbemerkungen: string;
  KundenInfo: string;
}

export interface VwBaseVerweise {
  Ebene: string;
  BaseID: number;
  KundenID: number;
  MitarbeiterID: number;
  BenutzerID: number;
}

export interface VwBenutzer {
  BenutzerID: number;
  BaseID: number;
  BenutzerRolleID: number;
  BenutzerRolle: string;
  Benutzername: string;
  Kennwort: string;
  Initialen: string;
  Sperren: string;
  Angemeldet: string;
  Abgemeldet: string;
  BenutzerInfo: string;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  AnredeID: number;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  Info: string;
}

export interface VwBenutzerAnu {
  Id: string;
  AccessFailedCount: number;
  ConcurrencyStamp: string;
  Email: string;
  EmailConfirmed: boolean;
  LockoutEnabled: boolean;
  LockoutEnd: string;
  NormalizedEmail: string;
  NormalizedUserName: string;
  PasswordHash: string;
  PhoneNumber: string;
  PhoneNumberConfirmed: boolean;
  SecurityStamp: string;
  TwoFactorEnabled: boolean;
  UserName: string;
}

export interface VwBenutzerAuswahlNeue {
  BaseID: number;
  NameGesamt: string;
}

export interface VwBenutzerModule {
  BenutzerID: number;
  BaseID: number;
  ModulName: string;
  ActionLabel: string;
  ActionLabelMitAbstandLinks: string;
  ActionIcon: string;
  ActionLink: string;
  ActionTask: string;
  UserRole: string;
  ItemBadge: string;
  SubActions: string;
}

export interface VwBenutzerSuchen {
  BenutzerID: number;
  BaseID: number;
  NameGesamt: string;
}

export interface VwDashboardTermineGeplant {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  KundenID: number;
  Jahr: string;
  Am: string;
  Von: string;
  Bis: string;
  Minuten: number;
  Stunden: string;
  Titel: string;
}

export interface VwDienstplanEreignisse {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  Start: string;
  Ende: string;
  KundenID: number;
  Zeit: string;
  Titel: string;
}

export interface VwDienstplanKundenLeistungen {
  KundenID: number;
  BaseID: number;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  LeistungArt: string;
  LeistungSchluessel: string;
  Anspruch: number;
  Verbrauch: number;
  Rest: number;
  KundenbesucheErledigt: number;
  KundenbesucheGeplant: number;
  KundenbesucheOffen: number;
}

export interface VwDokumente {
  DokumentID: number;
  DokumenteKategorieID: number;
  Kategorie: string;
  Titel: string;
  Beschreibung: string;
  DokumentURL: string;
}

export interface VwDokumenteAnzahl {
  Kategorie: string;
  AnzahlDokumente: number;
}

export interface VwEreignisse {
  id: number;
  BaseID: number;
  start: string;
  end: string;
  allDay: number;
  EreignisArtCode: string;
  title: string;
  title2: string;
  color: string;
  textColor: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  Beschreibung: string;
  BeantragtAm: string;
  GenehmigtAm: string;
  AbgelehntAm: string;
  Begruendung: string;
}

export interface VwEreignisseAlle {
  EreignisID: number;
  EreignisArtCode: string;
  EreignisSonderurlaubArtID: number;
  EreignisBezeichnung: string;
  BaseID: number;
  BesitzerNameGesamt: string;
  BesitzerNameVorNach: string;
  BesitzerNameKuerzel: string;
  KundenID: number;
  KundeBaseID: number;
  KundeNameGesamt: string;
  KundeNameVorNach: string;
  KundeNameKuerzel: string;
  KundenLeistungArtID: number;
  KundeLeistungArt: string;
  KundeLeistungSchluessel: string;
  Start: string;
  Ende: string;
  end: string;
  endKorrigiert: string;
  GanzerTag: number;
  allDay: number;
  Titel: string;
  title: string;
  titleModulDashboard: string;
  titleModulDienstplan: string;
  titleModulMitarbeiter: string;
  titleModulKunden: string;
  titleModulManagement: string;
  Beschreibung: string;
  description: string;
  StundenUrlaub: number;
  BeantragtAm: string;
  GenehmigtAm: string;
  AbgelehntAm: string;
  Begruendung: string;
  StatusAntrag: string;
  Verwendung: string;
  Gesperrt: number;
  color: string;
  textColor: string;
  EreignisseTeilnehmerID: number;
  TeilnehmerBaseID: number;
  TeilnehmerNameGesamt: string;
  TeilnehmerNameVorNach: string;
  TeilnehmerNameKuerzel: string;
  TeilnehmerStatusCode: string;
  TeilnehmerStatusCodeTitel: string;
}

export interface VwEreignisseAntraege {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  Mitarbeiter: string;
  EreignisText: string;
  SonderurlaubArt: string;
  Titel: string;
  Start: string;
  StartJahr: number;
  Ende: string;
  Tage: number;
  StundenUrlaub: number;
  BeantragtAm: string;
  GenehmigtAm: string;
  AbgelehntAm: string;
  Begruendung: string;
  StatusAntrag: string;
  Bearbeiter: string;
}

export interface VwEreignisseAntraegeUrlaubVerbraucht {
  BaseID: number;
  EreignisArtCode: string;
  Tage: number;
}

export interface VwEreignisseArtenDienstplan {
  EreignisArtCode: string;
  Bezeichnung: string;
  Kurzzeichen: string;
}

export interface VwEreignisseArtenManagement {
  EreignisArtCode: string;
  Bezeichnung: string;
  Kurzzeichen: string;
}

export interface VwEreignisseArtenMitTextAlle {
  EreignisArtCode: string;
  BisEreignisArtCode: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  TermineDienstplan: number;
  TermineManagement: number;
  SortierungTermineDienstplan: number;
  SortierungTermineManagement: number;
}

export interface VwEreignisseArtenModule {
  NameModul: string;
  EreignisArtCode: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  SortierungTermineDienstplan: number;
}

export interface VwEreignisseGesamt {
  id: number;
  EreignisArtCode: string;
  title: string;
  description: string;
  allDay: number;
  start: string;
  end: string;
  BeantragtAm: string;
  GenehmigtAm: string;
  AbgelehntAm: string;
  Begruendung: string;
  BaseID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  Verwendung: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  VerwendenFuer: string;
  Sortierung: number;
  color: string;
  textColor: string;
  NameGesamt: string;
  EreignisseTeilnehmerID: number;
  EreignisseTeilnehmerBaseID: number;
  StatusCode: string;
  Nachricht: string;
}

export interface VwEreignisseKundenBesuche {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  Start: string;
  Ende: string;
  Minuten: number;
  Titel: string;
  TitelDatumZeit: string;
  Beschreibung: string;
  Bemerkungen: string;
  GefuehlSituation01: number;
  GefuehlSituation02: number;
  GefuehlSituation03: number;
  GefuehlSituation04: number;
  GefuehlSituation05: number;
  GefuehlSituation06: number;
  KundenFahrtMinuten: number;
  KundenFahrtKM: number;
  BetreuerAnAbReiseMinuten: number;
  BetreuerAnAbReiseKM: number;
  BesuchAm: string;
  BesuchVon: string;
  BesuchBis: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
}

export interface VwEreignisseKundenbesucheHeute {
  BaseID: number;
  Start: string;
  Ende: string;
  Titel: string;
  TitelAnzeige: string;
}

export interface VwEreignisseKundenbesucheHeuteOffen {
  BaseID: number;
  EreignisseKundenbesucheOffen: number;
}

export interface VwEreignisseMitTeilnehmer {
  id: number;
  BaseID: number;
  start: string;
  end: string;
  allDay: number;
  EreignisArtCode: string;
  title: string;
  title2: string;
  color: string;
  textColor: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  Beschreibung: string;
  BeantragtAm: string;
  GenehmigtAm: string;
  AbgelehntAm: string;
  Begruendung: string;
  StatusCode: string;
  StatusTitel: string;
  Nachricht: string;
}

export interface VwEreignisseModulDashboard {
  id: number;
  EreignisArtCode: string;
  title: string;
  description: string;
  allDay: number;
  start: string;
  end: string;
  BaseID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  Verwendung: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  VerwendenFuer: string;
  Sortierung: number;
  color: string;
  textColor: string;
  Name: string;
  MitarbeiterID: number;
}

export interface VwEreignisseModulDashboardMobile {
  id: number;
  EreignisArtCode: string;
  title: string;
  description: string;
  allDay: number;
  start: string;
  startJahr: number;
  startQuartal: number;
  startMonat: number;
  startWoche: number;
  startTag: number;
  startStunde: number;
  startMinute: number;
  startTagKurz: string;
  startTagTitel: string;
  startMonatKurz: string;
  startMonatTitel: string;
  startMonatTitelJahr: string;
  startJahrMonat: number;
  startZeit: string;
  startZeitspanne: string;
  end: string;
  BaseID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  Verwendung: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  VerwendenFuer: string;
  Sortierung: number;
  color: string;
  textColor: string;
  Name: string;
  MitarbeiterID: number;
}

export interface VwEreignisseModulDienstplanListe {
  EreignisID: number;
  EreignisArtCode: string;
  EreignisArtTitel: string;
  BaseID: number;
  BesitzerNameGesamt: string;
  KundenID: number;
  KundeNameGesamt: string;
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  VonDatum: string;
  VonZeit: string;
  BisDatum: string;
  BisZeit: string;
  Minuten: number;
  Stunden: string;
  Tage: number;
  GanzerTag: number;
  Titel: string;
  Beschreibung: string;
  BeantragtAm: string;
  GenehmigtAm: string;
  AbgelehntAm: string;
  Begruendung: string;
  StatusAntrag: string;
  Gesperrt: number;
}

export interface VwEreignisseModulDienstplanMobile {
  id: number;
  EreignisArtCode: string;
  title: string;
  description: string;
  allDay: number;
  start: string;
  startJahr: number;
  startQuartal: number;
  startMonat: number;
  startWoche: number;
  startTag: number;
  startStunde: number;
  startMinute: number;
  startTagKurz: string;
  startTagTitel: string;
  startMonatKurz: string;
  startMonatTitel: string;
  startMonatTitelJahr: string;
  startJahrMonat: number;
  startZeit: string;
  startZeitspanne: string;
  startTitelDientplanWoche: string;
  end: string;
  BaseID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  Verwendung: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  VerwendenFuer: string;
  Sortierung: number;
  color: string;
  textColor: string;
  Name: string;
  MitarbeiterID: number;
}

export interface VwEreignisseModulKunden {
  id: number;
  EreignisArtCode: string;
  title: string;
  description: string;
  allDay: number;
  start: string;
  end: string;
  KundenID: number;
  KundenLeistungArtID: number;
  Verwendung: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  VerwendenFuer: string;
  Sortierung: number;
  color: string;
  textColor: string;
  Name: string;
}

export interface VwEreignisseModulManagement {
  id: number;
  EreignisArtCode: string;
  title: string;
  description: string;
  allDay: number;
  start: string;
  end: string;
  BaseID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  Verwendung: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  VerwendenFuer: string;
  Sortierung: number;
  color: string;
  textColor: string;
  Name: string;
  MitarbeiterID: number;
}

export interface VwEreignisseModulMitarbeiter {
  id: number;
  EreignisArtCode: string;
  title: string;
  description: string;
  allDay: number;
  start: string;
  end: string;
  BaseID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  Verwendung: string;
  Gruppe: string;
  Ebene: string;
  Bezeichnung: string;
  Kurzzeichen: string;
  VerwendenFuer: string;
  Sortierung: number;
  color: string;
  textColor: string;
  Name: string;
  MitarbeiterID: number;
}

export interface VwEreignisseTeilnehmerListe {
  EreignisseTeilnehmerID: number;
  EreignisID: number;
  BaseID: number;
  StatusCode: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
}

export interface VwFeedback {
  FeedbackID: number;
  BaseID: number;
  ErstelltAm: string;
  Modul: string;
  Titel: string;
  Beschreibung: string;
  Erledigt: string;
  ErledigtAm: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
}

export interface VwGeburtstage {
  BaseID: number;
  Name1: string;
  Name2: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Telefon1: string;
  EMail1: string;
  NameNV: string;
  NameVN: string;
  BildURL: string;
  Geburtsdatum: string;
  Jahr: number;
  Monat: number;
  Tag: number;
  Art: string;
  GeburtstagKurz: string;
  GeburtstagAlter: number;
  GeburtstagAlterGenau: number;
  Sortierung: number;
}

export interface VwKunden {
  KundenID: number;
  BaseID: number;
  KundenStatusID: number;
  Betreuungsbeginn: string;
  Vorbemerkungen: string;
  Info: string;
  Status: string;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwKundenAuswahlNeu {
  BaseID: number;
  NameGesamt: string;
}

export interface VwKundenBase {
  KundenID: number;
  BaseID: number;
  KundenStatusID: number;
  Betreuungsbeginn: string;
  Vorbemerkungen: string;
  Info: string;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  AnredeID: number;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwKundenBescheideKontingente {
  KundenLeistungenBescheideKontingentID: number;
  KundenLeistungenBescheidID: number;
  KontingentVon: string;
  KontingentBis: string;
  Anspruch: number;
  Verbrauch: number;
  Rest: number;
  Kunde: string;
  LeistungArt: string;
  LeistungSchluessel: string;
  Von: string;
  Bis: string;
  Stunden: number;
  StundenArt: string;
  Geschaeftszahl: string;
  Selbstkostenbefreiung: boolean;
  BeantragtAm: string;
}

export interface VwKundenBetreuer {
  KundenLeistungenBetreuerID: number;
  KundenLeistungID: number;
  BaseID: number;
  KundenLeistungenBetreuerArtID: number;
  Info: string;
  NameGesamt: string;
  Betreuungsart: string;
  Sortierung: number;
  KundenID: number;
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
}

export interface VwKundenEreignisse {
  EreignisID: number;
  KundenID: number;
  Start: string;
  Ende: string;
  Zeit: string;
  ZeitSpanne: string;
  Minuten: number;
  Stunden: string;
  Tage: number;
  Titel: string;
}

export interface VwKundenGeburtstage {
  Art: string;
  ArtKurz: string;
  BetreuerBaseID: number;
  TabelleID: number;
  BaseID: number;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  BildURL: string;
  Geburtsdatum: string;
  GeborenTag: string;
  GeborenMonat: string;
  GeborenJahr: string;
  GeborenDiesesJahr: string;
  WochentagKurz: string;
  WochentagLang: string;
  GeborenKurz: string;
  GeborenLang: string;
  GeborenAlter: number;
  GeborenStatus: string;
  GeborenZeigen: string;
  GeborenZeigenZeichen: string;
}

export interface VwKundenHauptbetreuer {
  KundenLeistungenBetreuerID: number;
  KundenLeistungID: number;
  KundenID: number;
  BaseID: number;
  NameGesamt: string;
  LeistungArt: string;
  LeistungSchluessel: string;
}

export interface VwKundenKontingente {
  KundenLeistungenBescheideKontingentID: number;
  KundenLeistungenBescheidID: number;
  KontingentVon: string;
  KontingentBis: string;
  Anspruch: number;
  Verbrauch: number;
  Rest: number;
  KontingentTitel: string;
  KundenLeistungID: number;
  StatusCode: string;
}

export interface VwKundenLeistungen {
  KundenLeistungID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  LeistungArtTitel: string;
  LeistungTitel: string;
  LeistungMinuten: number;
  KontingentTitel: string;
  KontingentAnpruch: number;
  KontingentVerbrauch: number;
  KontingentRest: number;
}

export interface VwKundenLeistungenBescheide {
  KundenLeistungID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  KundenLeistungenBescheidID: number;
  StatusCode: string;
  StatusTitel: string;
  StatusSortierung: number;
  Von: string;
  Bis: string;
  BescheidTitel: string;
  Stunden: string;
  StundenArt: string;
  LeistungTitel: string;
  Geschaeftszahl: string;
  Selbstkostenbefreiung: string;
  BeantragtAm: string;
  KundenKontaktID: string;
  Ergaenzungsbescheid: string;
  ErgaenzungsbescheidInfo: string;
  Ablaufdatum: string;
  Info: string;
}

export interface VwKundenLeistungenBetreuer {
  KundenLeistungenBetreuerID: number;
  KundenLeistungID: number;
  BaseID: number;
  KundenLeistungenBetreuerArtID: number;
  NameGesamt: string;
  Betreuungsart: string;
  Sortierung: number;
}

export interface VwKundenLeistungenKontingente {
  KundenLeistungID: number;
  KundenID: number;
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  KundenLeistungenBescheideKontingentID: number;
  KontingentVon: string;
  KontingentBis: string;
  KontingentTitel: string;
  Anspruch: number;
  Verbrauch: number;
  Rest: number;
  KontingentTitelStunden: string;
  KontingentTitelBisStunden: string;
  KontingentTitelBisStundenKurz: string;
  KontingentTitelRest: string;
  StatusCode: string;
  StatusTitel: string;
  StatusSortierung: number;
}

export interface VwKundenProBetreuer {
  KundenID: number;
  BaseID: number;
  BaseIDBetreuer: number;
  KundenStatusID: number;
  Betreuungsbeginn: string;
  Vorbemerkungen: string;
  Info: string;
  Status: string;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwKundenSuchen {
  KundenID: number;
  BaseID: number;
  NameGesamt: string;
  NameVorNach: string;
  Ort: string;
}

export interface VwKundenTermineErledigt {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  KundenID: number;
  Jahr: string;
  Am: string;
  Von: string;
  Bis: string;
  Minuten: number;
  Stunden: string;
  LeistungArt: string;
  LeistungSchluessel: string;
  Betreuer: string;
}

export interface VwKundenTermineGeplant {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  KundenID: number;
  Jahr: string;
  Am: string;
  Von: string;
  Bis: string;
  Minuten: number;
  Stunden: string;
  LeistungArt: string;
  LeistungSchluessel: string;
  Betreuer: string;
}

export interface VwKundenTermineZusammenfassung {
  KundenID: number;
  Jahr: string;
  AnzahlTermine: number;
  SummeStunden: string;
}

export interface VwKundenUndBetreuer {
  KundenID: number;
  BaseID: number;
  KundenStatusID: number;
  BetreuerBaseID: number;
  BenutzerRolleID: number;
  Betreuungsbeginn: string;
  Vorbemerkungen: string;
  Info: string;
  Status: string;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwKundenUndBetreuerAuswahl {
  KundenID: number;
  KundeBaseID: number;
  KundeNameGesamt: string;
  KundeNameVorNach: string;
  KundeNameKuerzel: string;
  BetreuerBaseID: number;
  BetreuerNameGesamt: string;
  BetreuerNameVorNach: string;
  BetreuerNameKuerzel: string;
}

export interface VwKundenUndBetreuerUndLeistungenAuswahl {
  KundenID: number;
  KundeBaseID: number;
  KundeNameGesamt: string;
  BetreuerBaseID: number;
  BetreuerNameGesamt: string;
  KundenLeistungArtID: number;
  LeistungArt: string;
  LeistungSchluessel: string;
  LeistungArtUndSchluessel: string;
}

export interface VwMitarbeiter {
  MitarbeiterID: number;
  BaseID: number;
  MitarbeiterArtID: number;
  MitarbeiterArt: string;
  Status: string;
  ArbeitsrechtEintritt: string;
  ArbeitsrechtAustritt: string;
  LetzterEintritt: string;
  LetzterAustritt: string;
  Notfallkontakt: string;
  NotfallkontaktTelefon: string;
  Info: string;
  InfoGF: string;
  Name1: string;
  Name2: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwMitarbeiterArtenMitTextAlle {
  MitarbeiterArtID: number;
  BisMitarbeiterArtID: number;
  MitarbeiterArt: string;
  Sortierung: number;
}

export interface VwMitarbeiterAuswahlDashboard {
  MitarbeiterID: number;
  ZustaendigBaseID: number;
  NameGesamt: string;
}

export interface VwMitarbeiterAuswahlNeu {
  BaseID: number;
  NameGesamt: string;
}

export interface VwMitarbeiterAuswahlTermin {
  MitarbeiterID: number;
  BaseID: number;
  NameGesamt: string;
  MitarbeiterStatusID: number;
}

export interface VwMitarbeiterEreignisse {
  EreignisID: number;
  MitarbeiterID: number;
  Start: string;
  Ende: string;
  Zeit: string;
  ZeitSpanne: string;
  Titel: string;
  Minuten: number;
  Stunden: string;
  Tage: number;
}

export interface VwMitarbeiterFilterAuswahl {
  ID: number;
  Titel: string;
  Gruppe: string;
  SortierungGruppe: number;
  Sortierung: number;
}

export interface VwMitarbeiterFilterListe {
  MitarbeiterID: number;
  BaseID: number;
  MitarbeiterArtID: number;
  MitarbeiterArt: string;
  MitarbeiterStatusID: number;
  Status: string;
  MitarbeiterTaetigkeitenArtID: number;
  ArbeitsrechtEintritt: string;
  LetzterEintritt: string;
  Notfallkontakt: string;
  NotfallkontaktTelefon: string;
  Info: string;
  InfoGF: string;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  Anrede: string;
  TitelVorne: string;
  TitelHinten: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  Geburtsdatum: string;
  Versicherungsnummer: string;
  Staatsangehoerigkeit: string;
  Telefon1: string;
  Telefon2: string;
  EMail1: string;
  EMail2: string;
  Webseite: string;
  BildURL: string;
  BaseInfo: string;
}

export interface VwMitarbeiterFortbildungenSummenJahr {
  MitarbeiterID: number;
  Jahr: number;
  SummeKosten: number;
}

export interface VwMitarbeiterFortbildungenSummenJahrArten {
  MitarbeiterID: number;
  Jahr: number;
  Titel: string;
  Sortierung: number;
  SummeKosten: number;
}

export interface VwMitarbeiterFuerAuswahlMitTextAlle {
  MitarbeiterID: number;
  BaseID: number;
  MitarbeiterArtID: number;
  MitarbeiterStatusID: number;
  MitarbeiterTaetigkeitenArtID: number;
  NameGesamt: string;
  NameKuerzel: string;
}

export interface VwMitarbeiterGeburtstage {
  Art: string;
  ArtKurz: string;
  BetreuerBaseID: number;
  TabelleID: number;
  BaseID: number;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  BildURL: string;
  Geburtsdatum: string;
  GeborenTag: string;
  GeborenMonat: string;
  GeborenJahr: string;
  GeborenDiesesJahr: string;
  WochentagKurz: string;
  WochentagLang: string;
  GeborenKurz: string;
  GeborenLang: string;
  GeborenAlter: number;
  GeborenStatus: string;
  GeborenZeigen: string;
  GeborenZeigenZeichen: string;
}

export interface VwMitarbeiterKundenAnzahlAa {
  MitarbeiterID: number;
  BaseID: number;
  KundenID: number;
}

export interface VwMitarbeiterKundenAnzahlBb {
  MitarbeiterID: number;
  BaseID: number;
  AnzahlvonKundenID: number;
}

export interface VwMitarbeiterKundenLeistungen {
  MitarbeiterID: number;
  MitarbeiterBaseID: number;
  KundenID: number;
  KundenBaseID: number;
  NameGesamt: string;
  LeistungArt: string;
  LeistungSchluessel: string;
  Betreuungsart: string;
}

export interface VwMitarbeiterKundenbudgetSummenJahr {
  MitarbeiterID: number;
  Jahr: number;
  SummeBetrag: number;
}

export interface VwMitarbeiterKundenbudgetSummenJahrKategorien {
  MitarbeiterID: number;
  Jahr: number;
  Titel: string;
  Sortierung: number;
  SummeBetrag: number;
}

export interface VwMitarbeiterMitTextAlle {
  MitarbeiterID: number;
  BaseID: number;
  BisBaseID: number;
  MitarbeiterArtID: number;
  MitarbeiterStatusID: number;
  NameGesamt: string;
  NameKuerzel: string;
}

export interface VwMitarbeiterSonderurlaubEinfach {
  BaseID: number;
  Jahr: number;
  Verbrauch: number;
  Plan: number;
}

export interface VwMitarbeiterStatusMitTextAlle {
  MitarbeiterStatusID: number;
  BisMitarbeiterStatusID: number;
  Status: string;
  Sortierung: number;
}

export interface VwMitarbeiterSuchen {
  MitarbeiterID: number;
  BaseID: number;
  MitarbeiterArtID: number;
  MitarbeiterStatusID: number;
  NameGesamt: string;
  NameVorNach: string;
  NameKuerzel: string;
  Strasse: string;
  PLZ: string;
  Ort: string;
  BildURL: string;
}

export interface VwMitarbeiterTaetigkeiten {
  MitarbeiterID: number;
  BaseID: number;
  MitarbeiterTaetigkeitenArtID: number;
  TaetigkeitArt: string;
  LeistungSchluessel: string;
}

export interface VwMitarbeiterTaetigkeitenMitTextAlle {
  MitarbeiterTaetigkeitenArtID: number;
  BisMitarbeiterTaetigkeitenArtID: number;
  TaetigkeitArt: string;
}

export interface VwMitarbeiterTermineErledigt {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  KundenID: number;
  MitarbeiterID: number;
  Jahr: string;
  Am: string;
  Von: string;
  Bis: string;
  Minuten: number;
  Stunden: string;
  Mitarbeiter: string;
}

export interface VwMitarbeiterTermineGeplant {
  EreignisID: number;
  EreignisArtCode: string;
  BaseID: number;
  KundenID: number;
  MitarbeiterID: number;
  Jahr: string;
  Am: string;
  Von: string;
  Bis: string;
  Minuten: number;
  Stunden: string;
  Mitarbeiter: string;
}

export interface VwMitarbeiterTermineZusammenfassung {
  BaseID: number;
  MitarbeiterID: number;
  Jahr: string;
  AnzahlTermine: number;
  SummeStunden: string;
}

export interface VwMitarbeiterUrlaub {
  MitarbeiterUrlaubID: number;
  MitarbeiterID: number;
  BaseID: number;
  Art: string;
  Jahr: number;
  AnspruchJahrTage: number;
  RestVorjahr: number;
  AnspruchJahr: number;
  AnspruchGesamt: number;
  Verbraucht: number;
  Geplant: number;
  RestJahr: number;
  Info: string;
}

export interface VwMitarbeiterVerlaufDienstzeiten {
  MitarbeiterVerlaufDienstzeitenID: number;
  MitarbeiterVerlaufDienstzeitenArtID: number;
  MitarbeiterID: number;
  Von: string;
  Bis: string;
  Bis2: string;
  Info: string;
  AnzahlTage: number;
  AnzahlMonate: number;
  AnzahlJahre: number;
  BisIstNull: number;
  Status: string;
  DienstzeitRechnen: boolean;
  Referenz_MitarbeiterStatusID: number;
  Sortierung: number;
}

export interface VwMitteilungen {
  MitteilungID: number;
  BaseID: number;
  Ersteller: string;
  Am: string;
  Titel: string;
  Beschreibung: string;
  DokumentID: number;
  DokumentTitel: string;
  DokumentURL: string;
}

export interface VwMitteilungenOffen {
  BaseID: number;
  MitteilungenOffen: number;
}

export interface VwMitteilungenVerteiler {
  MitteilungVerteilerID: number;
  MitteilungID: number;
  BaseID: number;
  Gelesen: string;
  GelesenAm: string;
  NameGesamt: string;
}

export interface VwModuleAuswahlMitTextAlle {
  ModulID: number;
  ModulName: string;
  Sortierung: number;
}

export interface VwProtokollOffen {
  BaseID: number;
  ProtokollOffen: number;
}
