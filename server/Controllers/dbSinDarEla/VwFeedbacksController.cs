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

  [ODataRoutePrefix("odata/dbSinDarEla/VwFeedbacks")]
  [Route("mvc/odata/dbSinDarEla/VwFeedbacks")]
  public partial class VwFeedbacksController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwFeedbacksController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwFeedbacks
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwFeedback> GetVwFeedbacks()
    {
      var items = this.context.VwFeedbacks.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwFeedback>();
      this.OnVwFeedbacksRead(ref items);

      return items;
    }

    partial void OnVwFeedbacksRead(ref IQueryable<Models.DbSinDarEla.VwFeedback> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwFeedback> GetVwFeedback(int key)
    {
        var items = this.context.VwFeedbacks.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwFeedbacksGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwFeedbacksGet(ref IQueryable<Models.DbSinDarEla.VwFeedback> items);

  }
}
