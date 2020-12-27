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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenLeistungenBetreuers")]
  [Route("mvc/odata/dbSinDarEla/VwKundenLeistungenBetreuers")]
  public partial class VwKundenLeistungenBetreuersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenLeistungenBetreuersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenLeistungenBetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenLeistungenBetreuer> GetVwKundenLeistungenBetreuers()
    {
      var items = this.context.VwKundenLeistungenBetreuers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenLeistungenBetreuer>();
      this.OnVwKundenLeistungenBetreuersRead(ref items);

      return items;
    }

    partial void OnVwKundenLeistungenBetreuersRead(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungenBetreuer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungID}")]
    public SingleResult<VwKundenLeistungenBetreuer> GetVwKundenLeistungenBetreuer(int key)
    {
        var items = this.context.VwKundenLeistungenBetreuers.AsNoTracking().Where(i=>i.KundenLeistungID == key);
        this.OnVwKundenLeistungenBetreuersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenLeistungenBetreuersGet(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungenBetreuer> items);

  }
}
