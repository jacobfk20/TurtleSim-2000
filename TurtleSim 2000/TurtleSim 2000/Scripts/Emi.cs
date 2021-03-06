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
        string trigger = "switch";

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
                                   "debug",
                                       "You get up and decide to go for a walk to lose some of that fat\n you keep gaining.",

                                       bgchange,
                                       "school_forest1",

                                       "As you are entering the wooded area where you tend to take your\nwalks.  You spot someone else a bit further ahead.",
                                       "You shrug it off and keep on walking minding your own business.",
                                       "?????:\n\"Hey!  Who are you?\"",

                                       charaevent_show_1,
                                       "emi/emicas_closedsmile",

                                       music,
                                       "Afternoon",

                                       playername + ":\n\"Oh..  Uh..  It's " + playername + "\"",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "Oh hello, " + playername + ".  My name is Emi!  I see you're out walking\naround and I though I would join you!\"",
                                       playername + ":\n\"Nah, I think I'm good, but thanks.\"",

                                       emi + "Oh don't be like that!  C'mon, It'll be fun!  I promise.\"",

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

                                       charaevent_move_1,
                                       "left",

                                       Fork,
                                       "Oh god!  I was not prepared for that!  How can I turn that down?",
                                       "Say sorry and walk with her",
                                       "walk_meetemi_accept",
                                       "Stutter words and run away.",
                                       "walk_meetemi_decline",

                                       //================================================MEETEMI-ACCEPT=============================================================
                                       breakpage,

                                       "walk_meetemi_accept",

                                       playername + ": \n\"Ok, we can walk together.\"",

                                       charaevent_move_1,
                                       "center",

                                       charaevent_show_1,
                                       "emi/emicas_happy_up",

                                       emi + "I told you it always works.\"",
                                       "\"Emi and I start walking together.  She starts to pick up the pace and I\nslowly follow in suite.  Not so long after I start to get tired and say my\ngoodbye.\"",
                                       "\"She stops me and gives me and we exchange phone numbers real quick.",

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

                                       music,
                                       "Daylight",

                                       "Man what a day!",

                                       //=============================================MEETEMI-DECLINE=============================================
                                       breakpage,

                                       "walk_meetemi_decline",

                                       playername + ": \n\"I'MSorryButIHaveToGo!\"",

                                       trigger,
                                       "sMetEmi_badend",

                                       "I start to turn around and run away but she grabs my hand just as I'm \nabout to escape her grasp.",

                                       charaevent_show_1,
                                       "emi/emicas_angry",

                                       emi + "What is wrong with you?  Is it something I said?\"",

                                       charaevent_show_1,
                                       "emi/emicas_frown",

                                       emi + "Or do you really have something to go do..\"",
                                       emi + "I'm sorry, you can go if you want to.",

                                       "She looks as if she just did something horribly wrong.  Maybe I should say \nsomething.. but instead I continue on.",

                                       charaevent_exit,

                                       "I start to walk away and I hear her yell from a distance.",

                                       charaevent_show_1,
                                       "emi/emicas_smile",

                                       emi + "If you want to walk with me some other time you know where to find me!",

                                       charaevent_move_1,
                                       "offleft",

                                       "After she yelled from across the opening in the trees she heads off sprinting \nin the other direction.  I turn back around and head back to the dorms.",

                                       bgchange,
                                       "school_dormkenji",

                                       music,
                                       "Daylight",

                                       "That was an awkward moment.",

                                       charaevent_exit,

                                       "I shure hope I don't run into her again.",

                                       //============================================ Meeting Emi again (badend) =================================
                                       breakpage,

                                       "walk_meetemi_2",

                                       "You get up and decide to go for a walk to lose some of that fat\n you keep gaining.",

                                       bgchange,
                                       "school_forest1",

                                       "As I'm entering the wooded area where I tend to take my walks.  \nI spot someone else a bit further ahead.",
                                       "I quickly realize it is Emi and I decide to head back in another \nDirection.  She doesn't seem to spot me this time.",
                                       
                                       bgchange,
                                       "school_courtyard",

                                       "I decide to walk around the main campus instead of my favorite spot.  \nNo one really seems to pay me any mind.",
                                       "After about an hour of walking around I decide to head back to my dorm.",

                                       bgchange,
                                       "school_dormext_start",

                                       "I though I just spotted Emi, so I quickly make it up to the front door.",
                                       "After looking back I realize it was just an orange bush in the distance \nI feel slightly relieved, yet stupid at the same time.",

                                       bgchange,
                                       "school_dormkenji",


                                       //============================================= Eat With Emi! ==================================================
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

                                       music,
                                       "Daylight",

                                       "I really don't want to go to the movies, there is never anything I want to\nwatch.  Oh well, at least there will be noise.",

                                       //==================================================== testing the debug script =========================

                                       breakpage,

                                       "deleteme",

                                       "Turtle is a fagot.",
                                       "No, really.",

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
