using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hamad.Components
{
    public class ConfirmBase: ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete Confimration";

        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete?";

        [Parameter]
        public EventCallback<bool> ConfirmationChagned { get; set; }
        public async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChagned.InvokeAsync(value);
        }
    }
}
