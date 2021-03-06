﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.GssKerberos.Test
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var result = await context.AuthenticateAsync(GssAuthenticationDefaults.AuthenticationScheme);
            if(!result.Succeeded)
                await context.ChallengeAsync(GssAuthenticationDefaults.AuthenticationScheme);

            context.Response.WriteAsync("hello");
        }
    }
}
