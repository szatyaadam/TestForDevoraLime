using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Models
{
    public class Army
    {
        public Army(int id,Soldier soldier) 
        {
            this.Id = id;
            this.Soldier = soldier;
        }
        public int Id { get; set; }
        public Soldier Soldier { get; set; }
    }
}
