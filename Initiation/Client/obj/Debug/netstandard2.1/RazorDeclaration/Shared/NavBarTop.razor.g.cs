#pragma checksum "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\NavBarTop.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18ebbafe1d44664cf2a3c01d6d3ce83a0a9d2c43"
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
#nullable restore
#line 10 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Initiation.Client.Shared.Bulma;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Initiation.Client.Shared.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\NavBarTop.razor"
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\NavBarTop.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
    public partial class NavBarTop : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 67 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\NavBarTop.razor"
       
    string toogleClass = "";
    private static TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

    void ToogleNavBar()
    {
        if (toogleClass == "")
            toogleClass = "is-active";
        else
            toogleClass = "";
    }

    async void Logout()
    {
        Storage.RemoveItem("username");
        Storage.RemoveItem("token"); 
        MyNavigationManager.NavigateTo("/");
        await JSRuntime.InvokeAsync<bool>("Refresh");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private LocalStorage Storage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager MyNavigationManager { get; set; }
    }
}
#pragma warning restore 1591
