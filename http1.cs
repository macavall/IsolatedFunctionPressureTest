using System;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace IsolatedPressureTest
{
    public class http1
    {
        //public static byte[] MemoryLeak;
        public static int counter = 0;
        public static int limit = Convert.ToInt32(Environment.GetEnvironmentVariable("limit"));

        [Function("http1")]
        public string Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            //MemoryLeak = new byte[1024 * 1024 * 100];

            //for (int i = 0; i < MemoryLeak.Length; i++)
            //{
            //    MemoryLeak[i] = 1;
            //}

            if (counter++ > limit)
            {
                StackOverflow();
            }


            //for (int i = 0; i < 999999999; i++)
            //{
            //    //_logger.LogInformation("C# HTTP trigger function processed a request.");

            //    http1.Run(req);
            //}

            return "test";
        }

        public void StackOverflow()
        {
            StackOverflow();
        }
    }
}
