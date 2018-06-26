using System;
using System.Net.Http;
using System.IO;
namespace TransferSH
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length == 1 == false){
                Console.WriteLine("Specify a single file!");
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("PUT"), "https://transfer.sh/"+ args[0]))
                    {
                        request.Content = new ByteArrayContent(File.ReadAllBytes(args[0])); 
                        var response = httpClient.SendAsync(request).Result;
                        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }
    }
}
