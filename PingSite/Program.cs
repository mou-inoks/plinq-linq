using System.Net.NetworkInformation;
using static System.Net.WebRequestMethods;

namespace PingSite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Normal 
            List<string> sites = new List<string>
            {
                "www.google.fr",
                "www.aspsnippets.com",
                "edu.ge.ch",
                "ge.ch",
                "disarmament.unoda.org",
                "laoevisa.gov.la",
                "www.yahoo.com",
                "www.google.com",
                "www.yahoo.fr"
            };

            //for (int i = 0; i < sites.Count; i++)
            //{
            //    var s = DoPing(sites[i]);
            //    Console.WriteLine(s.Address + ": " + s.RoundtripTime + ": " + s.Status);

            //}

            //LINQ 
            //sites.ForEach(x =>
            //{
            //    var s = DoPing(x);
            //    Console.WriteLine(s.Address + ": " + s.RoundtripTime + ": " + s.Status);
            //});

            //PLINQ
           var t = from site in sites.AsParallel()
                   select site;
            t.ForAll(x =>
            {
                var s = DoPing(x);
                Console.WriteLine(s.Address + ": " + s.RoundtripTime + ": " + s.Status);
            }); 
                   
        }

        static private PingReply DoPing(string site)
        {
            Ping p = new Ping();
            return p.Send(site);
        }
    }
}