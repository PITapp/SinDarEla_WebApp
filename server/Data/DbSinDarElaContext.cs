using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using SinDarEla.Models.DbSinDarEla;

namespace SinDarEla.Data
{
    public partial class DbSinDarElaContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public DbSinDarElaContext(IHttpContextAccessor httpAccessor, DbContextOptions<DbSinDarElaContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public DbSinDarElaContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SinDarEla.Models.DbSinDarEla.AbrechnungKundenReststunden>()
                  .HasOne(i => i.Kunden)
                  .WithMany(i => i.AbrechnungKundenReststundens)
                  .HasForeignKey(i => i.KundenID)
                  .HasPrincipalKey(i => i.KundenID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.AbrechnungKundenReststunden>()
                  .HasOne(i => i.KundenLeistungArten)
                  .WithMany(i => i.AbrechnungKundenReststundens)
                  .HasForeignKey(i => i.KundenLeistungArtID)
                  .HasPrincipalKey(i => i.KundenLeistungArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Aufgaben>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Aufgabens)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Aufgaben>()
                  .HasOne(i => i.Base1)
                  .WithMany(i => i.Aufgabens1)
                  .HasForeignKey(i => i.ZustaendigBaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Base>()
                  .HasOne(i => i.BaseAnreden)
                  .WithMany(i => i.Bases)
                  .HasForeignKey(i => i.AnredeID)
                  .HasPrincipalKey(i => i.AnredeID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.BaseBanken>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.BaseBankens)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.BaseKontakte>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.BaseKontaktes)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.BaseKontakte>()
                  .HasOne(i => i.BaseAnreden)
                  .WithMany(i => i.BaseKontaktes)
                  .HasForeignKey(i => i.AnredeID)
                  .HasPrincipalKey(i => i.AnredeID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Benutzer>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Benutzers)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Benutzer>()
                  .HasOne(i => i.BenutzerRollen)
                  .WithMany(i => i.Benutzers)
                  .HasForeignKey(i => i.BenutzerRolleID)
                  .HasPrincipalKey(i => i.BenutzerRolleID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.BenutzerModule>()
                  .HasOne(i => i.Benutzer)
                  .WithMany(i => i.BenutzerModules)
                  .HasForeignKey(i => i.BenutzerID)
                  .HasPrincipalKey(i => i.BenutzerID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.BenutzerModule>()
                  .HasOne(i => i.Module)
                  .WithMany(i => i.BenutzerModules)
                  .HasForeignKey(i => i.ModulID)
                  .HasPrincipalKey(i => i.ModulID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.BenutzerProtokoll>()
                  .HasOne(i => i.Benutzer)
                  .WithMany(i => i.BenutzerProtokolls)
                  .HasForeignKey(i => i.BenutzerID)
                  .HasPrincipalKey(i => i.BenutzerID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Dokumente>()
                  .HasOne(i => i.DokumenteKategorien)
                  .WithMany(i => i.Dokumentes)
                  .HasForeignKey(i => i.DokumenteKategorieID)
                  .HasPrincipalKey(i => i.DokumenteKategorieID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Dokumente>()
                  .HasOne(i => i.Kunden)
                  .WithMany(i => i.Dokumentes)
                  .HasForeignKey(i => i.KundenID)
                  .HasPrincipalKey(i => i.KundenID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Dokumente>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.Dokumentes)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Ereignisses)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .HasOne(i => i.EreignisseArten)
                  .WithMany(i => i.Ereignisses)
                  .HasForeignKey(i => i.EreignisArtCode)
                  .HasPrincipalKey(i => i.EreignisArtCode);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .HasOne(i => i.EreignisseSonderurlaubArten)
                  .WithMany(i => i.Ereignisses)
                  .HasForeignKey(i => i.EreignisSonderurlaubArtID)
                  .HasPrincipalKey(i => i.EreignisSonderurlaubArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .HasOne(i => i.Kunden)
                  .WithMany(i => i.Ereignisses)
                  .HasForeignKey(i => i.KundenID)
                  .HasPrincipalKey(i => i.KundenID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .HasOne(i => i.KundenLeistungArten)
                  .WithMany(i => i.Ereignisses)
                  .HasForeignKey(i => i.KundenLeistungArtID)
                  .HasPrincipalKey(i => i.KundenLeistungArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseTeilnehmer>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.EreignisseTeilnehmers)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseTeilnehmer>()
                  .HasOne(i => i.Ereignisse)
                  .WithMany(i => i.EreignisseTeilnehmers)
                  .HasForeignKey(i => i.EreignisID)
                  .HasPrincipalKey(i => i.EreignisID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseTeilnehmer>()
                  .HasOne(i => i.EreignisseTeilnehmerStatus)
                  .WithMany(i => i.EreignisseTeilnehmers)
                  .HasForeignKey(i => i.StatusCode)
                  .HasPrincipalKey(i => i.StatusCode);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Feedback>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Feedbacks)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Kunden>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Kundens)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Kunden>()
                  .HasOne(i => i.KundenStatus)
                  .WithMany(i => i.Kundens)
                  .HasForeignKey(i => i.KundenStatusID)
                  .HasPrincipalKey(i => i.KundenStatusID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenInfo>()
                  .HasOne(i => i.Kunden)
                  .WithMany(i => i.KundenInfos)
                  .HasForeignKey(i => i.KundenID)
                  .HasPrincipalKey(i => i.KundenID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenKontakte>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.KundenKontaktes)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenKontakte>()
                  .HasOne(i => i.Kunden)
                  .WithMany(i => i.KundenKontaktes)
                  .HasForeignKey(i => i.KundenID)
                  .HasPrincipalKey(i => i.KundenID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenKontakte>()
                  .HasOne(i => i.KundenKontakteArten)
                  .WithMany(i => i.KundenKontaktes)
                  .HasForeignKey(i => i.KundenKontaktArtID)
                  .HasPrincipalKey(i => i.KundenKontaktArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungen>()
                  .HasOne(i => i.Kunden)
                  .WithMany(i => i.KundenLeistungens)
                  .HasForeignKey(i => i.KundenID)
                  .HasPrincipalKey(i => i.KundenID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungen>()
                  .HasOne(i => i.KundenLeistungArten)
                  .WithMany(i => i.KundenLeistungens)
                  .HasForeignKey(i => i.KundenLeistungArtID)
                  .HasPrincipalKey(i => i.KundenLeistungArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheide>()
                  .HasOne(i => i.KundenKontakte)
                  .WithMany(i => i.KundenLeistungenBescheides)
                  .HasForeignKey(i => i.KundenKontaktID)
                  .HasPrincipalKey(i => i.KundenKontaktID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheide>()
                  .HasOne(i => i.KundenLeistungen)
                  .WithMany(i => i.KundenLeistungenBescheides)
                  .HasForeignKey(i => i.KundenLeistungID)
                  .HasPrincipalKey(i => i.KundenLeistungID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheide>()
                  .HasOne(i => i.KundenLeistungenBescheideStatus)
                  .WithMany(i => i.KundenLeistungenBescheides)
                  .HasForeignKey(i => i.StatusCode)
                  .HasPrincipalKey(i => i.StatusCode);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheideKontingente>()
                  .HasOne(i => i.KundenLeistungenBescheide)
                  .WithMany(i => i.KundenLeistungenBescheideKontingentes)
                  .HasForeignKey(i => i.KundenLeistungenBescheidID)
                  .HasPrincipalKey(i => i.KundenLeistungenBescheidID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBetreuer>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.KundenLeistungenBetreuers)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBetreuer>()
                  .HasOne(i => i.KundenLeistungenBetreuerArten)
                  .WithMany(i => i.KundenLeistungenBetreuers)
                  .HasForeignKey(i => i.KundenLeistungenBetreuerArtID)
                  .HasPrincipalKey(i => i.KundenLeistungenBetreuerArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBetreuer>()
                  .HasOne(i => i.KundenLeistungen)
                  .WithMany(i => i.KundenLeistungenBetreuers)
                  .HasForeignKey(i => i.KundenLeistungID)
                  .HasPrincipalKey(i => i.KundenLeistungID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Mitarbeiter>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Mitarbeiters)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Mitarbeiter>()
                  .HasOne(i => i.MitarbeiterArten)
                  .WithMany(i => i.Mitarbeiters)
                  .HasForeignKey(i => i.MitarbeiterArtID)
                  .HasPrincipalKey(i => i.MitarbeiterArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Mitarbeiter>()
                  .HasOne(i => i.MitarbeiterStatus)
                  .WithMany(i => i.Mitarbeiters)
                  .HasForeignKey(i => i.MitarbeiterStatusID)
                  .HasPrincipalKey(i => i.MitarbeiterStatusID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterFortbildungen>()
                  .HasOne(i => i.Dokumente)
                  .WithMany(i => i.MitarbeiterFortbildungens)
                  .HasForeignKey(i => i.DokumentID)
                  .HasPrincipalKey(i => i.DokumentID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterFortbildungen>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterFortbildungens)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterFortbildungen>()
                  .HasOne(i => i.MitarbeiterFortbildungenArten)
                  .WithMany(i => i.MitarbeiterFortbildungens)
                  .HasForeignKey(i => i.FortbildungArtID)
                  .HasPrincipalKey(i => i.FortbildungArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterInfo>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterInfos)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterKundenbudget>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterKundenbudgets)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterKundenbudget>()
                  .HasOne(i => i.MitarbeiterKundenbudgetKategorien)
                  .WithMany(i => i.MitarbeiterKundenbudgets)
                  .HasForeignKey(i => i.KundenbudgetKategorieID)
                  .HasPrincipalKey(i => i.KundenbudgetKategorieID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterTaetigkeiten>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterTaetigkeitens)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterTaetigkeiten>()
                  .HasOne(i => i.MitarbeiterTaetigkeitenArten)
                  .WithMany(i => i.MitarbeiterTaetigkeitens)
                  .HasForeignKey(i => i.MitarbeiterTaetigkeitenArtID)
                  .HasPrincipalKey(i => i.MitarbeiterTaetigkeitenArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaub>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterUrlaubs)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubDetail>()
                  .HasOne(i => i.MitarbeiterUrlaub)
                  .WithMany(i => i.MitarbeiterUrlaubDetails)
                  .HasForeignKey(i => i.MitarbeiterUrlaubID)
                  .HasPrincipalKey(i => i.MitarbeiterUrlaubID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterUrlaubKumuliertAnspruches)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterUrlaubKumuliertDienstzeitens)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterVerlaufDienstzeitens)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>()
                  .HasOne(i => i.MitarbeiterVerlaufDienstzeitenArten)
                  .WithMany(i => i.MitarbeiterVerlaufDienstzeitens)
                  .HasForeignKey(i => i.MitarbeiterVerlaufDienstzeitenArtID)
                  .HasPrincipalKey(i => i.MitarbeiterVerlaufDienstzeitenArtID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufGehalt>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterVerlaufGehalts)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>()
                  .HasOne(i => i.Mitarbeiter)
                  .WithMany(i => i.MitarbeiterVerlaufNormalarbeitszeits)
                  .HasForeignKey(i => i.MitarbeiterID)
                  .HasPrincipalKey(i => i.MitarbeiterID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Mitteilungen>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Mitteilungens)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Mitteilungen>()
                  .HasOne(i => i.Dokumente)
                  .WithMany(i => i.Mitteilungens)
                  .HasForeignKey(i => i.DokumentID)
                  .HasPrincipalKey(i => i.DokumentID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitteilungenVerteiler>()
                  .HasOne(i => i.Mitteilungen)
                  .WithMany(i => i.MitteilungenVerteilers)
                  .HasForeignKey(i => i.MitteilungID)
                  .HasPrincipalKey(i => i.MitteilungID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.MitteilungenVerteiler>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.MitteilungenVerteilers)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);
            builder.Entity<SinDarEla.Models.DbSinDarEla.Protokoll>()
                  .HasOne(i => i.Base)
                  .WithMany(i => i.Protokolls)
                  .HasForeignKey(i => i.BaseID)
                  .HasPrincipalKey(i => i.BaseID);

            builder.Entity<SinDarEla.Models.DbSinDarEla.AbrechnungBasis>()
                  .Property(p => p.Gesperrt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Aufgaben>()
                  .Property(p => p.Erledigt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Benutzer>()
                  .Property(p => p.Sperren)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.BenutzerModule>()
                  .Property(p => p.ErlaubtNeu)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.BenutzerModule>()
                  .Property(p => p.ErlaubtAendern)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.BenutzerModule>()
                  .Property(p => p.ErlaubtLoeschen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.StatusAntrag)
                  .HasDefaultValueSql("Offen");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.Gesperrt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.GefuehlSituation01)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.GefuehlSituation02)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.GefuehlSituation03)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.GefuehlSituation04)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.GefuehlSituation05)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.GefuehlSituation06)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.KundenFahrtMinuten)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.KundenFahrtKM)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.BetreuerAnAbReiseMinuten)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Ereignisse>()
                  .Property(p => p.BetreuerAnAbReiseKM)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseArten>()
                  .Property(p => p.TerminGanzerTag)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseArten>()
                  .Property(p => p.Beantragungspflicht)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseArten>()
                  .Property(p => p.Begruendungspflicht)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseArten>()
                  .Property(p => p.TeilnehmerErfassen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseArten>()
                  .Property(p => p.TermineDienstplan)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.EreignisseArten>()
                  .Property(p => p.TermineManagement)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Feedback>()
                  .Property(p => p.Erledigt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheide>()
                  .Property(p => p.Ergaenzungsbescheid)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>()
                  .Property(p => p.AnrechnungGehalt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>()
                  .Property(p => p.AnrechnungUrlaub)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>()
                  .Property(p => p.DienstzeitRechnen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.MitteilungenVerteiler>()
                  .Property(p => p.Gelesen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Module>()
                  .Property(p => p.ImDashboard)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.Protokoll>()
                  .Property(p => p.Gelesen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAbrechnungBasisReststunden>()
                  .Property(p => p.AbrechnungBasisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAbrechnungBasisReststunden>()
                  .Property(p => p.Gesperrt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAbrechnungKundenReststunden>()
                  .Property(p => p.AbrechnungKundenReststundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAbrechnungKundenReststunden>()
                  .Property(p => p.Reststunden)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAbrechnungKundenReststunden>()
                  .Property(p => p.NichtAbgerechnet)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAbrechnungKundenReststunden>()
                  .Property(p => p.Offen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAufgaben>()
                  .Property(p => p.AufgabeID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAufgaben>()
                  .Property(p => p.ZustaendigBaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwAufgabenOffen>()
                  .Property(p => p.AufgabenOffen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBase>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseBenutzer>()
                  .Property(p => p.BenutzerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseBenutzer>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseEreignisse>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseKontakte>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseKontakte>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseKunden>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseKunden>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseMitarbeiter>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseMitarbeiter>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseStatistik>()
                  .Property(p => p.AnzahlBase)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseStatistik>()
                  .Property(p => p.AnzahlKunden)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseStatistik>()
                  .Property(p => p.AnzahlMitarbeiter)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseStatistik>()
                  .Property(p => p.AnzahlBenutzer)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseSuchen>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseUndKunden>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseUndKunden>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseVerweise>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseVerweise>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseVerweise>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBaseVerweise>()
                  .Property(p => p.BenutzerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBenutzer>()
                  .Property(p => p.BenutzerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBenutzerAuswahlNeue>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBenutzerModule>()
                  .Property(p => p.BenutzerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwBenutzerSuchen>()
                  .Property(p => p.BenutzerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDashboardTermineGeplant>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanEreignisse>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>()
                  .Property(p => p.Anspruch)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>()
                  .Property(p => p.Verbrauch)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>()
                  .Property(p => p.Rest)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>()
                  .Property(p => p.KundenbesucheErledigt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>()
                  .Property(p => p.KundenbesucheGeplant)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>()
                  .Property(p => p.KundenbesucheOffen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDokumente>()
                  .Property(p => p.DokumentID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwDokumenteAnzahl>()
                  .Property(p => p.AnzahlDokumente)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisse>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseAlle>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseAlle>()
                  .Property(p => p.StundenUrlaub)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseAlle>()
                  .Property(p => p.StatusAntrag)
                  .HasDefaultValueSql("Offen");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseAlle>()
                  .Property(p => p.Gesperrt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseAlle>()
                  .Property(p => p.EreignisseTeilnehmerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseAntraege>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseAntraege>()
                  .Property(p => p.StundenUrlaub)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseGesamt>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseGesamt>()
                  .Property(p => p.EreignisseTeilnehmerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.GefuehlSituation01)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.GefuehlSituation02)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.GefuehlSituation03)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.GefuehlSituation04)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.GefuehlSituation05)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.GefuehlSituation06)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.KundenFahrtMinuten)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.KundenFahrtKM)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.BetreuerAnAbReiseMinuten)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>()
                  .Property(p => p.BetreuerAnAbReiseKM)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenbesucheHeuteOffen>()
                  .Property(p => p.EreignisseKundenbesucheOffen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseMitTeilnehmer>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseMitTeilnehmer>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboard>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboard>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboardMobile>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboardMobile>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboardMobile>()
                  .Property(p => p.KundenLeistungArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboardMobile>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanListe>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanListe>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanListe>()
                  .Property(p => p.KundenLeistungArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanListe>()
                  .Property(p => p.Gesperrt)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanMobile>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanMobile>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanMobile>()
                  .Property(p => p.KundenLeistungArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanMobile>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulKunden>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulManagement>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulManagement>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulMitarbeiter>()
                  .Property(p => p.id)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseModulMitarbeiter>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwEreignisseTeilnehmerListe>()
                  .Property(p => p.EreignisseTeilnehmerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwFeedback>()
                  .Property(p => p.FeedbackID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwGeburtstage>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKunden>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenAuswahlNeu>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenBase>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenBase>()
                  .Property(p => p.AnredeID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenBescheideKontingente>()
                  .Property(p => p.KundenLeistungenBescheideKontingentID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenBetreuer>()
                  .Property(p => p.KundenLeistungenBetreuerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenEreignisse>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenGeburtstage>()
                  .Property(p => p.BetreuerBaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenGeburtstage>()
                  .Property(p => p.TabelleID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenHauptbetreuer>()
                  .Property(p => p.KundenLeistungenBetreuerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenHauptbetreuer>()
                  .Property(p => p.KundenLeistungID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenHauptbetreuer>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenKontingente>()
                  .Property(p => p.KundenLeistungenBescheideKontingentID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungen>()
                  .Property(p => p.KundenLeistungID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungen>()
                  .Property(p => p.LeistungMinuten)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungen>()
                  .Property(p => p.KontingentAnpruch)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungen>()
                  .Property(p => p.KontingentVerbrauch)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungen>()
                  .Property(p => p.KontingentRest)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenBescheide>()
                  .Property(p => p.KundenLeistungID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenBescheide>()
                  .Property(p => p.KundenLeistungenBescheidID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenBetreuer>()
                  .Property(p => p.KundenLeistungenBetreuerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenKontingente>()
                  .Property(p => p.KundenLeistungID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenKontingente>()
                  .Property(p => p.KundenLeistungenBescheideKontingentID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenProBetreuer>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenSuchen>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenTermineErledigt>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenTermineGeplant>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenTermineZusammenfassung>()
                  .Property(p => p.AnzahlTermine)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuer>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuer>()
                  .Property(p => p.BenutzerRolleID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuerAuswahl>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuerUndLeistungenAuswahl>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiter>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle>()
                  .Property(p => p.MitarbeiterArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle>()
                  .Property(p => p.BisMitarbeiterArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlDashboard>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlNeu>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlTermin>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterEreignisse>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterEreignisse>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterAuswahl>()
                  .Property(p => p.ID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterAuswahl>()
                  .Property(p => p.SortierungGruppe)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterListe>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterListe>()
                  .Property(p => p.MitarbeiterTaetigkeitenArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle>()
                  .Property(p => p.MitarbeiterArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle>()
                  .Property(p => p.MitarbeiterStatusID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle>()
                  .Property(p => p.MitarbeiterTaetigkeitenArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterGeburtstage>()
                  .Property(p => p.BetreuerBaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterGeburtstage>()
                  .Property(p => p.TabelleID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenAnzahlAa>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb>()
                  .Property(p => p.AnzahlvonKundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenLeistungen>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenLeistungen>()
                  .Property(p => p.KundenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterMitTextAlle>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterMitTextAlle>()
                  .Property(p => p.BaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterMitTextAlle>()
                  .Property(p => p.BisBaseID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterMitTextAlle>()
                  .Property(p => p.MitarbeiterArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterMitTextAlle>()
                  .Property(p => p.MitarbeiterStatusID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle>()
                  .Property(p => p.MitarbeiterStatusID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle>()
                  .Property(p => p.BisMitarbeiterStatusID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterSuchen>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle>()
                  .Property(p => p.MitarbeiterTaetigkeitenArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle>()
                  .Property(p => p.BisMitarbeiterTaetigkeitenArtID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineErledigt>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineErledigt>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineGeplant>()
                  .Property(p => p.EreignisID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineGeplant>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung>()
                  .Property(p => p.MitarbeiterID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung>()
                  .Property(p => p.AnzahlTermine)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterUrlaub>()
                  .Property(p => p.MitarbeiterUrlaubID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten>()
                  .Property(p => p.MitarbeiterVerlaufDienstzeitenID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten>()
                  .Property(p => p.BisIstNull)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten>()
                  .Property(p => p.DienstzeitRechnen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten>()
                  .Property(p => p.Referenz_MitarbeiterStatusID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitteilungen>()
                  .Property(p => p.MitteilungID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitteilungen>()
                  .Property(p => p.DokumentID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitteilungenOffen>()
                  .Property(p => p.MitteilungenOffen)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwMitteilungenVerteiler>()
                  .Property(p => p.MitteilungVerteilerID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwModuleAuswahlMitTextAlle>()
                  .Property(p => p.ModulID)
                  .HasDefaultValueSql("0");

            builder.Entity<SinDarEla.Models.DbSinDarEla.VwProtokollOffen>()
                  .Property(p => p.ProtokollOffen)
                  .HasDefaultValueSql("0");


            this.OnModelBuilding(builder);
        }


        public DbSet<SinDarEla.Models.DbSinDarEla.AbrechnungBasis> AbrechnungBases
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.AbrechnungKundenReststunden> AbrechnungKundenReststundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Aufgaben> Aufgabens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.AuswahlJahr> AuswahlJahrs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.AuswahlMonat> AuswahlMonats
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Base> Bases
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.BaseAnreden> BaseAnredens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.BaseBanken> BaseBankens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.BaseKontakte> BaseKontaktes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Benutzer> Benutzers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.BenutzerModule> BenutzerModules
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.BenutzerProtokoll> BenutzerProtokolls
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.BenutzerRollen> BenutzerRollens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Debugg> Debuggs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Dokumente> Dokumentes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.DokumenteKategorien> DokumenteKategoriens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Ereignisse> Ereignisses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.EreignisseArten> EreignisseArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.EreignisseSonderurlaubArten> EreignisseSonderurlaubArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.EreignisseTeilnehmer> EreignisseTeilnehmers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.EreignisseTeilnehmerStatus> EreignisseTeilnehmerStatuses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Feedback> Feedbacks
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Kunden> Kundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenInfo> KundenInfos
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenKontakte> KundenKontaktes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenKontakteArten> KundenKontakteArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenLeistungArten> KundenLeistungArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenLeistungen> KundenLeistungens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheide> KundenLeistungenBescheides
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheideKontingente> KundenLeistungenBescheideKontingentes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheideStatus> KundenLeistungenBescheideStatuses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBetreuer> KundenLeistungenBetreuers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBetreuerArten> KundenLeistungenBetreuerArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.KundenStatus> KundenStatuses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Mitarbeiter> Mitarbeiters
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterArten> MitarbeiterArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterFortbildungen> MitarbeiterFortbildungens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterFortbildungenArten> MitarbeiterFortbildungenArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterInfo> MitarbeiterInfos
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterKundenbudget> MitarbeiterKundenbudgets
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> MitarbeiterKundenbudgetKategoriens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterStatus> MitarbeiterStatuses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterTaetigkeiten> MitarbeiterTaetigkeitens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> MitarbeiterTaetigkeitenArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaub> MitarbeiterUrlaubs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubDetail> MitarbeiterUrlaubDetails
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> MitarbeiterUrlaubKumuliertAnspruches
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> MitarbeiterUrlaubKumuliertDienstzeitens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> MitarbeiterVerlaufDienstzeitens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> MitarbeiterVerlaufDienstzeitenArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufGehalt> MitarbeiterVerlaufGehalts
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> MitarbeiterVerlaufNormalarbeitszeits
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Mitteilungen> Mitteilungens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.MitteilungenVerteiler> MitteilungenVerteilers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Module> Modules
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Protokoll> Protokolls
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.RegelnAbwesenheiten> RegelnAbwesenheitens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.TextbausteineHtml> TextbausteineHtmls
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.Versionskontrolle> Versionskontrolles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwAbrechnungBasisReststunden> VwAbrechnungBasisReststundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwAbrechnungKundenReststunden> VwAbrechnungKundenReststundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwAufgaben> VwAufgabens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwAufgabenOffen> VwAufgabenOffens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBase> VwBases
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseBenutzer> VwBaseBenutzers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseEreignisse> VwBaseEreignisses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseKontakte> VwBaseKontaktes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseKunden> VwBaseKundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseMitarbeiter> VwBaseMitarbeiters
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseStatistik> VwBaseStatistiks
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseSuchen> VwBaseSuchens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseUndKunden> VwBaseUndKundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBaseVerweise> VwBaseVerweises
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBenutzer> VwBenutzers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBenutzerAnu> VwBenutzerAnus
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBenutzerAuswahlNeue> VwBenutzerAuswahlNeues
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBenutzerModule> VwBenutzerModules
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwBenutzerSuchen> VwBenutzerSuchens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwDashboardTermineGeplant> VwDashboardTermineGeplants
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwDienstplanEreignisse> VwDienstplanEreignisses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen> VwDienstplanKundenLeistungens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwDokumente> VwDokumentes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwDokumenteAnzahl> VwDokumenteAnzahls
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisse> VwEreignisses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseAlle> VwEreignisseAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseAntraege> VwEreignisseAntraeges
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseAntraegeUrlaubVerbraucht> VwEreignisseAntraegeUrlaubVerbrauchts
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenDienstplan> VwEreignisseArtenDienstplans
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenManagement> VwEreignisseArtenManagements
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenMitTextAlle> VwEreignisseArtenMitTextAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenModule> VwEreignisseArtenModules
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseGesamt> VwEreignisseGesamts
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche> VwEreignisseKundenBesuches
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenbesucheHeute> VwEreignisseKundenbesucheHeutes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenbesucheHeuteOffen> VwEreignisseKundenbesucheHeuteOffens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseMitTeilnehmer> VwEreignisseMitTeilnehmers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboard> VwEreignisseModulDashboards
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboardMobile> VwEreignisseModulDashboardMobiles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanListe> VwEreignisseModulDienstplanListes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanMobile> VwEreignisseModulDienstplanMobiles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulKunden> VwEreignisseModulKundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulManagement> VwEreignisseModulManagements
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulMitarbeiter> VwEreignisseModulMitarbeiters
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwEreignisseTeilnehmerListe> VwEreignisseTeilnehmerListes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwFeedback> VwFeedbacks
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwGeburtstage> VwGeburtstages
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKunden> VwKundens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenAuswahlNeu> VwKundenAuswahlNeus
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenBase> VwKundenBases
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenBescheideKontingente> VwKundenBescheideKontingentes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenBetreuer> VwKundenBetreuers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenEreignisse> VwKundenEreignisses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenGeburtstage> VwKundenGeburtstages
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenHauptbetreuer> VwKundenHauptbetreuers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenKontingente> VwKundenKontingentes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungen> VwKundenLeistungens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenBescheide> VwKundenLeistungenBescheides
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenBetreuer> VwKundenLeistungenBetreuers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenKontingente> VwKundenLeistungenKontingentes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenProBetreuer> VwKundenProBetreuers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenSuchen> VwKundenSuchens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenTermineErledigt> VwKundenTermineErledigts
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenTermineGeplant> VwKundenTermineGeplants
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenTermineZusammenfassung> VwKundenTermineZusammenfassungs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuer> VwKundenUndBetreuers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuerAuswahl> VwKundenUndBetreuerAuswahls
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuerUndLeistungenAuswahl> VwKundenUndBetreuerUndLeistungenAuswahls
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiter> VwMitarbeiters
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle> VwMitarbeiterArtenMitTextAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlDashboard> VwMitarbeiterAuswahlDashboards
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlNeu> VwMitarbeiterAuswahlNeus
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlTermin> VwMitarbeiterAuswahlTermins
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterEreignisse> VwMitarbeiterEreignisses
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterAuswahl> VwMitarbeiterFilterAuswahls
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterListe> VwMitarbeiterFilterListes
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahr> VwMitarbeiterFortbildungenSummenJahrs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahrArten> VwMitarbeiterFortbildungenSummenJahrArtens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle> VwMitarbeiterFuerAuswahlMitTextAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterGeburtstage> VwMitarbeiterGeburtstages
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenAnzahlAa> VwMitarbeiterKundenAnzahlAas
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb> VwMitarbeiterKundenAnzahlBbs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenLeistungen> VwMitarbeiterKundenLeistungens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahr> VwMitarbeiterKundenbudgetSummenJahrs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahrKategorien> VwMitarbeiterKundenbudgetSummenJahrKategoriens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterMitTextAlle> VwMitarbeiterMitTextAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterSonderurlaubEinfach> VwMitarbeiterSonderurlaubEinfaches
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle> VwMitarbeiterStatusMitTextAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterSuchen> VwMitarbeiterSuchens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> VwMitarbeiterTaetigkeitens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle> VwMitarbeiterTaetigkeitenMitTextAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineErledigt> VwMitarbeiterTermineErledigts
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineGeplant> VwMitarbeiterTermineGeplants
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung> VwMitarbeiterTermineZusammenfassungs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterUrlaub> VwMitarbeiterUrlaubs
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten> VwMitarbeiterVerlaufDienstzeitens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitteilungen> VwMitteilungens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitteilungenOffen> VwMitteilungenOffens
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwMitteilungenVerteiler> VwMitteilungenVerteilers
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwModuleAuswahlMitTextAlle> VwModuleAuswahlMitTextAlles
        {
          get;
          set;
        }

        public DbSet<SinDarEla.Models.DbSinDarEla.VwProtokollOffen> VwProtokollOffens
        {
          get;
          set;
        }
    }
}
