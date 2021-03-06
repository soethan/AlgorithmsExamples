﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlgorithmsExamples.Extensions;
using System.Diagnostics;
using System.ComponentModel;

namespace AlgorithmsExamples
{
    interface ITestInterface1
    {
        void Show();
    }

    interface ITestInterface2
    {
        void Show();
    }

    class Abc : ITestInterface1, ITestInterface2
    {
        void ITestInterface1.Show()
        {
            Console.WriteLine("For testInterface1 !!");
        }
        void ITestInterface2.Show()
        {
            Console.WriteLine("For testInterface2 !!");
        }
    }

    class Program
    {
        public static decimal RoundDown(decimal i, double decimalPlaces = 2)
        {
            ITestInterface1 obj1 = new Abc();
            ITestInterface2 obj2 = new Abc();
            obj1.Show();
            obj2.Show();

            decimal power = (decimal)Math.Pow(10, decimalPlaces);
            return Math.Floor(i * power) / power;
        }

        static void Main(string[] args)
        {
            string myStr = "123456";
            Console.WriteLine(myStr.GetFirst3Letters());

            decimal result = RoundDown(100.78999m);
            Console.WriteLine(string.Format("{0}", result));

            #region Binary Search Tree

            TreeNode root = null;
            BinarySearchTree bst = new BinarySearchTree();

            //int[] a = new int[8]{10, 9, 12, 11, 16, 14, 20, 15};
            int[] a = new int[7] { 10, 9, 12, 11, 16, 20, 21 };

            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + ",");
            }

            watch.Stop();
            
            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Filling the tree with {0} nodes...", a.Length);

            watch = Stopwatch.StartNew();

            for (int i = 0; i < a.Length; i++)
            {
                root = bst.Insert(root, a[i]);
            }

            watch.Stop();
            
            Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("\nTraversing all {0} nodes in tree...", a.Length);

            watch = Stopwatch.StartNew();

            bst.Traverse(root);

            watch.Stop();
            ///////////////////////////////////////////////////////////////////

            bst.Delete(12);
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("\nTraversing all {0} nodes AFTER DELETE in tree...", a.Length);

            watch = Stopwatch.StartNew();

            bst.Traverse(root);

            watch.Stop();
            ///////////////////////////////////////////////////////////////////

