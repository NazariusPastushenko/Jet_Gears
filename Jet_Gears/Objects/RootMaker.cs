using System.Collections.Generic;

namespace Jet_Gears.Objects;

    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Maker
    {
        public string Label { get; set; }
        public List<Option> Options { get; set; }
    }

    public class RootMaker
    {
        public List<Maker> Makers { get; set; }
    }
