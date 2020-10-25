using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class GraphVertexInfo
    {
        
        public Vertex Vertex { get; set; }

    
        public bool IsUnvisited { get; set; }

        public int EdgesWeightSum { get; set; }

    
        public Vertex PreviousVertex { get; set; }

        public GraphVertexInfo(Vertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PreviousVertex = null;
        }
    }
}
