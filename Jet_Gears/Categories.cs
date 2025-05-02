using System;
using System.Collections;
using System.Collections.Generic;
using Jet_Gears.Controls;
using Jet_Gears.Objects;

namespace Jet_Gears
{
    public class Categories
    {
        public static string CurrUserToken { get; set; }
        public static string CurrUserLogin { get; set; }
        
        public static Forms.Main_Form CurrentMainForm { get; set; }
        
        public static OverviewPart Current_OverviewPart = new OverviewPart("", "", "", "",  "","",new List<KeyValuePair<string, string>>());
        
        
        public static List<Shelf_Gear> BusketArray = new List<Shelf_Gear>();
        public static List<Order> Orders = new List<Order>();
        public static List<Search_Gear> SearchGears = new List<Search_Gear>();
        public static List<Shelf_Gear> ShelfGears = new List<Shelf_Gear>();
        public static List<string> ShelvesList = new List<string>() ;
        
        public static List<Option> MakersRoot = new List<Option>();
        public static List<Car_Model> CarModels = new List<Car_Model>();
        public static List<Car_Mark> CarMarks = new List<Car_Mark>();
        public static List<Car> Cars  = new List<Car>();
        
        public static List<AutoZvuk_Maker> Auto_Zvuk_Makers = new List<AutoZvuk_Maker>();
        public static List<AutoZvuk_Model> Auto_Zvuk_Models = new List<AutoZvuk_Model>();
        public static List<AvtoZvuk_Node> Auto_Zvuk_Nodes = new List<AvtoZvuk_Node>();


        
        public static string ChoosenMaker;
        public static string ChoosenModelHref;
        public static string ChoosenMarkHref;
        public static string ChoosenCarHref;
        
    }
}