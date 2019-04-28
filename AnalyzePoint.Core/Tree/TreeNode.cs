using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AnalyzePoint.Core.Tree
{
  public class TreeNode : IEnumerable<TreeNode>
  {
    public TreeNode Parent { get; protected set; }
    protected List<TreeNode> Children;

    public int GetDepth()
    {
      int depth = 0;
      TreeNode node = this;
      while (node.Parent != null)
      {
        node = node.Parent;
        depth++;
      }
      return depth;
    }

    public IEnumerable<TreeNode> GetDescendants()
    {
      var builder = ImmutableArray.CreateBuilder<TreeNode>();
      builder.AddRange(Children);
      foreach (TreeNode node in Children)
      {
        builder.AddRange(node.GetDescendants());
      }
      return builder.MoveToImmutable();
    }

    public IEnumerable<TreeNode> GetChildren()
    {
      return Children.ToImmutableArray<TreeNode>();
    }

    public IEnumerable<TreeNode> GetChildrenAndSelf()
    {
      IEnumerable<TreeNode> children = GetChildren();
      if (children == null)
      {
        return ImmutableArray.Create<TreeNode>(this);
      }
      else
      {
        return children.Union(ImmutableArray.Create<TreeNode>(this));
      }
    }

    public IEnumerable<TreeNode> GetDescendantsAndSelf()
    {
      IEnumerable<TreeNode> descendants = GetDescendants();
      if (descendants == null)
      {
        return ImmutableArray.Create<TreeNode>(this);
      }
      else
      {
        return descendants.Union(ImmutableArray.Create<TreeNode>(this));
      }
    }

    public IEnumerator<TreeNode> GetEnumerator()
    {
      return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public TreeNode(TreeNode parent = null, IEnumerable<TreeNode> children = null)
    {
      Parent = parent;
      Children = (children == null) ? new List<TreeNode>() : children.ToList<TreeNode>();

      if (Parent != null)
        Parent.Children.Add(this);

      foreach (TreeNode child in Children)
      {
        child.Parent = this;
      }
    }

    public class Enumerator : IEnumerator<TreeNode>
    {
      private TreeNode RootNode;
      private TreeNode NextNode;
      private Stack<int> Position;

      public TreeNode Current { get; private set; }

      object IEnumerator.Current
      {
        get
        {
          return Current;
        }
      }

      public void Dispose()
      {
        return;
      }

      public bool MoveNext()
      {
        //Enumeration basically does this:
        //while (en.MoveNext()) { yield return en.Current; }

        if (NextNode == RootNode.Parent)
          return false;

        Current = NextNode;

        //Amíg az utolsó gyermeken állunk, addig jövünk felfelé. Vége, hogyha kiléptünk a gyökérelemből.
        while (NextNode != RootNode.Parent && NextNode.Children.Count == Position.Peek() + 1)
        {
          NextNode = NextNode.Parent;
          Position.Pop();
        }

        //Lehet, hogy bejártuk az egész fát...
        if (NextNode != RootNode.Parent)
        {
          //Elmozdulunk oldalra - lehet hova, hiszen fentebb szűrtünk.
          int childIdx = Position.Pop();
          Position.Push(++childIdx);

          if (NextNode.Children.Count > childIdx)
          {
            NextNode = NextNode.Children[childIdx];
            Position.Push(-1);
          }
        }

        return true;
      }

      public void Reset()
      {
        Current = null;
        NextNode = RootNode;
        Position.Clear();
        Position.Push(-1);
      }

      public Enumerator(TreeNode root)
      {
        RootNode = root ?? throw new ArgumentException(nameof(root));
        Position = new Stack<int>();

        Reset();
      }
    }
  }
}
