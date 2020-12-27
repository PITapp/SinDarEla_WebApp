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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseModulKundens")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseModulKundens")]
  public partial class VwEreignisseModulKundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseModulKundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseModulKundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseModulKunden> GetVwEreignisseModulKundens()
    {
      var items = this.context.VwEreignisseModulKundens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseModulKunden>();
      this.OnVwEreignisseModulKundensRead(ref items);

      return items;
    }

    partial void OnVwEreignisseModulKundensRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulKunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseModulKunden> GetVwEreignisseModulKunden(string key)
    {
        var items = this.context.VwEreignisseModulKundens.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseModulKundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseModulKundensGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulKunden> items);

  }
}
