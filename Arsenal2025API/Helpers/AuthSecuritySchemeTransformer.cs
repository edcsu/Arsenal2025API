using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace Arsenal2025API.Helpers;

public sealed class AuthSecuritySchemeTransformer(IAuthenticationSchemeProvider authenticationSchemeProvider) : IOpenApiDocumentTransformer
{
    public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();
        var requirements = new Dictionary<string, OpenApiSecurityScheme>();

        if (authenticationSchemes.Any(authScheme => authScheme.Name == "Bearer"))
        {
            requirements.Add("Bearer",  new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                In = ParameterLocation.Header,
                BearerFormat = "Json Web Token"
            });
        }
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes = requirements;
    }
}