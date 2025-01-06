using System;
using System.Collections;
using System.Collections.Generic;
using Jet_Gears.Objects;

namespace Jet_Gears
{
    public class Categories
    {
        public static string Curr_User_Token { get; set; }
        public static ArrayList Busket_Array = new ArrayList();
        public static List<Search_Gear> Search_Gears = new List<Search_Gear>();
        public static List<Shelf_Gear> Shelf_Gears = new List<Shelf_Gear>();
    }
}