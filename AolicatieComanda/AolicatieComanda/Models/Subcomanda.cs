using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AolicatieComanda.Models
{
    public class Subcomanda
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Comanda))]
        public int IdComanda { get; set; }
        
        public int IdFel{ get; set; }
        

    }
}
