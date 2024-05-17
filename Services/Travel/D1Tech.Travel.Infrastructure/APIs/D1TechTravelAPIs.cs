using D1Tech.Travel.Infrastructure.Shared;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D1Tech.Travel.Infrastructure.APIs
{
    public static class D1TechTravelAPIs
    {
        static readonly string ipAddress = "localhost";

        public static async Task<T> GetTravelById<T>(int id)
        {
            var response = await $"https://{ipAddress}:44372/api/Travel/GetTravelById?id={id}".GetJsonAsync<ResponseInfra<T>>();

            return response.Data;
        }
    }
}
