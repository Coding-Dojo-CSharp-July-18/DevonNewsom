using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SessionTimes
{
    public static class MyFunnyExtensions
    {
        public static string AwesomeFormatter(this DateTime dt)
        {
            return dt.ToString("F");
        }

        public static void SetFunnyObjectInSession(this ISession sesh, string key, object value)
        {
            sesh.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetFunnyObjectFromSession<T>(this ISession sesh, string key)
        {
            // Crazy Ternary Return Statement!!!
            // it goes like this:
        
            //     (if this evaluates to true..) ? return this : otherwise return this
            return (sesh.GetString(key) == null) ? default(T)  : JsonConvert.DeserializeObject<T>(key); 
        }
    }
}