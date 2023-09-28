
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_shortest_path_label_setting

 { 

class PathSLink
    {
        public enum LinkUseageType
        {
            Unused,
            InTree,
            InPath
        }

        public PathSNode Node1, Node2;
        public int Cost;
        public LinkUseageType LinkUsage = LinkUseageType.Unused;
    }










    class PathSNode
    {
        public enum NodeStatusType
        {
            NotInList,
            WasInList,
            NowInList
        }

        public int Id;
        public Point Location;
        public Dictionary<int, PathSLink> Links = new Dictionary<int, PathSLink>();
        public int Dist;                    // Distance from root of path tree.
        public NodeStatusType NodeStatus;   // Path tree status.
        public PathSLink InLink;            // The link into the node.
    }

}