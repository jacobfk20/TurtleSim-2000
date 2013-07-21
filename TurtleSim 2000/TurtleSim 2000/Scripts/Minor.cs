using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim_2000
{
    class Minor
    {
        string[] Minorpages;

        //Declare Script Actions:
        string playername = "Turtle";
        string bgchange = "bgchange";
        string charaevent_show_1 = "charaevent show 1";
        string charaevent_show_2 = "charaevent show 2";
        string charaevent_move_1 = "charaevent move 1";
        string charaevent_exit = "charaevent exit";
        string music = "music";
        string music_stop = "music stop";
        string breakpage = "break";
        string Fork = "Fork Question";
        string trigger = "switch";

        //Ease of Formatting:
        //use these instead of escapes  Ex. (  emi + "dialogue",  )
        string emi = "Emi: \n\""; 

        bool hasbeenopened = false;


        public Minor()
        {
            hasbeenopened = true;
        }

        string readpage(int line)
        {
            string[] Minorpages = {
                                   "Sam_Bully",

                                   "I'm too lazy to do this right now, but this will be minor chara's scripts",

                                       "!",
                                       "!"
                                   };
            return Minorpages[line];
        }

        public string readline(int line)
        {
            //Send proper line to class header

            string Line;

            Line = readpage(line);

            return Line;
        }

    }
}
