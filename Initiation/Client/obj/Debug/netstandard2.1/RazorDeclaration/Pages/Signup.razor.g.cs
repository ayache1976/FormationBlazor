#pragma checksum "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37da723a1dd4f89021a50be96410ee2cc70714e3"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Initiation.Client.Pages
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
#line 8 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using Initiation.Shared.Dto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using Initiation.Client.Services.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using Initiation.Client.Services.Js;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using Initiation.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/signup")]
    public partial class Signup : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 87 "F:\Dev\Source\Repos\BlazorInitiation\Initiation\Initiation\Client\Pages\Signup.razor"
       
    private DtoUser model = new DtoUser();

    private static System.Globalization.TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
    private bool? swAvailable = null;

    private async Task HandleValidSubmit()
    {
        var response = await HttpUserService.PostRegister(model);
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                await JsAlertifyService.Open($"Utilisateur &laquo; {textInfo.ToTitleCase(model.UserName)} &raquo; cr&eacute;e", TypeAlertify.Success);
                MyNavigationManager.NavigateTo("/");
                break;
            default:
                await JsAlertifyService.Open($"Erreur de creation de l'utilisateur : { await response.Content.ReadAsStringAsync()}", TypeAlertify.Error);
                break;
        }
    }

    protected override void OnInitialized()
    {
        model.ValueChanged += CheckIfUserNameAvailableEvent;
        if (Storage["token"] != null || Storage["username"] != null)
            MyNavigationManager.NavigateTo("/");
    }

    public async void CheckIfUserNameAvailableEvent(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(model.UserName))
            swAvailable = null;
        else
        {
            var dtoAvailable = new DtoUserForLogin
            {
                UserName = model.UserName
            };
            swAvailable = await HttpUserService.PostAvailable(dtoAvailable);
        }

        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJsAlertifyService JsAlertifyService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpUserService HttpUserService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager MyNavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private LocalStorage Storage { get; set; }
    }
}
#pragma warning restore 1591