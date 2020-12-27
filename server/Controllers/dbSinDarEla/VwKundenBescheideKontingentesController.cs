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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenBescheideKontingentes")]
  [Route("mvc/odata/dbSinDarEla/VwKundenBescheideKontingentes")]
  public partial class VwKundenBescheideKontingentesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenBescheideKontingentesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenBescheideKontingentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenBescheideKontingente> GetVwKundenBescheideKontingentes()
    {
      var items = this.context.VwKundenBescheideKontingentes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenBescheideKontingente>();
      this.OnVwKundenBescheideKontingentesRead(ref items);

      return items;
    }

    partial void OnVwKundenBescheideKontingentesRead(ref IQueryable<Models.DbSinDarEla.VwKundenBescheideKontingente> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungenBescheidID}")]
    public SingleResult<VwKundenBescheideKontingente> GetVwKundenBescheideKontingente(int key)
    {
        var items = this.context.VwKundenBescheideKontingentes.AsNoTracking().Where(i=>i.KundenLeistungenBescheidID == key);
        this.OnVwKundenBescheideKontingentesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenBescheideKontingentesGet(ref IQueryable<Models.DbSinDarEla.VwKundenBescheideKontingente> items);

  }
}
