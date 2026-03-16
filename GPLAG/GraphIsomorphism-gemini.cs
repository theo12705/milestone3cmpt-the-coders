using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vflibcs;

namespace GPLAG_PD
{
    class GraphIsomorphism
    {
        ProgramDependencyGraph G;
        ProgramDependencyGraph G1;

        public GraphIsomorphism(ProgramDependencyGraph g, ProgramDependencyGraph g1)
        {
            this.G = g;
            this.G1 = g1;

            Graph gControlGraph = new Graph();
            Graph gDataGraph = new Graph();

            gControlGraph = BuildC(g);
            gDataGraph = BuildD(g);

            Graph g1ControlGraph = BuildC(g1);
            Graph g1DataGraph = BuildD(g1);
            
            VfState graphCompControl = new VfState(gControlGraph, g1ControlGraph, false, false);

            // FIXED: Replaced Match() with FMatch() which returns a boolean
            bool isControlMatch = graphCompControl.FMatch();

            if (isControlMatch)
            {
                // Check matching source 1 to 2
                bool Isomorphic = true;
                double unmappedNodes = 0;

                // FIXED: Grab the mapping array directly from VfState using Mapping1To2
                int[] controlMapping = graphCompControl.Mapping1To2;
                double totalNodes = controlMapping.Length;

                // Iterate directly over the mapped node IDs
                foreach (int mappedNode in controlMapping)
                {
                    // If the value is -1, it means there was no mapping found for this node
                    if (mappedNode == -1)
                    {
                        Isomorphic = false;
                        unmappedNodes++;
                    }
                }

                VfState graphCompData = new VfState(gDataGraph, g1DataGraph, false, false);

                // FIXED: Check data graph for match
                bool isDataMatch = graphCompData.FMatch();

                if (isDataMatch)
                {
                    // FIXED: Grab the mapping array directly from VfState using Mapping1To2
                    int[] dataMapping = graphCompData.Mapping1To2;
                    totalNodes += dataMapping.Length;

                    // Check matching source 1 to 2
                    foreach (int mappedNode in dataMapping)
                    {
                        if (mappedNode == -1)
                        {
                            Isomorphic = false;
                            unmappedNodes++;
                        }
                    }
                }

                Console.WriteLine("Perfectly Isomorphic: " + Isomorphic.ToString());
                Console.WriteLine("Percent similar: " + ((1.0 - (unmappedNodes / totalNodes)) * 100.0).ToString() + "%");
            }
            else
            {
                Console.WriteLine("Failed to detect matches.");
            }
        }

        private Graph BuildC(ProgramDependencyGraph g)
        {
            Graph graph = new Graph();
            Dictionary<int, int> gMap = new Dictionary<int, int>();

            // Add nodes to graph
            foreach (Node n in g.ControlGraph)
            {
                int id = graph.InsertNode(n.NodeType);
                gMap[n.ID] = id;
            }

            // Add control edges
            foreach (Node n in g.ControlGraph)
            {
                if (n.Children.Count > 0)
                {
                    foreach (Node child in n.Children)
                    {
                        graph.InsertEdge(gMap[n.ID], gMap[child.ID]);
                    }
                }
            }

            return graph;
        }

        private Graph BuildD(ProgramDependencyGraph g)
        {
            Graph graph = new Graph();
            Dictionary<int, int> gMap = new Dictionary<int, int>();

            // Add nodes to graph
            foreach (Node n in g.ControlGraph)
            {
                int id = graph.InsertNode(n.NodeType);
                gMap[n.ID] = id;
            }

            // Add control edges
            foreach (Node n in g.DataGraph)
            {
                if (n.Children.Count > 0)
                {
                    Node prevChild = n;
                    foreach (Node child in n.Children)
                    {
                        if (!gMap.ContainsKey(child.ID))
                        {
                            int id = graph.InsertNode(child.NodeType);
                            gMap[child.ID] = id;
                        }
                        if (!gMap.ContainsKey(prevChild.ID))
                        {
                            int id = graph.InsertNode(prevChild.NodeType);
                            gMap[prevChild.ID] = id;
                        }
                        try
                        {
                            graph.InsertEdge(gMap[prevChild.ID], gMap[child.ID]);
                        }
                        catch
                        {
                            Console.WriteLine("Edge Already Added");
                        }
                        prevChild = child;
                    }
                }
            }

            return graph;
        }
    }
}