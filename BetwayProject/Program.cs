using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BetwayProject
{
    internal class Program

        {


        static async Task Main(string[] args)
        {

            string url = "https://fixturedownload.com/feed/json/champions-league-2021";

            //MyTesting url HTTP Json Link . . .
            //string url = "https://my-json-server.typicode.com/typicode/demo/posts";


            // - -  A real http Client to send the get request (More like a target) - - - 
            //HttpClient httpClient = new HttpClient(<-WeThinkCode.API(~root(https://fixturedownload.com/feed/json/champions-league-2021)));
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                //Reading the string From the  response's content
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                Console.WriteLine(jsonResponse);
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                

                //Deserialize the json response into a C# array of type post[]
                var myPosts = JsonConvert.DeserializeObject<BetwayTestClass[]>(jsonResponse);


                //Print the array objects using foreach loop . . . Not for  loop
                foreach(var post in myPosts)
                {
                    //Print the items for which x Present . . .
                    Console.WriteLine("Group    :   " + post.Group  + "\n");
                    Console.WriteLine("Home-Team:   " + post.HomeTeam + "\n");
                    Console.WriteLine("HomeTeam Score: " + post.HomeTeamScore + "\n");
                    Console.WriteLine("Away-Team:   " + post.AwayTeam + "\n");
                    Console.WriteLine(post.AwayTeamScore + "\n");
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                //Print Message incase of an error
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                //Dispose HTTP Client
                httpClient.Dispose();
            }

            //  ######## U  Check out website yonopfi https://json2csharp.com/  . . . na  CodeBeautify.com   #######
        }
    }
}
