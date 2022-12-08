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
    public partial class AddIiN04
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
            iiN04 = new VentaProducto.Server.Models.PruebaVentas.IiN04();
        }
        protected bool errorVisible;
        protected VentaProducto.Server.Models.PruebaVentas.IiN04 iiN04;

        protected async Task FormSubmit()
        {
            try
            {
                await PruebaVentasService.CreateIiN04(iiN04);
                DialogService.Close(iiN04);
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