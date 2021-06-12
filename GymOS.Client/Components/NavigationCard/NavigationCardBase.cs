using Microsoft.AspNetCore.Components;

namespace GymOS.Client.Components.NavigationCard
{
    public class NavigationCardBase : ComponentBase
    {
        [Parameter]
        public string Destination { get; set; }
    }
}
