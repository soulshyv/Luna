using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ERDF_DispoReseau.Commons.Csp
{
    public class CspMiddleware
    {
        private const string HEADER = "Content-Security-Policy";
        private readonly RequestDelegate next;
        private readonly CspOptions options;

        public CspMiddleware(
            RequestDelegate next, CspOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HEADER, GetHeaderValue());
            await next(context);
        }

        private string GetHeaderValue()
        {
            var value = "";
            value += GetDirective("default-src", options.Defaults);
            value += GetDirective("script-src", options.Scripts);
            value += GetDirective("style-src", options.Styles);
            value += GetDirective("img-src", options.Images);
            value += GetDirective("font-src", options.Fonts);
            value += GetDirective("media-src", options.Media);
            return value;
        }

        private string GetDirective(string directive, List<string> sources)
            => sources.Count > 0 ? $"{directive} {string.Join(" ", sources)}; " : "";
    }
    
    public static class CspMiddlewareExtensions
    {
        public static IApplicationBuilder UseCsp(
            this IApplicationBuilder app, Action<CspOptionsBuilder> builder)
        {
            var newBuilder = new CspOptionsBuilder();
            builder(newBuilder);

            var options = newBuilder.Build();
            return app.UseMiddleware<CspMiddleware>(options);
        }
    }
}