﻿#nullable disable
using System.Collections.Generic;
using System.Linq;
using static CSharpLibraries.Extensions.Extension;

namespace CSharpLibraries.Algorithms.Graph
{
    public static class Bfs
    {
        #region InnerClass

        internal enum Color
        {
            White,
            Gray,
            Black
        }

        public sealed class BfsVertex<Tid>
        {
            public BfsVertex<Tid> Parent { get; internal set; }
            internal Color Color;
            public double Distance { get; internal set; } // d
            public readonly Tid Id;

            public BfsVertex(Tid id)
            {
                NotNullArg(id, nameof(id));
                Id = id;
            }

            internal BfsVertex() => Id = default;
        }

        #endregion

        public static void BreathFirstSearch<T>(LinkedGraph<BfsVertex<T>> g, BfsVertex<T> s)
        {
            NotNullArg(g, nameof(g));
            NotNullArg(g,nameof(s));
            var vs = g.AllVertices();
            foreach (var v in vs.Where(v => v != s))
            {
                v.Color = Color.White;
                v.Distance = double.PositiveInfinity;
                v.Parent = null;
            }

            s.Color = Color.Gray;
            s.Distance = 0;
            s.Parent = null;
            Queue<BfsVertex<T>> q = new Queue<BfsVertex<T>>();
            q.Enqueue(s);
            while (q.Count != 0)
            {
                var u = q.Dequeue();
                var uEdges = g.EdgesAt(u);
                foreach (var v in uEdges.Select(edge => edge.AnotherSide(u)).Where(v => v.Color == Color.White))
                {
                    v.Color = Color.Gray;
                    v.Distance = u.Distance + 1;
                    v.Parent = u;
                    q.Enqueue(v);
                }

                u.Color = Color.Black;
            }
        }

        public static IList<T> GetPath<T>(BfsVertex<T> s, BfsVertex<T> v)
        {
            NotNullArg(s,nameof(s));
            NotNullArg(v,nameof(v));
            List<T> t = new List<T>();
            Traverse(s, v, t);
            List<T> res = new List<T>(t.Count);
            res.AddRange(t);
            return res;
        }

        private static void Traverse<T>(BfsVertex<T> s, BfsVertex<T> v, List<T> res)
        {
            if (v == s) res.Add(s.Id);
            else if (v.Parent != null)
            {
                Traverse(s, v.Parent, res);
                res.Add(v.Id);
            }
        }
    }
}