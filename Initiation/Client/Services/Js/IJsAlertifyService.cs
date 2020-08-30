using Initiation.Client.Helpers;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiation.Client.Services.Js
{
    public interface IJsAlertifyService
    {
        Task Open(string message, TypeAlertify type);
    }
    public class JsAlertifyService : IJsAlertifyService
    {
        private readonly IJSRuntime _jSRuntime;
        public JsAlertifyService(IJSRuntime jSRuntime) 
        { 
                _jSRuntime = jSRuntime; 
        }
        public async Task Open(string message, TypeAlertify type)
        {
            switch (type)
            {
                case TypeAlertify.Success:
                    await _jSRuntime.InvokeAsync<bool>("Alertify", message, "Success", 5);
                    break;
                case TypeAlertify.Error:
                    await _jSRuntime.InvokeAsync<bool>("Alertify", message, "Error", 5);
                    break;
                case TypeAlertify.Wraning:
                    await _jSRuntime.InvokeAsync<bool>("Alertify", message, "Wraning", 5);
                    break;
                case TypeAlertify.Default:
                    await _jSRuntime.InvokeAsync<bool>("Alertify", message);
                    break;

            }
        }
    }
}
