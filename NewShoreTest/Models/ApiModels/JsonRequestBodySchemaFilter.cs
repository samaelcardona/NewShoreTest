using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NewShoreTest.Models.ApiModels
{
    public class JsonRequestBodySchemaFilter <T> : ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(T))
            {
                schema.Example = new OpenApiObject
                {
                    ["Origin"] = new OpenApiString("MZL"),
                    ["Destination"] = new OpenApiString("BCN")
                };
            }
        }

    }
}
