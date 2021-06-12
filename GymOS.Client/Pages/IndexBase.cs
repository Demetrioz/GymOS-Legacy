using Microsoft.AspNetCore.Components;

namespace GymOS.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected void HandleJoin()
        {
            NavigationManager.NavigateTo("/Counter");
        }
    }
}
