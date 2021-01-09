using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AolicatieComanda.Models
{
    public class Comanda
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume_client { get; set; }
        public string Adresa { get; set; }

        
        public double Total { get; set; }
    }
}
