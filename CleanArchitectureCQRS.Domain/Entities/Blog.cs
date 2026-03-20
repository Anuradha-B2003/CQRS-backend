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
            private string _name = string.Empty;
            public string Name {
            get=>_name;
            set=>_name=value?.Trim()??string.Empty; 
            }
            public int Age { get; set; }
            private string _content = string.Empty;
            public string Content { 
            get=>_content;
            set=>_content=value?.Trim()??string.Empty; 
            } 
           
        }
    }


