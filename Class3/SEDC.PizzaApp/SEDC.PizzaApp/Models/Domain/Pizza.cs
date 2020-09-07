using Microsoft.CodeAnalysis.CSharp.Syntax;
using SEDC.PizzaApp.Models.Enums;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public bool HasExtras { get; set; }
    }
}
