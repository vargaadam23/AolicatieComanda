using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AolicatieComanda.Models
{
    public class Feluri
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Denumire { get; set; }
        public double Pret { get; set; }
        [OneToMany]
        public List<Subcomanda> Subcomenzi { get; set; }
    }
}
