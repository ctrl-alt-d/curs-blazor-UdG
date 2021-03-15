using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Datalayer
{

    public class Blog
    {
        public int BlogId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public DateTime? DiaDePublicacio { get; set; }
        public List<Post> Posts { get; set; } = new();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        [Required]
        public Blog? Blog { get; set; } 
    }

    public class AuditEntry
    {
        public int AuditEntryId { get; set; } 
        public string Username { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
    }

}
