using System.ComponentModel;

namespace VenusBiller.Entities
{
    public class Party
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Browsable(false)]
        public string GstIn { get; set; }
    }
}