using System;
using System.Collections;
using System.Collections.Generic;
using Jet_Gears.Objects;

namespace Jet_Gears
{
    public class Categories
    {
        public static string CurrUserToken { get; set; }
        public static string CurrUserLogin { get; set; }
        
        public static Forms.Main_Form CurrentMainForm { get; set; }
        
        public static ArrayList BusketArray = new ArrayList();
        public static List<Search_Gear> SearchGears = new List<Search_Gear>();
        public static List<Shelf_Gear> ShelfGears = new List<Shelf_Gear>();
        public static List<string> ShelvesList = new List<string>() ;
        
        public static List<Option> MakersRoot = new List<Option>();
        public static List<Car_Model> CarModels = new List<Car_Model>();
        public static List<Car_Mark> CarMarks = new List<Car_Mark>();
        public static List<Car> Cars  = new List<Car>();
        

        public static string ChoosenMaker;
        public static string ChoosenModelHref;
        public static string ChoosenMarkHref;
        public static string ChoosenCarHref;
        
    }
}