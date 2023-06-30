using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_handling
{
    public class AsyncAwait
    {
        public async Task<int> AyncAwaitSample ()
        {
            await Task.Delay (3000);
            Console.WriteLine("AyncAwaitSample After delay of 3 sec");
            return 1;
        }

        public async Task FetchDataAsync()
        {
            string apiUrl = "https://reqres.in/api/users?page=1";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(data);
                    }
                    else
                    {
                        Console.WriteLine("Request failed with status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

    }
}
