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
        string emi = "Emi: \n";
        string pro = "Turtle: \n";

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

                                   //======================================= TEST KATAWA SHOUJO =============================

                                   breakpage,

                                   "katawa",

                                    "Class doesn't start for at least a few more hours.",

    "It takes me a moment to remember that I agreed to run \nin the mornings with Emi.",

    "What the hell was I thinking?",

    "Oh yes, now I remember.  I was thinking about how much I \ndon't want to die.",
    
    "Really, I'm not that interested in running as a hobby, or \neven as a possible life-lengthening exercise...",

    "But for whatever reason I feel obligated to follow through \non my promise to Emi yesterday.",
    
    "Which is why I find myself throwing on some running shorts \nand a light tee-shirt.",
    
    bgchange,
    "school_courtyard",

    "The cool morning air caresses my face as the morning sunshine \ncauses the dew on the grass to sparkle, nearly blinding \nme at first.",

    "As I make my way down to the track, an ugly thought strikes \nme.",

    "What if this was some sort of joke that Emi's playing on me?",
    
    "Would that surprise me, really?",
    
    "Hell, I'd probably do it to the new guy too, if it were me.",

    "At the least I'll bet Emi and Rin were wagering on whether or \nnot I'd actually show up.",
    
    //stop music fadeout 1.5
    
    bgchange,
    "school_track",

    "I feel a sense of trepidation as the track comes into view.",
    
    //play music music_emi fadein 0.75

    charaevent_show_1, 
    "emi/emicas_frown",
    
    emi + "You're late!",

    "It would seem that Emi is already there. What a relief.",

    pro + "Preposterous! You're early!",

    charaevent_show_1,
    "emi/emicas_grin",
    
    emi + "Damn. You've got me there.",

    "Emi is sitting on the bleachers, decked out in her running gear, \nwaiting somewhat patiently for me.",

    pro + "I'm glad you're actually here. I was afraid that this was \na joke or something.",

    charaevent_show_1,
    "emi/emicas_grin_up",
    
    emi + "Nah, I'd never make someone get up early for nothing.",

    emi + "Plus, Rin owes me 500 yen now. She didn't think you'd actually \nshow up.",

    "I knew it!",
    
    "Nice to know she was on my side, at least.",

    "Emi hops off of the bleachers and begins stretching out.",

    "She's remarkably lithe, almost like a dancer.",

    "I set out to stretch myself and realize that I don't remember how \nexactly to stretch properly.",
    
    "It's been ages since I stretched for anything, if you don't count\nmy one stint at running last week.",
    
    "And even then, I don't think I actually stretched beforehand.",
    
    "The specter of my long hospital stay rises up again.",
    
    "Although I can't say I was all that active before the hospital stay.",
    
    "So maybe I'm just being morose.",

    "Emi giggles as she watches me stretch out.",

    charaevent_show_1,
    "emi/emicas_smile",
    
    emi + "No no no Hisao, you've got to hold it for longer than that!",

    pro + "I'm trying! It kinda hurts a little.",

    charaevent_show_1,
    "emi/emicas_happy",
    
    emi + "Ha! That's because you're out of shape. You've got to get some \nflexibility in you, like this.",

    "To demonstrate, Emi reaches down and puts her head through her legs.",

    "God bless you, Emi!",

    pro + "I see. Is that the sort of thing I should strive for?",


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
