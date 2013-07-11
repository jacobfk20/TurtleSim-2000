using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim_2000
{
    class Emi
    {
        string[] emipages;

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

        //Ease of Formatting:
        //use these instead of escapes  Ex. (  emi + "dialogue",  )
        string emi = "Emi: \n\""; 

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

                                       //music,
                                       //"Ah_Eh_I_Oh_You",

                                       playername + ":\n\"Oh..  Uh..  It's " + playername + "\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "Oh hello, " + playername + ".  My name is Emi!  I see you're out walking\naround and I though I would join you!\"",
                                       playername + ":\n\"Nah, I think I'm good, but thanks.\"",

                                       charaevent_move_1,
                                       "right",

                                       emi + "Oh don't be like that!  C'mon, It'll be fun!  I promise.\"",

                                       charaevent_move_1,
                                       "left",

                                       "easy ass shit.",

                                       charaevent_show_1,
                                       "emi/emicas_wink",

                                       emi  + "Besides, who could turn down an opportunity to walk with someone \nsuch as me?\"",
                                       playername + ": \n\"I'm sure there are a few.\"",

                                       charaevent_show_1,
                                       "emi/emicas_weaksmile",

                                       "I guess that was a bit too harsh of me to say.  Oh well, it's too late now.",
                                       emi + "Do..  Do you not want me to bother you?\"",
                                       "Emi: \n\"C'mon, let me walk with you.  Please?  Don't make me do my\npouty face.  No one can resist!\"",

                                       charaevent_show_1,
                                       "emi/emicas_pout",

                                       "Oh god!  I was not prepared for that!  I can't turn that down!",
                                       playername + ": \n\"Ok, we can walk together.\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "I told you it always works.\"",
                                       "\"Emi and I start walking together.  She starts to pick up the pace and I\nslowly follow in suite.  Not so long after I start to get tired and say my\ngoodbye.\"",
                                       "\"She stops me and gives me and we exchange phone numbers real quick.",

                                       Fork,
                                       emi + "Do you want to go to the movies with me?\"",
                                       "Uhh, sure.",
                                       "emi_movies1",
                                       "Not today, sorry.",
                                       "emi_movies1_decline",

                                       charaevent_show_1,
                                       "emi/emicas_neutral",

                                       emi + "I know we just met, but I would really enjoy if you would run with me\nmore often.  It's always nice to have a running partner!\"",
                                       playername + ":\n\"I don't know.  I'm not a big fan of running.\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "Just give it a thought and text me if you change your mind!\nIt's fun!  I promise!\"",

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

                                       "eat_emi",

                                       "I start to feel my stomach rumble, better head to the cafe.",

                                       bgchange,
                                       "school_cafeteria",

                                       "After going through the line and getting my food, I decide to find a nice \nalone spot to gather my thoughts.",
                                       "Just as I'm about to take a seat someone I've seen before comes up to me.",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "Hey " + playername + "!  I knew I would run in to you here!",
                                       playername + ": \n\"Yeah, fancy that!",
                                       "I feel as if what I said was pretty spiteful.\nBut She doesn't seem to be affected by it.",

                                       charaevent_show_1,
                                       "emi/emicas_smile",

                                       emi + "So have you given my offer a thought?\"",
                                       "At first I felt stupified, then I remembered what she was talking about\nBut She must have noticed my face of ignorance.",

                                       charaevent_show_1,
                                       "emi/emicas_frown",

                                       emi + "Did you forget?", 
                                       playername + ": \n\"Uh..  No!  You just caught me off guard is all.\"",

                                       charaevent_show_1,
                                       "emi/emicas_grin",

                                       emi + "Haha!  Don't worry about it!  You have my phone number, just text me\nwhen you have finally decided.\"",
                                       emi + "Or..  I'll text you.\"",

                                       charaevent_show_1,
                                       "emi/emicas_evil_up",

                                       emi + "You don't want me to text you first, haha!\"",
                                       "I kinda felt uncomfortable after that last comment.  I don't know if she is \nkidding, or if she is threatening to kill me.  either way, I should text her \nfirst.\"",

                                       charaevent_show_1,
                                       "emi/emicas_neutral",

                                       "I see her looking around and starts to look fairly concerned.",
                                       emi + "Are you going to eat over here just by yourself?\"",
                                       "The question caught me off gaurd.  She seems to be vary good at that.\"",
                                       playername + ": \n\"Uh, I was--\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "I can sit with you!\"",

                                       "She interupted me.  Yet again, off gaurd.",
                                       "I shrug it off and I start to sit down.",

                                       charaevent_show_1,
                                       "emi/emicas_sad",

                                       emi + "Oh!  I forgot I need to be at practice in like two minutes!",

                                       charaevent_move_1,
                                       "offright",

                                       "Before I can even think she is gone.  Oh well, I can finally be alone.",
                                       "I eat my meal and put the tray back up and head back to the dorms.",

                                       charaevent_exit,

                                       bgchange,
                                       "school_dormext_start",

                                       "Just as I am about to enter my dorm I see Emi running with a group\nof people.",
                                       "Huh, she must be on the track team.",

                                       bgchange,
                                       "school_dormkenji",

                                       "She kinda scares me.",

                                       //================================================================= Script 003 ===============================================

                                       breakpage,

                                       "emi_movies1",
                                       
                                       playername + ": \n\"" + "Uhh.. Sure.",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "Really?  No one ever wants to go to the movies with me!\"",

                                       charaevent_show_1,
                                       "emi/emicas_awayfrown",

                                       emi + "You're not just teasing me are you?  The last time I got stood up I\ndecked the guy right in his nose.\"",

                                       playername + ": \n\"" + "No, I'm not trying to set you up.\"",

                                       charaevent_show_1,
                                       "emi/emicas_smile_up",

                                       emi + "I'm glad you're not that kind of person.\"",

                                       charaevent_exit,

                                       bgchange,
                                       "school_dormkenji",

                                       "I really don't want to go to the movies, there is never anything I want to\nwatch.  Oh well, at least there will be noise.",

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
