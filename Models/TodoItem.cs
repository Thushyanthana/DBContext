using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {

        public long Id { get; set; }
        public String Name { get; set; }

        public bool isComplete { get; set; }
        //? It is for assign null value to a coloumn
        public DateTime? Date { get; set; }
        public  int Priority { get; set; }

    }
}
