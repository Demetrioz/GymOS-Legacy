using Microsoft.AspNetCore.Components;
using System;

namespace GymOS.Client.Components.PrimaryButton
{
    public class PrimaryButtonBase : ComponentBase
    {
        [Parameter]
        public string Text { get; set; } = "Click Me!";

        [Parameter]
        public Action ClickAction { get; set; }

        protected void HandleClick()
        {
            if (ClickAction != null)
                ClickAction.Invoke();
        }
    }
}
