using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHelper.Models.Tables
{
    public class Technique
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public string Algorithm { get; set; }
        public string Path { get; set; }
    }
}
