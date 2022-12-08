
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace VentaProducto.Client
{
    public partial class PruebaVentasService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public PruebaVentasService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/PruebaVentas/");
        }


        public async System.Threading.Tasks.Task ExportIiN04SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/iin04s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/iin04s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportIiN04SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/iin04s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/iin04s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetIiN04S(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<VentaProducto.Server.Models.PruebaVentas.IiN04>> GetIiN04S(Query query)
        {
            return await GetIiN04S(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<VentaProducto.Server.Models.PruebaVentas.IiN04>> GetIiN04S(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"IiN04S");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetIiN04S(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VentaProducto.Server.Models.PruebaVentas.IiN04>>(response);
        }

        partial void OnCreateIiN04(HttpRequestMessage requestMessage);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IiN04> CreateIiN04(VentaProducto.Server.Models.PruebaVentas.IiN04 iiN04 = default(VentaProducto.Server.Models.PruebaVentas.IiN04))
        {
            var uri = new Uri(baseUri, $"IiN04S");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(iiN04), Encoding.UTF8, "application/json");

            OnCreateIiN04(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VentaProducto.Server.Models.PruebaVentas.IiN04>(response);
        }

        partial void OnDeleteIiN04(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteIiN04(int id = default(int))
        {
            var uri = new Uri(baseUri, $"IiN04S({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteIiN04(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetIiN04ById(HttpRequestMessage requestMessage);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IiN04> GetIiN04ById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"IiN04S({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetIiN04ById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VentaProducto.Server.Models.PruebaVentas.IiN04>(response);
        }

        partial void OnUpdateIiN04(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateIiN04(int id = default(int), VentaProducto.Server.Models.PruebaVentas.IiN04 iiN04 = default(VentaProducto.Server.Models.PruebaVentas.IiN04))
        {
            var uri = new Uri(baseUri, $"IiN04S({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(iiN04), Encoding.UTF8, "application/json");

            OnUpdateIiN04(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportIN05SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/in05s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/in05s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportIN05SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/in05s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/in05s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetIN05S(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<VentaProducto.Server.Models.PruebaVentas.IN05>> GetIN05S(Query query)
        {
            return await GetIN05S(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<VentaProducto.Server.Models.PruebaVentas.IN05>> GetIN05S(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"IN05S");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetIN05S(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VentaProducto.Server.Models.PruebaVentas.IN05>>(response);
        }

        partial void OnCreateIN05(HttpRequestMessage requestMessage);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IN05> CreateIN05(VentaProducto.Server.Models.PruebaVentas.IN05 in05 = default(VentaProducto.Server.Models.PruebaVentas.IN05))
        {
            var uri = new Uri(baseUri, $"IN05S");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(in05), Encoding.UTF8, "application/json");

            OnCreateIN05(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VentaProducto.Server.Models.PruebaVentas.IN05>(response);
        }

        partial void OnDeleteIN05(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteIN05(int idIn05 = default(int))
        {
            var uri = new Uri(baseUri, $"IN05S({idIn05})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteIN05(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetIN05ByIdIn05(HttpRequestMessage requestMessage);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IN05> GetIN05ByIdIn05(string expand = default(string), int idIn05 = default(int))
        {
            var uri = new Uri(baseUri, $"IN05S({idIn05})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetIN05ByIdIn05(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VentaProducto.Server.Models.PruebaVentas.IN05>(response);
        }

        partial void OnUpdateIN05(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateIN05(int idIn05 = default(int), VentaProducto.Server.Models.PruebaVentas.IN05 in05 = default(VentaProducto.Server.Models.PruebaVentas.IN05))
        {
            var uri = new Uri(baseUri, $"IN05S({idIn05})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(in05), Encoding.UTF8, "application/json");

            OnUpdateIN05(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}