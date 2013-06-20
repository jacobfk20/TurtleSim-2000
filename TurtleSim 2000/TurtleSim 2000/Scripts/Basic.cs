using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim_2000
{
    class Basic
    {
        //string[] Basicpages= {"!"};
        string playername = "Turtle";
        string bgchange = "bgchange";
        string charaevent_show_1 = "charaevent show 1";
        string charaevent_show_2 = "charaevent show 2";
        string charaevent_exit = "charaevent exit";
        string music = "music";
        string music_stop = "music stop";
        string breakpage = "break";
        bool hasbeenopened = false;

        public Basic()
        {
            hasbeenopened = true;
        }

        string readpage(int line)
        {
            string[] basicpages = {
                                      //------------------Sleep--------------
                                      "sleep",

                                      "\"I guess some sleep would be a wise idea.  It is by far \nmy favorite activity.\"",
                                      "\"No one can bother me in my dreams.  It is magical in my dreams.\"",
                                      "\"Why am I talking to myself? \"",
                                      "I stumble into my bed and start to ponder..",
                                      "...Will I dream?",

                                      charaevent_show_1,
                                      "emi/emicas_pout",

                                      charaevent_show_2,
                                      "rin/rin_relaxed_doubt_pan",

                                       "Emi\n\"Please come hang out with us.\"",

                                       charaevent_exit,

                                       "I have no idea if I should go or not..",

                                       breakpage,
                                      
                                       //--------------------------TV--------------------------
                                      "tv",
                                      "\"I do love watching TV.  I hope something is on that is worth it.\"",

                                      breakpage,
                                      
                                      //--------------------------Xbox-------------------------
                                      "xbox",
                                      "I start up the ol' 360, praying that it doesn't red ring on me...",
                                      "...And it didn't!  Yay!",
                                      "You feel yourself drift away in the world of gaming. \nMany hours pass before you feel you've had enough.",

                                      breakpage,
                                     
                                      //-------------------------music--------------------------
                                      "music",
                                      "You pop in your earphones and lose yourself in your weird collection of\nWeird Al and The Trashmen.  Quite a weird collection.",

                                      breakpage,
                                      
                                      //------------------------PornTime------------------------
                                      "porn",
                                      "You finally decide it's time for some 'Me' time.  You grab open your\nlaptop, lay in bed and get down to work.  Dont' worry though,\nIt doesn't take long.",

                                      charaevent_show_1,
                                      "emi/emicas_blush",

                                      "Emi: \n\"Oops, Oh my gosh!  I-I'm sorry!\"",

                                      charaevent_exit,

                                      "Well that was awkward...",

                                      breakpage,
                                      
                                      //-----------------------Study----------------------------
                                      "study",
                                      "After much debate you decide to study for your class.",
                                      "It doesn't take long before you lose interest.  You decided to stop.",

                                      breakpage,
                                      
                                      //----------------------Homework--------------------------
                                      "homework",
                                      "You sit down and start to do your homework.",
                                      "It takes a bit of work, but you finish up.  A considerable amount of\ntime passes, but you feel happy.",

                                      breakpage,
                                      
                                      //------------------------Text---------------------------
                                      "text",
                                      "Jacob:\nBro!  You have no friends!  Plus they're not programmed in yet anyway.",

                                      breakpage,
                                      
                                      //------------------------Write--------------------------
                                      "write",
                                      "You sit down with the urge to write.  You lose track of time as you write\nline after line.  You finally snap out of it.",

                                      breakpage,
                                      
                                      //------------------------Walk---------------------------
                                      "walk",
                                      "You get up and decide to go for a walk to lose some of that fat\n you keep gaining.",

                                      bgchange,
                                      "school_forest1",

                                      "A nice walk around the woods by the campus always clears one's mind.",

                                      bgchange,
                                      "school_dormext_start",

                                      "I find my way back to the dorms feeling rather accomplished.\nAlso pretty sweaty...  Gross.",

                                      bgchange,
                                      "school_dormkenji",

                                      breakpage,
                                      
                                      //----------------------------Eat--------------------------------
                                       "eat",

                                       "You decide to go eat, because food is a must.",

                                       bgchange,
                                       "school_cafeteria",

                                       "You go through the line quickly and you find a seat where no one\nelse is sitting.",
                                       "After quickly gulping down your food you quickly get up and leave.",

                                       bgchange,
                                       "school_dormkenji",

                                       breakpage,
                                      
                                       //---------------------------Win-----------------------------
                                       "win",
                                       "YAY!  YOU WON!  YOU'RE A LONER!  YAAAAAAAY!  ",

                                       "gameover",

                                       breakpage,
                                      
                                       //--------------------------Lose-----------------------------
                                       "lose",

                                       "Well, you lost.  good job.",

                                       "gameover",

                                       //breakpage,

                                       "!",
                                       "!"
                                   };
            return basicpages[line];
        }

        public string readline(int line)
        {


            string Line;

            Line = readpage(line);

            return Line;

        }

    }
}
