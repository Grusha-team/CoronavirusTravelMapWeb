using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class GraphBuilder
    {
        Dictionary<string, string> Countries;
        public GraphBuilder(Dictionary<string,string> countries)
        {
            this.Countries = countries;
        }
        public Graph BuildGraph()
        {
            Graph graph = new Graph();
            foreach (var name in Countries.Keys)
            {
                graph.AddVertex(name);
            }
            foreach (var c in Countries)
            {
                foreach (var d in c.Value.Split())
                {
                    graph.AddEdge(c.Key, d);
                }
            
            }
            return graph;
        
        }
    }
}
