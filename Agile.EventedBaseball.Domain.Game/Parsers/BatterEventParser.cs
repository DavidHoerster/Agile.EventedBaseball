using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Agile.EventedBaseball.Entity;

namespace Agile.EventedBaseball.Domain.Game.Parsers
{
    public class BatterEventParser
    {

        public static BatterEventType BatterEventResult(String eventString)
        {
            var batterAndAdvancement = eventString.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);  //53/SH/BG.2-3

            //don't worry about advancements for right now

            if (batterAndAdvancement.Length > 0)
            {
                var batterAndDetail = batterAndAdvancement[0].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (batterAndDetail.Length > 0)
                {
                    //just care about the first part for now
                    var batterEvent = batterAndDetail[0];

                    //check regex to see what the result is -- hit, out or np
                    return EvaluateEvent(batterEvent);
                }
            }

            return BatterEventType.NoPlay;
        }


        private static BatterEventType EvaluateEvent(String batterEvent)
        {
            //check for no play:

            //check for outs:
            if (Regex.IsMatch(batterEvent, "^[1-9]{1,3}(\\([1-3]\\)){0,1}") ||
                Regex.IsMatch(batterEvent, "^[1-9]{1,2}\\([B,1-3]\\)([1-9]{1,3}(\\([B,1-9]{1}\\)){0,1}){1,2}") ||
                Regex.IsMatch(batterEvent, "^[1-9]{1}\\([B,1-3]\\)([1-9]{1,3}(\\([B,1-9]{1}\\)){0,1}){1,2}") ||
                Regex.IsMatch(batterEvent, "^K[1-9]{0,2}") || 
                Regex.IsMatch(batterEvent, "^[E]{1}[1-9]{0,1}") ||  //error...out for now
                Regex.IsMatch(batterEvent, "^FC[1-9]{0,1}"))    //fielders choice...out for now
            {
                return BatterEventType.Out;
            }

            if (Regex.IsMatch(batterEvent, "^S{1}[1-9]{0,1}"))
            {
                return BatterEventType.Single;
            }
            if (Regex.IsMatch(batterEvent, "^D{1}[1-9]{0,1}") || 
                Regex.IsMatch(batterEvent, "^DGR"))
            {
                return BatterEventType.Double;
            }
            if (Regex.IsMatch(batterEvent, "^T{1}[1-9]{0,1}"))
            {
                return BatterEventType.Triple;
            }
            if (Regex.IsMatch(batterEvent, "^H[R]{0,1}[1-9]{0,1}"))
            {
                return BatterEventType.Homer;
            }
            if (Regex.IsMatch(batterEvent, "^I[W]{0,1}") || 
                Regex.IsMatch(batterEvent, "^W"))
            {
                return BatterEventType.Walk;
            }
            return BatterEventType.NoPlay;
        }
    }
}
