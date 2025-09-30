    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DAL.Models
    {
        public class Genre : BaseEntity
        {
            public string Name { get; set; }
            
            public virtual IEnumerable<Book> Books { get; set; }
        }
    }
