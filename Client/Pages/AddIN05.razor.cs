using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace VentaProducto.Client.Pages
{
    public partial class AddIN05
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }
        [Inject]
        public PruebaVentasService PruebaVentasService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            iN05 = new VentaProducto.Server.Models.PruebaVentas.IN05();
        }
        protected bool errorVisible;
        protected VentaProducto.Server.Models.PruebaVentas.IN05 iN05;

        protected async Task FormSubmit()
        {
            try
            {
                await PruebaVentasService.CreateIN05(iN05);
                DialogService.Close(iN05);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}