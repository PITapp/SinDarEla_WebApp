using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Hosting;

using SinDarEla.Data;
using SinDarEla.Models;
using SinDarEla.Authentication;

namespace SinDarEla
{
  public partial class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    partial void OnConfigureServices(IServiceCollection services);

    partial void OnConfiguringServices(IServiceCollection services);

    public void ConfigureServices(IServiceCollection services)
    {
      OnConfiguringServices(services);

      services.AddOptions();
      services.AddLogging(logging =>
      {
          logging.AddConsole();
          logging.AddDebug();
      });

      services.AddCors(options =>
      {
          options.AddPolicy(
              "AllowAny",
              x =>
              {
                  x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .SetIsOriginAllowed(isOriginAllowed: _ => true)
                  .AllowCredentials();
              });
      });
      services.AddMvc(options =>
      {
          options.EnableEndpointRouting = false;

          options.OutputFormatters.Add(new SinDarEla.Data.XlsDataContractSerializerOutputFormatter());
          options.FormatterMappings.SetMediaTypeMappingForFormat("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

          options.OutputFormatters.Add(new SinDarEla.Data.CsvDataContractSerializerOutputFormatter());
          options.FormatterMappings.SetMediaTypeMappingForFormat("csv", "text/csv");
      }).AddNewtonsoftJson();

      services.AddAuthorization();
      services.AddOData();
      services.AddODataQueryFilter();
      services.AddHttpContextAccessor();
      var tokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = TokenProviderOptions.Key,
          ValidateIssuer = true,
          ValidIssuer = TokenProviderOptions.Issuer,
          ValidateAudience = true,
          ValidAudience = TokenProviderOptions.Audience,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
      };

      services.AddAuthentication(options =>
      {
          options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
          options.Audience = TokenProviderOptions.Audience;
          options.ClaimsIssuer = TokenProviderOptions.Issuer;
          options.TokenValidationParameters = tokenValidationParameters;
          options.SaveToken = true;
      });
      services.AddDbContext<ApplicationIdentityDbContext>(options =>
      {
         options.UseMySql(Configuration.GetConnectionString("dbSinDarElaConnection"));
      });

      services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

      services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationPrincipalFactory>();


      services.AddDbContext<SinDarEla.Data.DbSinDarElaContext>(options =>
      {
        options.UseMySql(Configuration.GetConnectionString("dbSinDarElaConnection"));
      });

      OnConfigureServices(services);
    }

    partial void OnConfigure(IApplicationBuilder app);


    partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);
    partial void OnConfigureOData(ODataConventionModelBuilder builder);

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      OnConfiguring(app, env);

      IServiceProvider provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();
      app.UseCors("AllowAny");
      app.Use(async (context, next) => {
          if (context.Request.Path.Value == "/__ssrsreport" || context.Request.Path.Value == "/ssrsproxy") {
            await next();
            return;
          }
          await next();
          if ((context.Response.StatusCode == 404 || context.Response.StatusCode == 401) && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.Contains("/odata")) {
              context.Request.Path = "/index.html";
              await next();
          }
      });

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseDeveloperExceptionPage();

      app.UseMvc(builder =>
      {
          builder.Count().Filter().OrderBy().Expand().Select().MaxTop(null).SetTimeZoneInfo(TimeZoneInfo.Utc);

          if (env.EnvironmentName == "Development")
          {
              builder.MapRoute(name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" }
              );
          }

          var oDataBuilder = new ODataConventionModelBuilder(provider);

          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.AbrechnungBasis>("AbrechnungBases");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.AbrechnungKundenReststunden>("AbrechnungKundenReststundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Aufgaben>("Aufgabens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.AuswahlJahr>("AuswahlJahrs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.AuswahlMonat>("AuswahlMonats");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Base>("Bases");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.BaseAnreden>("BaseAnredens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.BaseBanken>("BaseBankens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.BaseKontakte>("BaseKontaktes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Benutzer>("Benutzers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.BenutzerModule>("BenutzerModules");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.BenutzerProtokoll>("BenutzerProtokolls");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.BenutzerRollen>("BenutzerRollens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Debugg>("Debuggs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Dokumente>("Dokumentes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.DokumenteKategorien>("DokumenteKategoriens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Ereignisse>("Ereignisses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.EreignisseArten>("EreignisseArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.EreignisseSonderurlaubArten>("EreignisseSonderurlaubArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.EreignisseTeilnehmer>("EreignisseTeilnehmers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.EreignisseTeilnehmerStatus>("EreignisseTeilnehmerStatuses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Feedback>("Feedbacks");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Kunden>("Kundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenInfo>("KundenInfos");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenKontakte>("KundenKontaktes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenKontakteArten>("KundenKontakteArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenLeistungArten>("KundenLeistungArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenLeistungen>("KundenLeistungens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheide>("KundenLeistungenBescheides");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheideKontingente>("KundenLeistungenBescheideKontingentes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBescheideStatus>("KundenLeistungenBescheideStatuses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBetreuer>("KundenLeistungenBetreuers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenLeistungenBetreuerArten>("KundenLeistungenBetreuerArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.KundenStatus>("KundenStatuses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Mitarbeiter>("Mitarbeiters");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterArten>("MitarbeiterArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterFortbildungen>("MitarbeiterFortbildungens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterFortbildungenArten>("MitarbeiterFortbildungenArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterInfo>("MitarbeiterInfos");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterKundenbudget>("MitarbeiterKundenbudgets");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>("MitarbeiterKundenbudgetKategoriens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterStatus>("MitarbeiterStatuses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterTaetigkeiten>("MitarbeiterTaetigkeitens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>("MitarbeiterTaetigkeitenArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaub>("MitarbeiterUrlaubs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubDetail>("MitarbeiterUrlaubDetails");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>("MitarbeiterUrlaubKumuliertAnspruches");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>("MitarbeiterUrlaubKumuliertDienstzeitens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>("MitarbeiterVerlaufDienstzeitens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>("MitarbeiterVerlaufDienstzeitenArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufGehalt>("MitarbeiterVerlaufGehalts");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>("MitarbeiterVerlaufNormalarbeitszeits");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Mitteilungen>("Mitteilungens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.MitteilungenVerteiler>("MitteilungenVerteilers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Module>("Modules");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Protokoll>("Protokolls");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.RegelnAbwesenheiten>("RegelnAbwesenheitens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.TextbausteineHtml>("TextbausteineHtmls");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.Versionskontrolle>("Versionskontrolles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwAbrechnungBasisReststunden>("VwAbrechnungBasisReststundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwAbrechnungKundenReststunden>("VwAbrechnungKundenReststundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwAufgaben>("VwAufgabens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwAufgabenOffen>("VwAufgabenOffens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBase>("VwBases");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseBenutzer>("VwBaseBenutzers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseEreignisse>("VwBaseEreignisses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseKontakte>("VwBaseKontaktes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseKunden>("VwBaseKundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseMitarbeiter>("VwBaseMitarbeiters");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseStatistik>("VwBaseStatistiks");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseSuchen>("VwBaseSuchens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseUndKunden>("VwBaseUndKundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBaseVerweise>("VwBaseVerweises");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBenutzer>("VwBenutzers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBenutzerAnu>("VwBenutzerAnus");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBenutzerAuswahlNeue>("VwBenutzerAuswahlNeues");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBenutzerModule>("VwBenutzerModules");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwBenutzerSuchen>("VwBenutzerSuchens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwDashboardTermineGeplant>("VwDashboardTermineGeplants");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwDienstplanEreignisse>("VwDienstplanEreignisses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwDienstplanKundenLeistungen>("VwDienstplanKundenLeistungens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwDokumente>("VwDokumentes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwDokumenteAnzahl>("VwDokumenteAnzahls");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisse>("VwEreignisses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseAlle>("VwEreignisseAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseAntraege>("VwEreignisseAntraeges");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseAntraegeUrlaubVerbraucht>("VwEreignisseAntraegeUrlaubVerbrauchts");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenDienstplan>("VwEreignisseArtenDienstplans");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenManagement>("VwEreignisseArtenManagements");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenMitTextAlle>("VwEreignisseArtenMitTextAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseArtenModule>("VwEreignisseArtenModules");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseGesamt>("VwEreignisseGesamts");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenBesuche>("VwEreignisseKundenBesuches");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenbesucheHeute>("VwEreignisseKundenbesucheHeutes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseKundenbesucheHeuteOffen>("VwEreignisseKundenbesucheHeuteOffens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseMitTeilnehmer>("VwEreignisseMitTeilnehmers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboard>("VwEreignisseModulDashboards");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDashboardMobile>("VwEreignisseModulDashboardMobiles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanListe>("VwEreignisseModulDienstplanListes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulDienstplanMobile>("VwEreignisseModulDienstplanMobiles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulKunden>("VwEreignisseModulKundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulManagement>("VwEreignisseModulManagements");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseModulMitarbeiter>("VwEreignisseModulMitarbeiters");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwEreignisseTeilnehmerListe>("VwEreignisseTeilnehmerListes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwFeedback>("VwFeedbacks");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwGeburtstage>("VwGeburtstages");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKunden>("VwKundens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenAuswahlNeu>("VwKundenAuswahlNeus");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenBase>("VwKundenBases");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenBescheideKontingente>("VwKundenBescheideKontingentes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenBetreuer>("VwKundenBetreuers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenEreignisse>("VwKundenEreignisses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenGeburtstage>("VwKundenGeburtstages");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenHauptbetreuer>("VwKundenHauptbetreuers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenKontingente>("VwKundenKontingentes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungen>("VwKundenLeistungens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenBescheide>("VwKundenLeistungenBescheides");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenBetreuer>("VwKundenLeistungenBetreuers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenLeistungenKontingente>("VwKundenLeistungenKontingentes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenProBetreuer>("VwKundenProBetreuers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenSuchen>("VwKundenSuchens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenTermineErledigt>("VwKundenTermineErledigts");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenTermineGeplant>("VwKundenTermineGeplants");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenTermineZusammenfassung>("VwKundenTermineZusammenfassungs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuer>("VwKundenUndBetreuers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuerAuswahl>("VwKundenUndBetreuerAuswahls");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwKundenUndBetreuerUndLeistungenAuswahl>("VwKundenUndBetreuerUndLeistungenAuswahls");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiter>("VwMitarbeiters");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle>("VwMitarbeiterArtenMitTextAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlDashboard>("VwMitarbeiterAuswahlDashboards");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlNeu>("VwMitarbeiterAuswahlNeus");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterAuswahlTermin>("VwMitarbeiterAuswahlTermins");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterEreignisse>("VwMitarbeiterEreignisses");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterAuswahl>("VwMitarbeiterFilterAuswahls");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFilterListe>("VwMitarbeiterFilterListes");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahr>("VwMitarbeiterFortbildungenSummenJahrs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahrArten>("VwMitarbeiterFortbildungenSummenJahrArtens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle>("VwMitarbeiterFuerAuswahlMitTextAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterGeburtstage>("VwMitarbeiterGeburtstages");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenAnzahlAa>("VwMitarbeiterKundenAnzahlAas");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb>("VwMitarbeiterKundenAnzahlBbs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenLeistungen>("VwMitarbeiterKundenLeistungens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahr>("VwMitarbeiterKundenbudgetSummenJahrs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahrKategorien>("VwMitarbeiterKundenbudgetSummenJahrKategoriens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterMitTextAlle>("VwMitarbeiterMitTextAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterSonderurlaubEinfach>("VwMitarbeiterSonderurlaubEinfaches");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle>("VwMitarbeiterStatusMitTextAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterSuchen>("VwMitarbeiterSuchens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten>("VwMitarbeiterTaetigkeitens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle>("VwMitarbeiterTaetigkeitenMitTextAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineErledigt>("VwMitarbeiterTermineErledigts");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineGeplant>("VwMitarbeiterTermineGeplants");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung>("VwMitarbeiterTermineZusammenfassungs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterUrlaub>("VwMitarbeiterUrlaubs");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten>("VwMitarbeiterVerlaufDienstzeitens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitteilungen>("VwMitteilungens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitteilungenOffen>("VwMitteilungenOffens");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwMitteilungenVerteiler>("VwMitteilungenVerteilers");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwModuleAuswahlMitTextAlle>("VwModuleAuswahlMitTextAlles");
          oDataBuilder.EntitySet<SinDarEla.Models.DbSinDarEla.VwProtokollOffen>("VwProtokollOffens");

          this.OnConfigureOData(oDataBuilder);

          oDataBuilder.EntitySet<ApplicationUser>("ApplicationUsers");
          var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(ApplicationUser));
          usersType.AddCollectionProperty(typeof(ApplicationUser).GetProperty("RoleNames"));
          oDataBuilder.EntitySet<IdentityRole>("ApplicationRoles");

          var model = oDataBuilder.GetEdmModel();

          builder.MapODataServiceRoute("odata/dbSinDarEla", "odata/dbSinDarEla", model);

          builder.MapODataServiceRoute("auth", "auth", model);
      });

      if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("RADZEN")) && env.IsDevelopment())
      {
        app.UseSpa(spa =>
        {
          spa.Options.SourcePath = "../client";
          spa.UseAngularCliServer(npmScript: "start -- --port 8000 --open");
        });
      }

      OnConfigure(app);
      OnConfigure(app, env);
    }
  }
}
