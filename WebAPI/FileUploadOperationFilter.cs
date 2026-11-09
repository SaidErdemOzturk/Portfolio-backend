using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var formFileParams = context.MethodInfo.GetParameters()
                .Where(p => p.ParameterType == typeof(IFormFile)
                         || typeof(IEnumerable<IFormFile>).IsAssignableFrom(p.ParameterType)
                         || p.ParameterType.GetProperties().Any(prop => prop.PropertyType == typeof(IFormFile)))
                .ToList();

            if (!formFileParams.Any())
                return;

            var properties = new Dictionary<string, OpenApiSchema>();
            var required = new HashSet<string>();

            foreach (var parameter in context.MethodInfo.GetParameters())
            {
                if (parameter.ParameterType == typeof(IFormFile))
                {
                    properties[parameter.Name!] = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "binary"
                    };
                    required.Add(parameter.Name!);
                }
                else if (parameter.ParameterType == typeof(int) || parameter.ParameterType == typeof(int?))
                {
                    properties[parameter.Name!] = new OpenApiSchema
                    {
                        Type = "integer",
                        Format = "int32"
                    };
                }
                else if (parameter.ParameterType == typeof(string))
                {
                    properties[parameter.Name!] = new OpenApiSchema
                    {
                        Type = "string"
                    };
                }
                else if (parameter.ParameterType.IsClass && parameter.ParameterType != typeof(string))
                {
                    foreach (var prop in parameter.ParameterType.GetProperties())
                    {
                        if (prop.PropertyType == typeof(IFormFile))
                        {
                            properties[prop.Name] = new OpenApiSchema
                            {
                                Type = "string",
                                Format = "binary"
                            };
                            required.Add(prop.Name);
                        }
                        else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                        {
                            properties[prop.Name] = new OpenApiSchema
                            {
                                Type = "integer",
                                Format = "int32"
                            };
                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            properties[prop.Name] = new OpenApiSchema
                            {
                                Type = "string"
                            };
                        }
                    }
                }
            }

            operation.RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["multipart/form-data"] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties = properties,
                            Required = required
                        }
                    }
                }
            };
        }
    }
}

