﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AISDE1
{
    class EventQueue
    {
        private List<Event> list;
        public EventQueue()
        {
            list = new List<Event>();
        }

        public void addEvent(EventType evType, double time, int streamSize, int numberOfStream)
        {
            Event myEvent = new Event();
            myEvent.eventType = evType;
            myEvent.eventTime = time;
            myEvent.streamSize = streamSize;
            myEvent.numberofStream = numberOfStream;
                

            list.Add(myEvent);
            list.OrderBy(MyEvent => MyEvent.eventTime).ToList();
        }
        public Event getEvent()
        {
            Event myEvent = list[0];
            list.RemoveAt(0);
            return myEvent;
        }

    }

}
public enum EventType { Arrival, Departure }
