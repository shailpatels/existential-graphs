using System;
using System.Collections.Generic;

public class ISONode
{

    /* Properties and Fields */

    public List<ISONode> children;
    public ISONode parent;
    public bool is_var;
    public bool is_cut;
    public string value;

    /* Constructor(s) */
    public ISONode()
    {
        this.children = new List<ISONode>();
        this.parent = null;
    }

    public void Init_As_Cut()
    {
        this.is_cut = true;
        this.is_var = false;
        this.value = "cut";

    }

    public void Init_As_Var(string name)
    {
        this.is_cut = false;
        this.is_var = true;
        this.value = name
    }

    /* Private Helper Methods */

    private int Depth_Helper(ISONode n, int depth)
    {
        if(n.is_root)
        {
            return depth;
        }
        return Depth_Helper(n.parent, depth + 1);

    }

    private int Number_Of_Cuts(ISONode n, int cut_count)
    {
        if (n == null)
        {
            return cut_count;
        }

        if(n.is_cut)
        {
            return Number_Of_Cuts(n.parent, cut_count + 1);
        }

        return Number_Of_Cuts(n.parent, cut_count);
    }

    /*  Public Methods  */

    public bool Is_Leaf()
    {
        return this.children.Count == 0;
    }

    public void Add_Child(ISONode n)
    {

        n.parent = this;
        this.children.Add(n);

    }

    public int Depth()
    {
        return Depth_Helper(this,0);
    }

    public List<ISONode> getChildren()
    {
        return this.children;
    }

    public bool Is_On_Even_Level()
    {
        return Number_Of_Cuts % 2 == 0;
    }

    public bool Is_On_Odd_Level()
    {
        return !Is_On_Even_Level();
    }

    public override string ToString()
    {
        return this.value;
    }

}
