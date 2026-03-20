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
            SaveToFile($@"{Paths.InteractionScripts}\{ScriptName}.json");
        }

        public static InteractionScript LoadFromFile(string fileName, string scriptName = "")
        {
            if (scriptName != "")
            {
                fileName = $@"{Paths.InteractionScripts}\{scriptName}.json";
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
            foreach(var ev in Events)
            {
                switch (ev.EventType)
                {
                    case InteractionEventType.MouseMove:
                    default:
                        MouseHelper.Move(ev.X.Value, ev.Y.Value, ev.DelayBefore.Value, ev.DelayAfter.Value);
                        break;

                    case InteractionEventType.MouseMoveAndClick:
                        MouseHelper.MoveAndClick(ev.X.Value, ev.Y.Value, ev.MouseClickType, 
                            ev.DelayBefore.Value, ev.DelayBetween.Value, ev.DelayAfter.Value);

                        break;

                    case InteractionEventType.Activate:
                        ProcHelper.ActivateApp(ProcessID, ev.DelayBefore.Value, ev.DelayAfter.Value);
                        break;

                    case InteractionEventType.SendKeys:

                        Thread.Sleep(ev.DelayBefore.Value);
                        SendKeys.Send(ev.KeysToSend);
                        Thread.Sleep(ev.DelayAfter.Value);
                        break;
                }
            }
        }
    }

    public class InteractionEvent
    {
        public string? EventName { get; set; }
        public InteractionEventType? EventType { get; set; } 

        public InteractionMouseClickType? MouseClickType { get; set; }      

        public int? X { get; set; }
        public int? Y { get; set; }  
        public int? DelayBefore { get; set; }    
        public int? DelayBetween { get; set; }
        public int? DelayAfter { get; set; }

        public string? KeysToSend { get; set; }
    }

    public enum InteractionEventType
    {
        MouseMove,
        MouseMoveAndClick,
        SendKeys,
        Activate
    }

    public enum InteractionMouseClickType
    {
        Left,
        Right
    }
}
