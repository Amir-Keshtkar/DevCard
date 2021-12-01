using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCard_MVC.Models {
    public class Project {
        public long Id {
            set; get;
        }
        public string Name {
            get; set;
        }
        public string Description {
            get; set;
        }
        public string Image {
            get; set;
        }
        public string Client {
            get; set;
        }

        public Project(long id, string name, string description, string Image, string client) {
            Id = id;
            Name = name;
            Description = description;
            this.Image = Image;
            Client = client;
        }
    }
}
