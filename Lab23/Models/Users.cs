using System;
using System.Collections.Generic;

namespace Lab23.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public decimal Funds { get; set; }
    }
}
