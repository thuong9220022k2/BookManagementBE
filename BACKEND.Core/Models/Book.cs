using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class Book : BaseEntity
    {
        #region Properties

        public Guid BookId { get; set; } //PK
        public string BookCode { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; } //FK
        public List<Author>? Author { get; set; }
        public Guid PublisherId { get; set; } //FK
        public Publisher Publisher { get; set; }
        public string ISBN { get; set; }
        public Guid CategoryId { get; set; } //FK
        public List<Category>? Category { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        #endregion
    }
}