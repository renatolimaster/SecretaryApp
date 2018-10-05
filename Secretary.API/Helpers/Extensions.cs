using System;
using Microsoft.AspNetCore.Http;

namespace Secretary.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime? theDateTime)
        {
            
            var age = 0;
            if (theDateTime.HasValue)
            {
                age = DateTime.Today.Year - theDateTime.Value.Year;
                if (theDateTime.Value.AddYears(age) > DateTime.Today)
                    age--;
            }
            return age;
        }

        
    }
}