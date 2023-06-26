using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carnival.Models;

namespace Carnival.ViewModels
{
    public class Food_Stall
    {
        public List<Food_Product> food_Products { get; set; }
        public List<Stall> stalls { get; set; }
    }
}