#pragma checksum "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80b80f61f209a26c9dc2370c535b8c14f4fbab92"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Initiation.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Initiation.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Initiation.Client.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 28 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
