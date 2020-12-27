using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace SinDarEla.Controllers.DbSinDarEla
{
  using Models;
  using Data;
  using Models.DbSinDarEla;

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenLeistungenKontingentes")]
  [Route("mvc/odata/dbSinDarEla/VwKundenLeistungenKontingentes")]
  public partial class VwKundenLeistungenKontingentesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenLeistungenKontingentesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenLeistungenKontingentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenLeistungenKontingente> GetVwKundenLeistungenKontingentes()
    {
      var items = this.context.VwKundenLeistungenKontingentes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenLeistungenKontingente>();
      this.OnVwKundenLeistungenKontingentesRead(ref items);

      return items;
    }

    partial void OnVwKundenLeistungenKontingentesRead(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungenKontingente> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenID}")]
    public SingleResult<VwKundenLeistungenKontingente> GetVwKundenLeistungenKontingente(int key)
    {
        var items = this.context.VwKundenLeistungenKontingentes.AsNoTracking().Where(i=>i.KundenID == key);
        this.OnVwKundenLeistungenKontingentesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenLeistungenKontingentesGet(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungenKontingente> items);

  }
}
