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
    [Route("odata/PruebaVentas/IiN04S")]
    public partial class IiN04SController : ODataController
    {
        private VentaProducto.Server.Data.PruebaVentasContext context;

        public IiN04SController(VentaProducto.Server.Data.PruebaVentasContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<VentaProducto.Server.Models.PruebaVentas.IiN04> GetIiN04S()
        {
            var items = this.context.IiN04S.AsQueryable<VentaProducto.Server.Models.PruebaVentas.IiN04>();
            this.OnIiN04SRead(ref items);

            return items;
        }

        partial void OnIiN04SRead(ref IQueryable<VentaProducto.Server.Models.PruebaVentas.IiN04> items);

        partial void OnIiN04Get(ref SingleResult<VentaProducto.Server.Models.PruebaVentas.IiN04> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/PruebaVentas/IiN04S(id={id})")]
        public SingleResult<VentaProducto.Server.Models.PruebaVentas.IiN04> GetIiN04(int key)
        {
            var items = this.context.IiN04S.Where(i => i.id == key);
            var result = SingleResult.Create(items);

            OnIiN04Get(ref result);

            return result;
        }
        partial void OnIiN04Deleted(VentaProducto.Server.Models.PruebaVentas.IiN04 item);
        partial void OnAfterIiN04Deleted(VentaProducto.Server.Models.PruebaVentas.IiN04 item);

        [HttpDelete("/odata/PruebaVentas/IiN04S(id={id})")]
        public IActionResult DeleteIiN04(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.IiN04S
                    .Where(i => i.id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnIiN04Deleted(item);
                this.context.IiN04S.Remove(item);
                this.context.SaveChanges();
                this.OnAfterIiN04Deleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnIiN04Updated(VentaProducto.Server.Models.PruebaVentas.IiN04 item);
        partial void OnAfterIiN04Updated(VentaProducto.Server.Models.PruebaVentas.IiN04 item);

        [HttpPut("/odata/PruebaVentas/IiN04S(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutIiN04(int key, [FromBody]VentaProducto.Server.Models.PruebaVentas.IiN04 item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.id != key))
                {
                    return BadRequest();
                }
                this.OnIiN04Updated(item);
                this.context.IiN04S.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.IiN04S.Where(i => i.id == key);
                ;
                this.OnAfterIiN04Updated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/PruebaVentas/IiN04S(id={id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchIiN04(int key, [FromBody]Delta<VentaProducto.Server.Models.PruebaVentas.IiN04> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.IiN04S.Where(i => i.id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnIiN04Updated(item);
                this.context.IiN04S.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.IiN04S.Where(i => i.id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnIiN04Created(VentaProducto.Server.Models.PruebaVentas.IiN04 item);
        partial void OnAfterIiN04Created(VentaProducto.Server.Models.PruebaVentas.IiN04 item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] VentaProducto.Server.Models.PruebaVentas.IiN04 item)
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

                this.OnIiN04Created(item);
                this.context.IiN04S.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.IiN04S.Where(i => i.id == item.id);

                ;

                this.OnAfterIiN04Created(item);

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
