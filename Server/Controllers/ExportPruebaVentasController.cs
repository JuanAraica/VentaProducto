using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using VentaProducto.Server.Data;

namespace VentaProducto.Server.Controllers
{
    public partial class ExportPruebaVentasController : ExportController
    {
        private readonly PruebaVentasContext context;
        private readonly PruebaVentasService service;

        public ExportPruebaVentasController(PruebaVentasContext context, PruebaVentasService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/PruebaVentas/iin04s/csv")]
        [HttpGet("/export/PruebaVentas/iin04s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportIiN04SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetIiN04S(), Request.Query), fileName);
        }

        [HttpGet("/export/PruebaVentas/iin04s/excel")]
        [HttpGet("/export/PruebaVentas/iin04s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportIiN04SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetIiN04S(), Request.Query), fileName);
        }

        [HttpGet("/export/PruebaVentas/in05s/csv")]
        [HttpGet("/export/PruebaVentas/in05s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportIN05SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetIN05S(), Request.Query), fileName);
        }

        [HttpGet("/export/PruebaVentas/in05s/excel")]
        [HttpGet("/export/PruebaVentas/in05s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportIN05SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetIN05S(), Request.Query), fileName);
        }
    }
}
