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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBenutzerAuswahlNeues")]
  [Route("mvc/odata/dbSinDarEla/VwBenutzerAuswahlNeues")]
  public partial class VwBenutzerAuswahlNeuesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBenutzerAuswahlNeuesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBenutzerAuswahlNeues
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBenutzerAuswahlNeue> GetVwBenutzerAuswahlNeues()
    {
      var items = this.context.VwBenutzerAuswahlNeues.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBenutzerAuswahlNeue>();
      this.OnVwBenutzerAuswahlNeuesRead(ref items);

      return items;
    }

    partial void OnVwBenutzerAuswahlNeuesRead(ref IQueryable<Models.DbSinDarEla.VwBenutzerAuswahlNeue> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwBenutzerAuswahlNeue> GetVwBenutzerAuswahlNeue(int key)
    {
        var items = this.context.VwBenutzerAuswahlNeues.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwBenutzerAuswahlNeuesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBenutzerAuswahlNeuesGet(ref IQueryable<Models.DbSinDarEla.VwBenutzerAuswahlNeue> items);

  }
}
