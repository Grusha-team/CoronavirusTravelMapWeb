
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public sealed class Graph
    {
        public List<Vertex> Vertexes { get; }
        public Graph()
        {
            Vertexes = new List<Vertex>();
        }
        public void AddVertex(string name)
        {
            Vertexes.Add(new Vertex(name));
        }
        public Vertex FindVertex(string name)
        {
            foreach (var vertex in Vertexes)
            {
                if (vertex.name.Equals(name))
                {
                    return vertex;
                }
            }
            return null;
        }
        public void AddEdge(string firstname, string secondname)
        {
            var v1 = FindVertex(firstname);
            var v2 = FindVertex(secondname);
            if (v1 != null && v2 != null)
            {
                v2.AddEdge(new Edge(v1));
            }
        
        
        
        }
    }
}
