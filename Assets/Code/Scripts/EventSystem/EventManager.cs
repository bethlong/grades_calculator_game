using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Using Tutorial https://unity3d.com/learn/tutorials/topics/scripting/events-creating-simple-messaging-system
namespace Assets.Code.Scripts.EventSystem
{
    public class EventManager : MonoBehaviour {

        private Dictionary <EventName, UnityEvent> eventDictionary;

        private static EventManager eventManager;

        public static EventManager Instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

                    if (!eventManager)
                    {
                        Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        eventManager.Init (); 
                    }
                }

                return eventManager;
            }
        }

        void Init ()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<EventName, UnityEvent>();
            }
        }

        public static void StartListening (EventName eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
                thisEvent.AddListener (listener);
            } 
            else
            {
                thisEvent = new UnityEvent ();
                thisEvent.AddListener (listener);
                Instance.eventDictionary.Add (eventName, thisEvent);
            }
        }

        public static void StopListening (EventName eventName, UnityAction listener)
        {
            if (eventManager == null) return;
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
                thisEvent.RemoveListener (listener);
            }
        }

        public static void TriggerEvent (EventName eventName)
        {
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent))
            {
//                Debug.Log("TriggerEvent successful: " + eventName);
                thisEvent.Invoke ();
            }
        }
    }
}