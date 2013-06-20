using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim_2000
{
    class Emi
    {
        string[] emipages;
        string playername = "Turtle";
        string bgchange = "bgchange";
        string charaevent_show_1 = "charaevent show 1";
        string charaevent_show_2 = "charaevent show 2";
        string charaevent_exit = "charaevent exit";
        string music = "music";
        string music_stop = "music stop";
        string breakpage = "break";
        bool hasbeenopened = false;


        public Emi()
        {
            hasbeenopened = true;
        }

        string readpage(int line)
        {
            string[] emipages = {
                                   "walk_meetemi",
                                       "You get up and decide to go for a walk to lose some of that fat\n you keep gaining.",

                                       bgchange,
                                       "school_forest1",

                                       "As you are entering the wooded area where you tend to take your\nwalks.  You spot someone else a bit further ahead.",
                                       "You shrug it off and keep on walking minding your own business.",
                                       "?????:\n\"Hey!  Who are you?\"",

                                       charaevent_show_1,
                                       "emi/emicas_closedsmile",

                                       music,
                                       "Ah_Eh_I_Oh_You",

                                       playername + ":\n\"Oh..  Uh..  It's " + playername + "\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       "Emi:\n\"Oh hello, " + playername + ".  My name is Emi!  I see you're out walking\naround and I though I would join you!\"",
                                       playername + ":\n\"Nah, I think I'm good, but thanks.\"",
                                       "Emi:\n\"Oh don't be like that!  C'mon, It'll be fun!  I promise.\"",

                                       charaevent_show_1,
                                       "emi/emicas_wink",

                                       "Emi: \n\"Besides, who could turn down an opportunity to walk with someone \nsuch as me?\"",
                                       playername + ": \n\"I'm sure there are a few.\"",

                                       charaevent_show_1,
                                       "emi/emicas_weaksmile",

                                       "I guess that was a bit too harsh of me to say.  Oh well, it's too late now.",
                                       "Emi: \n\"Do..  Do you not want me to bother you?\"",
                                       "Emi: \n\"C'mon, let me walk with you.  Please?  Don't make me do my\npouty face.  No one can resist!\"",

                                       charaevent_show_1,
                                       "emi/emicas_pout",

                                       "Oh god!  I was not prepared for that!  I can't turn that down!",
                                       playername + ": \n\"Ok, we can walk together.\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       "Emi: \n\"I told you it always works.\"",
                                       "\"Emi and I start walking together.  She starts to pick up the pace and I\nslowly follow in suite.  Not so long after I start to get tired and say my\ngoodbye.\"",
                                       "\"She stops me and gives me and we exchange phone numbers real quick.",

                                       charaevent_show_1,
                                       "emi/emicas_neutral",

                                       "Emi:\n\"I know we just met, but I would really enjoy if you would run with me\nmore often.  It's always nice to have a running partner!\"",
                                       playername + ":\n\"I don't know.  I'm not a big fan of running.\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       "Emi:\n\"Just give it a thought and text me if you change your mind!\nIt's fun!  I promise!\"",

                                       charaevent_exit,

                                       "With that she started to run again.  Her pace picked up now that she\ndoesn't have to keep at my pace anymore.\"",

                                       bgchange,
                                       "school_dormext_start",

                                       "I find my way back to the dorms feeling rather accomplished.\nAlso pretty sweaty...  Gross.",

                                       bgchange,
                                       "school_dormkenji",

                                       "Man what a day!",

                                       //=============================================SCRIPT 002==================================================
                                       breakpage, 

                                       "eat_emi_first",

                                       "Placeholder...",
                                       "Yet another placeholder.",
                                       "You know, this is a TON better to write script with than before.",
                                       "I sure hope I get this working right...",

                                       //breakpage,

                                       "!",
                                       "!"
                                   };
            return emipages[line];
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
