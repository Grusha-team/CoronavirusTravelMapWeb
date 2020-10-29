using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using GetData;
using Newtonsoft.Json;

namespace CoronavirusTravelBackendApi
{
    public class Hub
    {
        public static GetDataa getData;
        public static GraphBuilder graphBuilder;
        public static Graph graph;
        public static Dijkstra routeFinder;
        public static List<Country> countries;
        void Init()
        {
            getData = new GetDataa();
            getData.Login();
            countries = getData.GetListOfCountries();
            graphBuilder = new GraphBuilder(getData.GetCountries());
            graph = graphBuilder.BuildGraph();
            routeFinder = new Dijkstra(graph);

        }
        public Hub()
        {
            if (getData == null || graphBuilder == null
               || graph == null || routeFinder == null
               || countries == null)
            {
                Init();
            }

        }
        public string FindRoute(string start, string finish)
        {
            var path = routeFinder.FindShortestPath(start, finish);
            List<Country> countries = new List<Country>();
            if (path != null)
            {
                var route = path.Split().ToList();
                foreach (var c in route)
                {
                    countries.Add(AssociateCountry(c));
                }
            }
            
            return countries.Count() != 0 ? JsonConvert.SerializeObject(countries) : JsonConvert.SerializeObject(path?.Split().ToList());
        }

        public Country AssociateCountry(string name) => countries.Find(x => x.name == name);
        


    }

}
