using System;
using System.Collections.Generic;

namespace Project.MVC
{
    public partial class News
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public string LanguageCode { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public string ImageUrls { get; set; } = null!;
        public string Category { get; set; } = null!;

        public virtual Content Content { get; set; } = null!;
    }
}