            Console.WriteLine("\nDone. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);

            Console.WriteLine("Contains 3 = " + bst.Contains(root, 3));
            Console.WriteLine("Contains 11 = " + bst.Contains(root, 11));


            Console.WriteLine();

            #endregion

            #region Tasks

            //ThreadingSamples.ThreadingWithTask();
            //ThreadingSamples.ThreadingWithParallel();
            //DeadLock.ExecuteDeadlockAvoidance();
            //AutoManualResetEventSample.Init();

            #endregion

            #region Point inside Rectangle

            var pointCal = new PointInsideRectangleCalculator(
                new Point(1, 4), new Point(5, 4), new Point(5, 1), new Point(1, 1)
            );

            Console.WriteLine(pointCal.IsWithinRectangle(new Point(2, 0.5)));
            Console.WriteLine(pointCal.IsWithinRectangle(new Point(2, 1)));
            Console.WriteLine(pointCal.IsWithinRectangle(new Point(2, 1.5)));

            #endregion

            #region Hash Dummy

            Console.WriteLine(HashLib.GetHashedValue("Aaa"));
            Console.WriteLine(HashLib.GetHashedValue("Aba"));
            Console.WriteLine(HashLib.GetHashedValue("Bbb"));
            Console.WriteLine(HashLib.GetHashedValue("Ccc"));
            Console.WriteLine(HashLib.GetHashedValue("Cdc"));

            #endregion

            #region Number Translation

            Console.WriteLine(NumberDisplay.GetNumberText("1123456789"));
            Console.WriteLine(NumberDisplay.GetNumberText("12456789"));
            Console.WriteLine(NumberDisplay.GetNumberText("1456789"));
            Console.WriteLine(NumberDisplay.GetNumberText("1001123456789"));
            Console.WriteLine(NumberDisplay.GetNumberText("1000123456789"));

            #endregion

            #region Queue and Stack

            try
            {
                var queue = new Queue();
                queue.Enqueue("1");
                queue.Enqueue("2");
                queue.Enqueue("3");
                queue.Enqueue("4");
                queue.Enqueue("5");
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
                queue.Enqueue("6");
                queue.Enqueue("7");
                queue.Enqueue("8");
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
                queue.Dequeue();
                queue.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var stack = new Stack();
                stack.Push("1");
                stack.Push("2");
                stack.Push("3");
                stack.Push("4");
                stack.Push("5");
                stack.Display();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Display();
                stack.Push("3");
                stack.Push("4");
                stack.Push("5");
                stack.Display();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Searching

            int[] sortedNumbers = new int[] { 10, 13, 14, 15, 19, 55, 56 };
            var searchAlgorithm = new BinarySearch();
            var index = searchAlgorithm.Search(sortedNumbers, 55);
            if(index < 0)
                Console.WriteLine("Not found");
            else
                Console.WriteLine(string.Format("Found at {0}", index));

            #endregion

            #region Sorting

            Console.Write("\n************ Sorting ************");
            Console.Write("\n\nEnter number of elements: ");

            int totalElements = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[totalElements];

            for (int i = 0; i < totalElements; i++)
            {
                Console.Write("\nEnter [" + (i + 1).ToString() + "] element: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Before Sorting: ");
            Console.Write("\n");

            for (int k = 0; k < totalElements; k++)
            {
                Console.Write(numbers[k] + " ");
            }
            Console.Write("\n");

            Console.WriteLine("After Sorting:");

            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.QuickSort);
            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.BubbleSort);
            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.InsertionSort);
            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.MergeSort);
            //var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.MergeSortWithLinkedList);
            var sortAlgorithm = SortAlgorithmFactory.GetSortingAlgorithm(AlgorithmType.HeapSort);
            sortAlgorithm.Sort(numbers);

            for (int i = 0; i < totalElements; i++)
                Console.Write(numbers[i] + " ");
            Console.Write("\n");

            #endregion

            #region Graph

            /*
                0 - NewYork
                1 - Chicago
                2 - Miami
                3 - Dallas
                4 - Denver
                5 - SanFrancisco
                6 - SanDiego
                7 - LA
            */
            var cityList = new Dictionary<int, string>();
            cityList.Add(0, "NewYork");
            cityList.Add(1, "Chicago");
            cityList.Add(2, "Miami");
            cityList.Add(3, "Dallas");
            cityList.Add(4, "Denver");
            cityList.Add(5, "SanFrancisco");
            cityList.Add(6, "SanDiego");
            cityList.Add(7, "LA");

            var graph = new EdgeWeightedDirectedGraph(cityList.Count);
            //from, to, fare
            graph.AddEdge(new DirectedEdge(0, 1, 75));
            graph.AddEdge(new DirectedEdge(0, 2, 90));
            graph.AddEdge(new DirectedEdge(0, 3, 125));
            graph.AddEdge(new DirectedEdge(0, 4, 100));
            graph.AddEdge(new DirectedEdge(1, 4, 20));
            graph.AddEdge(new DirectedEdge(1, 5, 25));
            graph.AddEdge(new DirectedEdge(2, 3, 50));
            graph.AddEdge(new DirectedEdge(3, 6, 90));
            graph.AddEdge(new DirectedEdge(3, 7, 80));
            graph.AddEdge(new DirectedEdge(4, 5, 75));
            graph.AddEdge(new DirectedEdge(4, 7, 100));
            graph.AddEdge(new DirectedEdge(5, 7, 45));
            graph.AddEdge(new DirectedEdge(6, 7, 45));
                        
            var distanceTable = new Dictionary<int, double>();
            foreach (var city in cityList)
            {
                distanceTable[city.Key] = Int32.MaxValue;
            }

            var routeTable = new Dictionary<int, int?>();
            foreach (var city in cityList)
            {
                routeTable[city.Key] = null;
            }

            distanceTable[0] = 0;//initialize with 0 for starting City
            foreach (var city in cityList)
            {
                var edgeList = graph.GetAdjacencyList(city.Key);
                foreach (var edge in edgeList)
                {
                    if (distanceTable[city.Key] + edge.Weight() < distanceTable[edge.To()])
                    {
                        distanceTable[edge.To()] = distanceTable[city.Key] + edge.Weight();
                        routeTable[edge.To()] = city.Key;
                    }
                }
            }

            //Destination
            int destinationCity = 7;
            int? route = routeTable[destinationCity];
            string routePath = string.Empty;

            while (route != null)
            {
                routePath = "-->" + cityList[destinationCity] + routePath;
                destinationCity = route.Value;
                route = routeTable[destinationCity];
                if (route == null)
                {
                    routePath = cityList[destinationCity] + routePath;
                    break;
                }
            }

            Console.WriteLine("*** Cheapest Fare ***");
            Console.WriteLine(routePath);
            //var allEdges = graph.GetAllEdges();
            //foreach (var edge in allEdges)
            //{
            //    Console.WriteLine(edge.ToString());
            //}

            #endregion

            BasePayType basePaymentType = BasePayType.Visa;
            Console.WriteLine(basePaymentType.ToString());

            Console.ReadLine();
        }
    }

    [Flags]
    public enum BasePayType
    {
        [Description("Online")]
        Paypal = 1,
        [Description("WeChat")]
        Visa = 2,
    }
}
