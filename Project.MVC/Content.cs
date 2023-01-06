using System;
using System.Collections.Generic;

namespace Project.MVC
{
    public partial class Content
    {
        public Content()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<News> News { get; set; }
    }
}
