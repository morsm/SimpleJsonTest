using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleJsonTest
{

    public class Lamp
    {
        public bool On { get; set; }
    }

    // TODO: error handling

    public class JsonClient
    {
        public async static Task<string> Post(string url, string body, string mimeType)
        {
            try
            {
                var client = new HttpClient();

                // Post the data
                var content = new StringContent(body, System.Text.Encoding.UTF8, mimeType);
                var result = await client.PostAsync(url, content);

                var stringResult = await result.Content.ReadAsStringAsync();
                return stringResult;

            } catch (Exception e)
            {
                return FormatError(e);
            }
        }

        public async static Task<string> Get(string url)
        {
            try
            {
                var client = new HttpClient();

                // Post the data
                var result = await client.GetAsync(url);

                var stringResult = await result.Content.ReadAsStringAsync();
                return stringResult;
            }
            catch (Exception e)
            {
                return FormatError(e);
            }
        }

        private static string FormatError(Exception e)
        {
            return String.Format("ERROR: {0}, message {1}", e.GetType().Name, e.Message);
        }
    }
}
