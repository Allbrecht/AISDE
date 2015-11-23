namespace AISDE1
{
    public class Event
    {        
        public EventType eventType { set; get; }
        public double eventTime { set; get; }
        public int streamSize { set; get; }
        public int numberOfStream { set; get; }
        public double arrivalTime;
    }
}
