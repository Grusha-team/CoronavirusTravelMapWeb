using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class Edge
    {
       public Vertex ConnectedVertex { get; }
        
        public int edgeWeight { get;}
        public Edge(Vertex ConnectedVertex, int edgeWeight = 1)
        {
            this.ConnectedVertex = ConnectedVertex;
            this.edgeWeight = edgeWeight;
            
        }
    }
}
