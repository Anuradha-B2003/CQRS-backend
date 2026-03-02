using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace CleanArchitectureCQRS.Domain.Entities
    {
        public class Blog
        {
            public int Id { get; set; } 
            public string Name { get; set; }= string.Empty;
            public int Age { get; set; } 
            public string Content { get; set; } = string.Empty;
           
        }
    }


