using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2Końcowy
{
    class Path
    {
        double capacity;
        Node previous;
        public List<Link> links_list_in_path;
        public Path()
        {
            links_list_in_path = new List<Link>();
        }
        public Path(int v1, int v2)
        {
            links_list_in_path = new List<Link>();
            addLink(v1, v2);
        }
        public Path(int v1, int v2, double cap)
        {
            links_list_in_path = new List<Link>();
            addLink(v1, v2, cap);
        }
        public void addLink(int A, int B)
        {
            links_list_in_path.Add(new Link(A, B));
        }
        public void addLink(int A, int B, double cap)
        {
            links_list_in_path.Add(new Link(A, B, cap));
        }
        public List<Link> returnLinksList()
        {
            return links_list_in_path;
        }
        public List<Link> getLinks()
        {
            return links_list_in_path;
        }
        public void setLinks(List<Link> list)
        {
            this.links_list_in_path = list;
        }
        public void setCapacity(double capacity1)
        {
            capacity = capacity1;
        }
        public double returnCapacity()
        {
            return capacity;        
        }
        public void setPrevious(Node prev)
        {
            previous = prev;
        }
        public Node returnPrevious()
        {
            return previous;
        }

    }
}

