namespace VenusBiller.Entities
{
    public class NullParty : Party
    {
        public NullParty()
        {
            Code = string.Empty;
            Name = string.Empty;
            GstIn = string.Empty;
            Address = string.Empty;
        }
    }
}