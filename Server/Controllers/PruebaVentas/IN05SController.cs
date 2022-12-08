using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VentaProducto.Server.Controllers.PruebaVentas
{
    [Route("odata/PruebaVentas/IN05S")]
    public partial class IN05SController : ODataController
    {
        private VentaProducto.Server.Data.PruebaVentasContext context;

        public IN05SController(VentaProducto.Server.Data.PruebaVentasContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<VentaProducto.Server.Models.PruebaVentas.IN05> GetIN05S()
        {
            var items = this.context.IN05S.AsQueryable<VentaProducto.Server.Models.PruebaVentas.IN05>();
            this.OnIN05SRead(ref items);

            return items;
        }

        partial void OnIN05SRead(ref IQueryable<VentaProducto.Server.Models.PruebaVentas.IN05> items);

        partial void OnIN05Get(ref SingleResult<VentaProducto.Server.Models.PruebaVentas.IN05> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/PruebaVentas/IN05S(idIN05={idIN05})")]
        public SingleResult<VentaProducto.Server.Models.PruebaVentas.IN05> GetIN05(int key)
        {
            var items = this.context.IN05S.Where(i => i.idIN05 == key);
            var result = SingleResult.Create(items);

            OnIN05Get(ref result);

            return result;
        }
        partial void OnIN05Deleted(VentaProducto.Server.Models.PruebaVentas.IN05 item);
        partial void OnAfterIN05Deleted(VentaProducto.Server.Models.PruebaVentas.IN05 item);

        [HttpDelete("/odata/PruebaVentas/IN05S(idIN05={idIN05})")]
        public IActionResult DeleteIN05(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.IN05S
                    .Where(i => i.idIN05 == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnIN05Deleted(item);
                this.context.IN05S.Remove(item);
                this.context.SaveChanges();
                this.OnAfterIN05Deleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnIN05Updated(VentaProducto.Server.Models.PruebaVentas.IN05 item);
        partial void OnAfterIN05Updated(VentaProducto.Server.Models.PruebaVentas.IN05 item);

        [HttpPut("/odata/PruebaVentas/IN05S(idIN05={idIN05})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutIN05(int key, [FromBody]VentaProducto.Server.Models.PruebaVentas.IN05 item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.idIN05 != key))
                {
                    return BadRequest();
                }
                this.OnIN05Updated(item);
                this.context.IN05S.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.IN05S.Where(i => i.idIN05 == key);
                ;
                this.OnAfterIN05Updated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/PruebaVentas/IN05S(idIN05={idIN05})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchIN05(int key, [FromBody]Delta<VentaProducto.Server.Models.PruebaVentas.IN05> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.IN05S.Where(i => i.idIN05 == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnIN05Updated(item);
                this.context.IN05S.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.IN05S.Where(i => i.idIN05 == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnIN05Created(VentaProducto.Server.Models.PruebaVentas.IN05 item);
        partial void OnAfterIN05Created(VentaProducto.Server.Models.PruebaVentas.IN05 item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] VentaProducto.Server.Models.PruebaVentas.IN05 item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnIN05Created(item);
                this.context.IN05S.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.IN05S.Where(i => i.idIN05 == item.idIN05);

                ;

                this.OnAfterIN05Created(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
