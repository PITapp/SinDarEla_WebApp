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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenKontingentes")]
  [Route("mvc/odata/dbSinDarEla/VwKundenKontingentes")]
  public partial class VwKundenKontingentesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenKontingentesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenKontingentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenKontingente> GetVwKundenKontingentes()
    {
      var items = this.context.VwKundenKontingentes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenKontingente>();
      this.OnVwKundenKontingentesRead(ref items);

      return items;
    }

    partial void OnVwKundenKontingentesRead(ref IQueryable<Models.DbSinDarEla.VwKundenKontingente> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungenBescheidID}")]
    public SingleResult<VwKundenKontingente> GetVwKundenKontingente(int key)
    {
        var items = this.context.VwKundenKontingentes.AsNoTracking().Where(i=>i.KundenLeistungenBescheidID == key);
        this.OnVwKundenKontingentesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenKontingentesGet(ref IQueryable<Models.DbSinDarEla.VwKundenKontingente> items);

  }
}
