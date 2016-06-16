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
        private readonly int _source;//The source vertex
        private readonly int _target;//The target vertex
        private readonly double _weight;//The weight to go from _v to _w

        //Create a directed edge from v to w with weight 'weight'
        public DirectedEdge(int v, int w, double weight)
        {
            this._source = v;
            this._target = w;
            this._weight = weight;
        }

        //Return the weight
        public double Weight()
        {
            return _weight;
        }

        //Return the source vertex
        public int From()
        {
            return _source;
        }

        //Return the target vertex
        public int To()
        {
            return _target;
        }

        //Return a string representation of the edge
        public override string ToString()
        {
            return String.Format("{0:d}->{1:d} {2:f}", _source, _target, _weight);
        }
    }
    /*
    * Implementation of an edge weighted directed graph
    * */
    public class EdgeWeightedDirectedGraph
    {
        private readonly int _totalVertices; //The number of vertices
        private int _totalEdges;//The number of edges
        private LinkedList<DirectedEdge>[] _adjacencyList;//A linked list representation of the adjacency lists

        /*
        * Create an edge weighted directed graph with V vertices
        * */
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

        /*
        * Add an edge at the start of the linked list 
        * and increase the edge count
        * */
        public void AddEdge(DirectedEdge e)
        {
            _adjacencyList[e.From()].AddFirst(e);
            _totalEdges++;
        }

        //Iterate through the vertices linked lists
        public IEnumerable<DirectedEdge> GetAdjacencyList(int v)
        {
            return _adjacencyList[v];
        }

        //Iterate through all edges
        public IEnumerable<DirectedEdge> Edges()
        {
            LinkedList<DirectedEdge> linkedlist = new LinkedList<DirectedEdge>();
            for (int v = 0; v < _totalVertices; v++)
            {
                foreach (DirectedEdge e in _adjacencyList[v])
                    linkedlist.AddFirst(e);
            }
            return linkedlist;
        }
    }
}
