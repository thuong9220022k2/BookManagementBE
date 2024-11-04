using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.Core.Models
{
    public class Book : BaseEntity
    {
        #region Properties

        public Guid BookId { get; set; }
        public string BookCode { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; } //FK
        public Author Author { get; set; }
        public int PublisherId { get; set; } //FK
        public Publisher Publisher { get; set; }
        public string ISBN { get; set; }
        public int CategoryId { get; set; } //FK
        public Category Category { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public Datetime PublishedAt { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        #endregion
    }
}