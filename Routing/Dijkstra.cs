using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class Dijkstra
    {
        Graph graph;

        List<GraphVertexInfo> infos;

     
        public Dijkstra(Graph graph)
        {
            this.graph = graph;
        }
        void InitInfo()
        {
            infos = new List<GraphVertexInfo>();
            foreach (var v in graph.Vertexes)
            {
                infos.Add(new GraphVertexInfo(v));
            }
        }

       
        GraphVertexInfo GetVertexInfo(Vertex v)
        {
            foreach (var i in infos)
            {
                if (i.Vertex.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }

       
        public GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }

            return minVertexInfo;
        }

  
        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
        }

        
        public string FindShortestPath(Vertex startVertex, Vertex finishVertex)
        {   
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startVertex, finishVertex);
        }

      
        void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Vertex.Edges)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = info.EdgesWeightSum + e.edgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }

        string GetPath(Vertex startVertex, Vertex endVertex)
        {
            var path = endVertex.name;
            while (startVertex != endVertex)
            {
                if (endVertex == null)
                    return null;
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                if (endVertex == null)
                    return null;
                path = endVertex.name + " " + path;
            }

            return path;
        }
    }
}
