using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FONovelViewer
{
    public class Novel
    {
        public string Name { set; get; }

        public List<Chapter> Chapters { set; get; }

        public Novel()
        {
            Chapters = new List<Chapter>();
        }
    }
}
