using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class InteractionScript : JsonBase
    {
        public string? ScriptName { get; set; }
        public List<InteractionEvent>? Events { get; set; }
        [JsonIgnore]
        public int ProcessID {  get; set; }

        public InteractionScript(int processId = 0)
        {
            Events = new List<InteractionEvent>();
            ProcessID = processId;
        }

        public void Save()
        {
            SaveToFile($@"{sc.Paths.InteractionScripts}\{ScriptName}.json");
        }

        public static InteractionScript LoadFromFile(string fileName, string scriptName = "")
        {
            if (scriptName != "")
            {
                fileName = $@"{sc.Paths.InteractionScripts}\{scriptName}.json";
            }
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            var returnRI = JsonSerializer.Deserialize<InteractionScript>(System.IO.File.ReadAllText(fileName), options);
            return returnRI;
        }

        public void ProcessScript()
        {
            ProcessEvents(Events);
        }

        public void ProcessEvents(List<InteractionEvent> events)
        {
            foreach (var ev in events)
            {
                if (ev.Enabled.Value)
                {
                    Thread.Sleep(ev.DelayBefore.Value);
                    switch (ev.EventType)
                    {
                        case InteractionEventType.MouseMove:
                        default:
                            MouseHelper.Move(ev.X.Value, ev.Y.Value);
                            break;

                        case InteractionEventType.MouseMoveAndClick:
                            MouseHelper.MoveAndClick(ev.X.Value, ev.Y.Value, ev.MouseClickType,
                                ev.DelayBetween.Value, ev.Frequency.Value);

                            break;

                        case InteractionEventType.Activate:
                            ProcHelper.ActivateApp(ProcessID);
                            break;

                        case InteractionEventType.SendKeys:
                            SendKeys.Send(ev.KeysToSend);
                            break;

                        case InteractionEventType.Group:
                            for (int i = 0; i < ev.Frequency.Value; i++)
                            {
                                ProcessEvents(ev.ChildEvents);
                            }
                            break;
                    }
                    Thread.Sleep(ev.DelayAfter.Value);
                }
            }
        }
    }

    public class InteractionEvent
    {
        public string? EventName { get; set; }
        public bool? Enabled { get; set; }  
        public InteractionEventType? EventType { get; set; } 
        public InteractionMouseClickType? MouseClickType { get; set; }      
        public int? X { get; set; }
        public int? Y { get; set; }  
        public int? DelayBefore { get; set; }    
        public int? DelayBetween { get; set; }
        public int? DelayAfter { get; set; }
        public int? Frequency { get; set; }
        public string? KeysToSend { get; set; }

        public List<InteractionEvent>? ChildEvents { get; set; }
    }

    public enum InteractionEventType
    {
        MouseMove,
        MouseMoveAndClick,
        SendKeys,
        Activate,
        Group
    }

    public enum InteractionMouseClickType
    {
        Left,
        Right
    }
}
