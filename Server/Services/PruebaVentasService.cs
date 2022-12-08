using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using VentaProducto.Server.Data;

namespace VentaProducto.Server
{
    public partial class PruebaVentasService
    {
        PruebaVentasContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly PruebaVentasContext context;
        private readonly NavigationManager navigationManager;

        public PruebaVentasService(PruebaVentasContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportIiN04SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/iin04s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/iin04s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportIiN04SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/iin04s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/iin04s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnIiN04SRead(ref IQueryable<VentaProducto.Server.Models.PruebaVentas.IiN04> items);

        public async Task<IQueryable<VentaProducto.Server.Models.PruebaVentas.IiN04>> GetIiN04S(Query query = null)
        {
            var items = Context.IiN04S.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnIiN04SRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnIiN04Get(VentaProducto.Server.Models.PruebaVentas.IiN04 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IiN04> GetIiN04ById(int id)
        {
            var items = Context.IiN04S
                              .AsNoTracking()
                              .Where(i => i.id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnIiN04Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnIiN04Created(VentaProducto.Server.Models.PruebaVentas.IiN04 item);
        partial void OnAfterIiN04Created(VentaProducto.Server.Models.PruebaVentas.IiN04 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IiN04> CreateIiN04(VentaProducto.Server.Models.PruebaVentas.IiN04 iin04)
        {
            OnIiN04Created(iin04);

            var existingItem = Context.IiN04S
                              .Where(i => i.id == iin04.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.IiN04S.Add(iin04);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(iin04).State = EntityState.Detached;
                throw;
            }

            OnAfterIiN04Created(iin04);

            return iin04;
        }

        public async Task<VentaProducto.Server.Models.PruebaVentas.IiN04> CancelIiN04Changes(VentaProducto.Server.Models.PruebaVentas.IiN04 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnIiN04Updated(VentaProducto.Server.Models.PruebaVentas.IiN04 item);
        partial void OnAfterIiN04Updated(VentaProducto.Server.Models.PruebaVentas.IiN04 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IiN04> UpdateIiN04(int id, VentaProducto.Server.Models.PruebaVentas.IiN04 iin04)
        {
            OnIiN04Updated(iin04);

            var itemToUpdate = Context.IiN04S
                              .Where(i => i.id == iin04.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(iin04);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterIiN04Updated(iin04);

            return iin04;
        }

        partial void OnIiN04Deleted(VentaProducto.Server.Models.PruebaVentas.IiN04 item);
        partial void OnAfterIiN04Deleted(VentaProducto.Server.Models.PruebaVentas.IiN04 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IiN04> DeleteIiN04(int id)
        {
            var itemToDelete = Context.IiN04S
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnIiN04Deleted(itemToDelete);


            Context.IiN04S.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterIiN04Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportIN05SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/in05s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/in05s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportIN05SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/pruebaventas/in05s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/pruebaventas/in05s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnIN05SRead(ref IQueryable<VentaProducto.Server.Models.PruebaVentas.IN05> items);

        public async Task<IQueryable<VentaProducto.Server.Models.PruebaVentas.IN05>> GetIN05S(Query query = null)
        {
            var items = Context.IN05S.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnIN05SRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnIN05Get(VentaProducto.Server.Models.PruebaVentas.IN05 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IN05> GetIN05ByIdIn05(int idin05)
        {
            var items = Context.IN05S
                              .AsNoTracking()
                              .Where(i => i.idIN05 == idin05);

  
            var itemToReturn = items.FirstOrDefault();

            OnIN05Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnIN05Created(VentaProducto.Server.Models.PruebaVentas.IN05 item);
        partial void OnAfterIN05Created(VentaProducto.Server.Models.PruebaVentas.IN05 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IN05> CreateIN05(VentaProducto.Server.Models.PruebaVentas.IN05 in05)
        {
            OnIN05Created(in05);

            var existingItem = Context.IN05S
                              .Where(i => i.idIN05 == in05.idIN05)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.IN05S.Add(in05);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(in05).State = EntityState.Detached;
                throw;
            }

            OnAfterIN05Created(in05);

            return in05;
        }

        public async Task<VentaProducto.Server.Models.PruebaVentas.IN05> CancelIN05Changes(VentaProducto.Server.Models.PruebaVentas.IN05 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnIN05Updated(VentaProducto.Server.Models.PruebaVentas.IN05 item);
        partial void OnAfterIN05Updated(VentaProducto.Server.Models.PruebaVentas.IN05 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IN05> UpdateIN05(int idin05, VentaProducto.Server.Models.PruebaVentas.IN05 in05)
        {
            OnIN05Updated(in05);

            var itemToUpdate = Context.IN05S
                              .Where(i => i.idIN05 == in05.idIN05)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(in05);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterIN05Updated(in05);

            return in05;
        }

        partial void OnIN05Deleted(VentaProducto.Server.Models.PruebaVentas.IN05 item);
        partial void OnAfterIN05Deleted(VentaProducto.Server.Models.PruebaVentas.IN05 item);

        public async Task<VentaProducto.Server.Models.PruebaVentas.IN05> DeleteIN05(int idin05)
        {
            var itemToDelete = Context.IN05S
                              .Where(i => i.idIN05 == idin05)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnIN05Deleted(itemToDelete);


            Context.IN05S.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterIN05Deleted(itemToDelete);

            return itemToDelete;
        }
        }
}