#pragma checksum "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\Forms\MyInputrazor.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be67140d285d67e27de4a3c959baf86c77ae34ff"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Initiation.Client.Shared.Forms
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
#line 12 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\_Imports.razor"
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\Forms\MyInputrazor.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\Forms\MyInputrazor.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
    public partial class MyInputrazor : InputBase<string>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Shared\Forms\MyInputrazor.razor"
       
    [Parameter]
    public string AutoComplete { get; set; }

    [Parameter]
    public string Type { get; set; }

    protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
