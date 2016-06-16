using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /*
    * A representation of an edge from a source vertex to a target vertex
    * with a weight(cost)
    * */
    public class DirectedEdge
    {
        private readonly int _sourceVertex;
        private readonly int _targetVertex;
        private readonly double _weight;

        public DirectedEdge(int sourceVertex, int targetVertex, double weight)
        {
            this._sourceVertex = sourceVertex;
            this._targetVertex = targetVertex;
            this._weight = weight;
        }

        public double Weight()
        {
            return _weight;
        }

        public int From()
        {
            return _sourceVertex;
        }

        public int To()
        {
            return _targetVertex;
        }

        public override string ToString()
        {
            return String.Format("{0:d}->{1:d} {2:f}", _sourceVertex, _targetVertex, _weight);
        }
    }
    
    /// <summary>
    /// Implementation of an edge weighted directed graph
    /// </summary>
    public class EdgeWeightedDirectedGraph
    {
        private readonly int _totalVertices;
        private int _totalEdges;
        private LinkedList<DirectedEdge>[] _adjacencyList;

        public EdgeWeightedDirectedGraph(int totalVertices)
        {
            this._totalVertices = totalVertices;
            this._totalEdges = 0;
            /*
            * create 'totalVertices' linked lists; one for each vertex, which keeps track
            * of the edge from v to other vertices v 
            * */
            _adjacencyList = new LinkedList<DirectedEdge>[totalVertices];
            for (int i = 0; i < _totalVertices; i++)
            {
                _adjacencyList[i] = new LinkedList<DirectedEdge>();
            }
        }

        public int TotalVertices()
        {
            return _totalVertices;
        }

        public int TotalEdges()
        {
            return _totalEdges;
        }

        //Add an edge at the start of the linked list and increase the edge count
        public void AddEdge(DirectedEdge e)
        {
            _adjacencyList[e.From()].AddFirst(e);
            _totalEdges++;
        }

        public IEnumerable<DirectedEdge> GetAdjacencyList(int v)
        {
            return _adjacencyList[v];
        }

        public IEnumerable<DirectedEdge> GetAllEdges()
        {
            LinkedList<DirectedEdge> allEdges = new LinkedList<DirectedEdge>();
            for (int i = 0; i < _totalVertices; i++)
            {
                foreach (DirectedEdge e in _adjacencyList[i])
                    allEdges.AddFirst(e);
            }
            return allEdges;
        }
    }
}
