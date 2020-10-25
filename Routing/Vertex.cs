using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public sealed class Vertex
    {   public string name {  get;  }
        public List<Edge> Edges { get; }
        
        
        public Vertex(string name)
        {   
            this.name = name;
            Edges = new List<Edge>();
        }
        public void AddEdge(Edge newEdge)
        {
            Edges.Add(newEdge);
        }
    }
}
