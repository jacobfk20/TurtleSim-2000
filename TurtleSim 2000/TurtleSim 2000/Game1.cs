using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TurtleSim_2000
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {

        //just for reference.  not really important
        String GameInfo = "TurtleSim 2000 (Build 021) Alpha 0.25";

        //fonts
        SpriteFont debugfont;
        SpriteFont debugfontsmall;
        SpriteFont speechfont;
        SpriteFont clockfont;
        int frames = 0;

        //gui textures
        Texture2D buttonup;
        Texture2D buttondown;
        Texture2D logo;
        Texture2D logo2;
        Texture2D pgbar_left;
        Texture2D pgbar_center;
        Texture2D pgbar_right;
        Texture2D pgbar_filler_left;
        Texture2D pgbar_filler_center;
        Texture2D pgbar_filler_right;
        Texture2D messagebox;
        Texture2D messagebox2;
        Texture2D action_menu;
        Texture2D clock_tex;
        Texture2D buttonselector;
        Texture2D ButtonA;

        //background textures
        Texture2D bg_manage;             //Background: ??
        Texture2D bg_classroom;          //Background: Classroom
        Texture2D bg_courtyard;          //Background: Courtyard
        Texture2D bg_dormbath;           //Background: Dorm bathroom
        Texture2D bg_dormgirl;           //Background: Girls Dorm Hall
        Texture2D bg_dorm_ext;           //Background: Boys Dorm Exterior
        Texture2D bg_dorm;               //Background: Player's Dorm Room
        Texture2D bg_forest;             //Background: Forest (walking area)
        Texture2D bg_gate;               //Background: School Front Gate

        //Chara
        Texture2D emi_frown_close;           //old way of storing chara
        Texture2D rin_relaxed_doubt_pan;     //old way of storing chara

        //music
        Song basic;                      //old way of storing music
        Song m_daylight;                 //old way of storing music
        bool songstart = false;          //Start playing music (set to false to switch song)

        ScriptCompiler MasterScript = new ScriptCompiler();    //Handles all scripts and puts them in one place.
        int totscripts = 0;              //Gets the total amount of compiled scripts

        int actionmenuscroller = -300;   //moves the menu back and forth when it is called or closed
        int bgscroller = 0;              //moves the background on the START MENU
        int bgscrollslowerdowner = 0;    //Slows the scroll down more.
        int logoscaler = 0;              //Scales the logo X and Y.
        bool reversescaler = false;      //Reverses the X and Y.

        
        //engine bool
        bool bStart = true;               //Main game menu.  (only true on startup.)
        bool bSleep = false;              //Determines if the player is asleep.
        bool bActive = false;             //Determines if the player is active.  (walking; eating; ext)
        bool bGamerun = false;            //Continues to loop through; should be true always after start
        bool bLoner = false;              //Determines if the player is being too anti-social
        bool bDorm = false;               //Tells the game that player is in the dorm room
        bool bMenu = false;               //Calls the main action select menu.
        bool bError = false;              //calls the ERROR textbox.  halts game.
        bool bHud = false;                //will show the hud.  false will hide it
        bool bFirstrun = false;           //Sets the game up; only enable this to refresh all variables to default
        bool bShowtext = false;           //Tells the engine to show textbox and run through script
        bool bRunevent = false;           //Tells the engine to run a specific event (actions)
        bool bGameover = false;           //If the player loses; opens a new scene
        bool bWin = false;                //If the player wins; opens a new scene
        bool bClicked = false;            //is enabled for 1 frame; will send a (click)
        bool bclicking = false;           //to  determine if the player is holding the mouse button
        bool bGamePad = false;            //tells the game either Gamepad or Mouse/keyboard
        bool DpadDown = false;            //tells input that dpad is down
        bool DpadUp = false;              //tells input that dpad is up
        bool DpadLeft = false;            //tells input that dpad is left
        bool DpadRight = false;           //tells input that dpad is right
        bool bMoveChar1 = false;          //determins if we should move the chara
        bool bMoveChar2 = false;          //determins if we should move the chara
        bool fixfirstscripterror = true;  //helps patch up the "nothing to say" error at first event.

        //GAME STORY SWITCHES
        bool sMetEmi = false;      //First met emi, this will switch off that script from running
        bool sEatEmi = false;      //First time (almost) eating with Emi; switches script off
        
        //GAME STORY VARIABLES
        int MetEmiTime = 0;        //This makes it to where you eat lunch with emi 1 day after meeting her.

        string SetMusic;

        int dpadx = 0;
        int dpady = 0;
        int SelectorPosX = 0;      //Sets the Button selector along X coords; for Xbox360
        int SelectorPosY = 0;      //Sets Y axis.  (these keep it memorised too)

        string eventname = "";
        string charatalk = "No Name:\n\"";
        string ErrorReason = "Fuck, I don't know.";

        //Game Variables
        int HP;                     //Health
        int Energy;                 //Energy
        int Fat;                    //Fat
        int social;                 //Social (-antisocial / + popular)
        int Time = 1600;            //Time of Day (in 24 hour format; converts to 12.)
        int Day = 1;                //Days that have passed. 
        int DayofWeek = 1;          //Day of the week (1-7; Gets converted to names)
        string weekday = "Monday";  //Named version of above int.
        string s_class = "";                         //What class is happening today
        string s_class1 = "Ergonomics";              //First class slot
        string s_class2 = "Banana Boating 101";      //Second Class slot
        string s_class3 = "Advanced Shoe Tieing";    //Third Class slot
        int Turns = 0;              //How many actions the player has done in one game playthrough

        string playername = "Turtle";               //Default playername

        string[,] script = new string[101,500];     //MasterScript string array; holds all scripts (old)
        string dialouge = "nothing to say";         //This pulls the dialouge from script and displays it.
        int scriptreaderx = 0;                      //ScriptReaderx tells what script to read from
        int scriptreadery = 0;                      //Scriptreadery tells what line to read from


        //animation related
        string chara1;                 //used to tell the charamanager what chara to draw. slot1
        string chara2;                 //" " "  Slot 2.
        Texture2D charamanager1;       //Charamanager draws the chara to screen.
        Texture2D charamanager2;       //Same; slot 2.
        string bg1;                    //Sets background to the first one. (old)
        //Texture2D bgmanager;

        //animation frame ints
        int AbuttonFrame = 0;   //Moves the "A" button up/down
        int charamove1 = 0;     //used to move chara around
        int charamove2 = 0;     //used to move chara around
        string charadir1;      //0 = null; 1 = left; 2 = right; 3 = offleft; 4 = offrigtht.
        string charadir2;      //0 = null; 1 = left; 2 = right; 3 = offleft; 4 = offrigtht.


        //just for testing and messing
        Random Rando = new Random();         //Gives us a random generated number
        int cocks;                           //Used for keeping a random int; for debug really.
        float vibrator = 0.1f;               //Controls Vibration function for controller 1
        float vibrator2 = 0.1f;              //For Controller 2.


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.IsMouseVisible = true;
            base.Initialize();

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;


           //graphics.ToggleFullScreen();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //GUI specific loaders
            buttonup = Content.Load<Texture2D>("assets/gui/gui_button_up");
            buttondown = Content.Load<Texture2D>("assets/gui/gui_button_down");
            buttonselector = Content.Load<Texture2D>("assets/gui/gui_button_selector");
            logo = Content.Load<Texture2D>("assets/gui/tex_logo");
            logo2 = Content.Load<Texture2D>("assets/gui/logo_2");
            debugfont = Content.Load<SpriteFont>("fonts/debugfont");
            debugfontsmall = Content.Load<SpriteFont>("fonts/debugfontsmall");
            speechfont = Content.Load<SpriteFont>("fonts/speechfont");
            clockfont = Content.Load<SpriteFont>("fonts/clockfont");
            messagebox = Content.Load<Texture2D>("assets/gui/messagebox");
            messagebox2 = Content.Load<Texture2D>("assets/gui/messagebox2");
            action_menu = Content.Load<Texture2D>("assets/gui/menu_action");
            clock_tex = Content.Load<Texture2D>("assets/gui/clock");
            ButtonA = Content.Load<Texture2D>("assets/gui/gui_button_A");

            //GUI (Progress Bar)
            pgbar_center = Content.Load<Texture2D>("assets/gui/pgbar_center_empty");
            pgbar_left = Content.Load<Texture2D>("assets/gui/pgbar_left_empty");
            pgbar_right = Content.Load<Texture2D>("assets/gui/pgbar_right_empty");
            pgbar_filler_center = Content.Load<Texture2D>("assets/gui/pgbar_fill_center_empty");
            pgbar_filler_left = Content.Load<Texture2D>("assets/gui/pgbar_fill_left_empty");
            pgbar_filler_right = Content.Load<Texture2D>("assets/gui/pgbar_fill_right_empty");
            
            //Background Images
            bg_classroom = Content.Load<Texture2D>("assets/backgrounds/school_classroomart");
            bg_courtyard = Content.Load<Texture2D>("assets/backgrounds/school_courtyard");
            bg_dorm = Content.Load<Texture2D>("assets/backgrounds/school_dormkenji");
            bg_dorm_ext = Content.Load<Texture2D>("assets/backgrounds/school_dormext_start");
            bg_dormbath = Content.Load<Texture2D>("assets/backgrounds/school_dormbathroom");
            bg_dormgirl = Content.Load<Texture2D>("assets/backgrounds/school_dormemi");
            bg_forest = Content.Load<Texture2D>("assets/backgrounds/school_forest1");
            bg_gate = Content.Load<Texture2D>("assets/backgrounds/school_gate");

            //Chara
            emi_frown_close = Content.Load<Texture2D>("assets/chara/emi/emicas_frown_close");
            rin_relaxed_doubt_pan = Content.Load<Texture2D>("assets/chara/rin/rin_relaxed_doubt_pan");

            //music
            basic = Content.Load<Song>("assets/music/Ah_Eh_I_Oh_You");
            m_daylight = Content.Load<Song>("assets/music/Daylight");

            //Un-comment if I become a Microsoft Developer.  (I do not have permission to use these classes.

            //Gamer.GetFromGamertag(playername);

            

            //END UN-COMMENT

            totscripts = MasterScript.Compile();

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        //=============================================================================GAME UPDATE FUNCTION==========================================================
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            MediaPlayer.IsRepeating = true;

            frames += 1;

            if (bWin == true)
            {
                eventname = "win";
                bShowtext = true;
            }
            if (bGameover == true)
            {
                eventname = "lose";
                bShowtext = true;
            }

            //Music Controls
            if (!songstart)
            {
                if (bDorm == true) MediaPlayer.Play(m_daylight);
                if (bStart == true) MediaPlayer.Play(basic);
                songstart = true;

            }

            //charamover logic
            if (bMoveChar1 == true)
            {
                if (frames >= 0)
                {
                    if (charadir1 == "right")
                    {
                        if (charamove1 < 180) charamove1 += 4;
                        else bMoveChar1 = false;
                    }
                    if (charadir1 == "left")
                    {
                        if (charamove1 > -180) charamove1 -= 4;
                        else bMoveChar1 = false;
                    }
                    if (charadir1 == "offright")
                    {
                        if (charamove1 < 600) charamove1 += 9;
                        else bMoveChar1 = false;
                    }
                    if (charadir1 == "offleft")
                    {
                        if (charamove1 > -600) charamove1 -= 9;
                        else bMoveChar1 = false;
                    }
                }
            }


            if (frames >= 5)
            {
                AbuttonFrame++;
                if (AbuttonFrame >= 5) AbuttonFrame = 0;
                frames = 0;
            }


            //-------------------------- Controls (mouse and button actions) -----------------

            if (vibrator < 1.0f) vibrator += 0.1f;
            if (vibrator2 < 1.0f) vibrator2 += 0.1f;

            //get mouse position.
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            if (bGamePad == true)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) GamePad.SetVibration(PlayerIndex.Two, vibrator, vibrator);
                else if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Released) GamePad.SetVibration(PlayerIndex.Two, 0.0f, 0.0f);
                if (GamePad.GetState(PlayerIndex.Two).Buttons.X == ButtonState.Pressed) GamePad.SetVibration(PlayerIndex.One, vibrator2, vibrator2);
                else if (GamePad.GetState(PlayerIndex.Two).Buttons.X == ButtonState.Released) GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);

                //for pushing A to click
                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) bclicking = true;
                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released & bclicking == true)
                {
                    bClicked = true;
                    bclicking = false;
                }

                //D-pad controls
                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed) DpadDown = true;
                if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Released & DpadDown == true)
                {
                    dpady += 1;
                    DpadDown = false;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed) DpadUp = true;
                if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Released & DpadUp == true)
                {
                    dpady -= 1;
                    DpadUp = false;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed) DpadLeft = true;
                if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Released & DpadLeft == true)
                {
                    dpadx -= 1;
                    DpadLeft = false;
                }
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed) DpadRight = true;
                if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Released & DpadRight == true)
                {
                    dpadx += 1;
                    DpadRight = false;
                }
            }
            else
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed) Fat += 1;

                if (mouseState.LeftButton == ButtonState.Pressed) bclicking = true;
                if (mouseState.LeftButton == ButtonState.Released & bclicking == true)
                {
                    bClicked = true;
                    bclicking = false;
                }
            }

            if (bGamePad == true) ButtonSelector();

            dayactions();

            #region StartScreen Logic
            //handles for start screen
            if(bStart == true)
            {

                //bg_scroller
                bgscrollslowerdowner++;
                if (bgscrollslowerdowner == 3)
                {
                    bgscroller += 1;
                    if (bgscroller >= 2400) bgscroller = 0;

                    if (reversescaler == false)
                    {
                        logoscaler++;
                    }
                    else
                    {
                        logoscaler -= 1;
                    }
                    if (logoscaler == 10) reversescaler = true;
                    if (logoscaler == 0) reversescaler = false;

                    bgscrollslowerdowner = 0;
                }

                //buttons to click
                #region Button Controller
                Rectangle button1 = new Rectangle(320, 280, 160, 40);
                Rectangle button2 = new Rectangle(320, 200, 160, 40);

                if (bClicked == true)
                {
                    if (button1.Contains(mousePosition))
                    {
                        this.Exit();
                    }
                    if (button2.Contains(mousePosition))
                    {
                        bFirstrun = true;
                    }
                    else
                    {
                        if (bGamePad == true)
                        {
                            bFirstrun = true;
                        }
                    }
                }
            }
                #endregion

            #endregion

            //----------------------------------- Scripts Controls-------------------------------
            if (bFirstrun == true) setupgame();

            animateactionmenu();  //calls the animator to move the menu about.
                                  //Also handles button collision events

            //Waits for the Action Menu to be gone before drawing the text box
            if (bShowtext == true)
            {
                bMenu = false;
                if (actionmenuscroller == -300) textwindow(eventname);
            }
            
            //place events here.  it will only run once then de-activate itself.
            if (bRunevent == true)
            {
                //I just put them all into a function.
                Events();

                bRunevent = false;
            }

            if (chara1 != null) charamanager1 = Content.Load<Texture2D>("assets/chara/" + chara1 + "");
            if (chara2 != null) charamanager2 = Content.Load<Texture2D>("assets/chara/" + chara2 + "");

            //----------------------------------- Change Scenery ---------------------------------
            if (bDorm == true) bg_manage = bg_dorm;

            if (bg1 != null) bg_manage = Content.Load<Texture2D>("assets/backgrounds/" + bg1 + "");
            if (SetMusic != null) m_daylight = Content.Load<Song>("assets/music/" + SetMusic + "");

            bClicked = false;

            base.Update(gameTime);
        }

        //======================================================================================GAME DRAW FUNCTION===============================================
        protected override void Draw(GameTime gameTime)
        {

            //set background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            #region StartMenu
            if (bStart == true)
            {

                spriteBatch.Begin();

                //scrolling background
                spriteBatch.Draw(bg_gate, new Rectangle(0 - bgscroller, 0, 800, 480),Color.Gray);
                spriteBatch.Draw(bg_forest, new Rectangle(800 - bgscroller, 0, 800, 480), Color.Gray);
                spriteBatch.Draw(bg_courtyard, new Rectangle(1600 - bgscroller, 0, 800, 480), Color.Gray);
                spriteBatch.Draw(bg_gate, new Rectangle(2400 - bgscroller, 0, 800, 480), Color.Gray);

                //debug info
                spriteBatch.DrawString(debugfont, "IT COMPILED! YAY!", new Vector2(20, 20), Color.White);
                spriteBatch.DrawString(debugfontsmall, "Debug Font loaded.", new Vector2(20, 40), Color.White);
                spriteBatch.DrawString(debugfontsmall, "Total Scripts found: " + totscripts, new Vector2(20, 50), Color.White);
                spriteBatch.DrawString(debugfontsmall, "Random Script Line: " + MasterScript.Read(13,0), new Vector2(600, 20), Color.White);
                spriteBatch.DrawString(debugfontsmall, GameInfo, new Vector2(530, 460), Color.White);
                spriteBatch.DrawString(debugfontsmall, "Produced by Jacob Karleskint and Tclub Games", new Vector2(10, 460), Color.White);
                
                //menu buttons
                spriteBatch.Draw(messagebox, new Rectangle(240, 0, 320, 180), Color.White);
                spriteBatch.Draw(logo2, new Rectangle(240 - logoscaler, -20 - logoscaler, 320 + logoscaler + logoscaler, 250 + logoscaler + logoscaler), Color.White);
                spriteBatch.Draw(buttonup, new Rectangle(320, 280, 160, 40), Color.White);
                spriteBatch.DrawString(debugfont, "Quit", new Vector2(375, 285), Color.White);
                spriteBatch.Draw(buttonup, new Rectangle(320, 200, 160, 40), Color.White);
                spriteBatch.DrawString(debugfont, "Start Game", new Vector2(340, 205), Color.White);

                spriteBatch.End();
            }

            #endregion

            spriteBatch.Begin();

            //background manage here
            if (bDorm == true)  //CHANGE THIS TO GO OFF A DIFFERENT BOOL!!!!
            {
                spriteBatch.Draw(bg_manage, new Rectangle(0, 0, 800, 480), Color.White);
            }

            actionmenu();
            if (bMenu == true) classmenu();

            //Draw Progress bars.
            if (bHud == true) spriteBatch.Draw(messagebox, new Rectangle(0, -5, 200, 125), Color.White);
            pbar(10, 10, HP, "HP");
            pbar(10, 35, Energy, "Energy");
            pbar(10, 60, social, "Social");
            pbar(10, 85, Fat, "Fat");
            if (bHud == true) clock();

            if (bShowtext == true)
            {
                if (actionmenuscroller == -300)
                {
                    if (chara1 != null) spriteBatch.Draw(charamanager1, new Rectangle(200 + charamove1, -120, charamanager1.Width, charamanager1.Height), Color.White);
                    if (chara2 != null) spriteBatch.Draw(charamanager2, new Rectangle(420 + charamove2, -120, charamanager2.Width, charamanager2.Height), Color.White);
                    spriteBatch.Draw(messagebox2, new Rectangle(0, 355, 797, 125), Color.White);
                    spriteBatch.DrawString(speechfont, dialouge, new Vector2(30, 360), Color.White);
                    spriteBatch.Draw(ButtonA, new Rectangle(750, 440 + AbuttonFrame, 24, 24), Color.White);
                }
                
            }


            spriteBatch.End();

            #region Debug/Error
            //lets change this to debug window/error handler
            if (bError == true)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(messagebox, new Rectangle(60, 260, 600, 120), Color.White);
                spriteBatch.DrawString(debugfont, "FUCK! A PROBLEM HAPPENED!", new Vector2(90, 280), Color.White);
                spriteBatch.DrawString(debugfontsmall, "ERROR: " + ErrorReason, new Vector2(90, 310), Color.White);
                spriteBatch.DrawString(debugfontsmall, "Info: "  + GameInfo, new Vector2(90, 345), Color.White);
                spriteBatch.End();

            }

            #endregion

            base.Draw(gameTime);
        }

        //========================================================================================MY CUSTOM FUNCTIONS=============================================

        //starts game logic by seting up the rules and variables
        protected void setupgame()
        {
            if (bStart == true)
            {
                HP = 60;
                Energy = 60;
                social = 40;
                Fat = 20;
                bDorm = true;
                bHud = true;
                ErrorReason = "LOL, there is no script to run.  Sorry, bro.";
                bError = false;
                bMenu = true;
                bFirstrun = false;
                bStart = false;
                songstart = false;
            }
            
        }

        //draw progress bar.
        protected void pbar(int pbarx, int pbary, int V, string name)
        {

            if (bHud == true)
            {
                if (V >= 10)
                {
                    spriteBatch.Draw(pgbar_filler_left, new Rectangle(pbarx, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_left, new Rectangle(pbarx, pbary, 10, 20), Color.White);
                }
                if (V >= 20)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 10, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 10, pbary, 10, 20), Color.White);
                }
                if (V >= 30)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 20, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 20, pbary, 10, 20), Color.White);
                }
                if (V >= 40)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 30, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 30, pbary, 10, 20), Color.White);
                }
                if (V >= 50)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 40, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 40, pbary, 10, 20), Color.White);
                }
                if (V >= 60)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 50, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 50, pbary, 10, 20), Color.White);
                }
                if (V >= 70)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 60, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 60, pbary, 10, 20), Color.White);
                }
                if (V >= 80)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 70, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 70, pbary, 10, 20), Color.White);
                }
                if (V >= 90)
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 80, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_center, new Rectangle(pbarx + 80, pbary, 10, 20), Color.White);
                }
                if (V >= 95)
                {
                    spriteBatch.Draw(pgbar_filler_right, new Rectangle(pbarx + 90, pbary, 10, 20), Color.Green);
                }
                else
                {
                    spriteBatch.Draw(pgbar_filler_right, new Rectangle(pbarx + 90, pbary, 10, 20), Color.White);
                }

                spriteBatch.Draw(pgbar_left, new Rectangle(pbarx, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 10, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 20, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 30, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 40, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 50, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 60, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 70, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_center, new Rectangle(pbarx + 80, pbary, 10, 20), Color.White);
                spriteBatch.Draw(pgbar_right, new Rectangle(pbarx + 90, pbary, 10, 20), Color.White);

                spriteBatch.DrawString(debugfont, V + "%", new Vector2(pbarx + 35, pbary - 3), Color.White);
                spriteBatch.DrawString(debugfont, name, new Vector2(pbarx + 103, pbary - 4), Color.White);

            }

        }

        //class schedule box
        protected void classmenu()
        {
            spriteBatch.Draw(action_menu, new Rectangle(500, 340, 400, 400), Color.White);
            spriteBatch.DrawString(debugfont, weekday + "      Day: " + Day, new Vector2(520, 360), Color.White);
            spriteBatch.DrawString(speechfont, "Schedule: \n   " + s_class, new Vector2(520, 395), Color.White);
        }

        protected void dayactions()
        {

            if (weekday == "Monday")
            {
                s_class = s_class1;
            }
         
            if (weekday == "Wednesday")
            {
                s_class = s_class2;
            }
            if (weekday == "Friday")
            {
                s_class = s_class3;
            }
            if (weekday == "Tuesday" || weekday == "Thursday" || weekday == "Saturday" || weekday == "Sunday") s_class = "";
        }

        //Action Menu
        protected void actionmenu()
        {

            //Action Menu
            spriteBatch.Draw(action_menu, new Rectangle(actionmenuscroller, 120, 300, 400), Color.White);
            spriteBatch.DrawString(debugfont, "Action Select Menu", new Vector2(52 + actionmenuscroller, 160), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(30 + actionmenuscroller, 220, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(160 + actionmenuscroller, 220, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(30 + actionmenuscroller, 260, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(160 + actionmenuscroller, 260, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(30 + actionmenuscroller, 300, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(160 + actionmenuscroller, 300, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(30 + actionmenuscroller, 340, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(160 + actionmenuscroller, 340, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(30 + actionmenuscroller, 380, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(160 + actionmenuscroller, 380, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(30 + actionmenuscroller, 420, 120, 30), Color.White);
            spriteBatch.Draw(buttonup, new Rectangle(160 + actionmenuscroller, 420, 120, 30), Color.White);

            //Text on buttons
            spriteBatch.DrawString(debugfont, "Sleep", new Vector2(60 + actionmenuscroller, 221), Color.White);
            spriteBatch.DrawString(debugfont, "Text", new Vector2(195 + actionmenuscroller, 221), Color.White);
            spriteBatch.DrawString(debugfont, "TV", new Vector2(78 + actionmenuscroller, 261), Color.White);
            spriteBatch.DrawString(debugfont, "Go Eat", new Vector2(188 + actionmenuscroller, 261), Color.White);
            spriteBatch.DrawString(debugfont, "Xbox", new Vector2(70 + actionmenuscroller, 301), Color.White);
            spriteBatch.DrawString(debugfont, "Homework", new Vector2(175 + actionmenuscroller, 301), Color.White);
            spriteBatch.DrawString(debugfont, "Write", new Vector2(62 + actionmenuscroller, 341), Color.White);
            spriteBatch.DrawString(debugfont, "Study", new Vector2(192 + actionmenuscroller, 341), Color.White);
            spriteBatch.DrawString(debugfont, "Music", new Vector2(63 + actionmenuscroller, 381), Color.White);
            spriteBatch.DrawString(debugfont, "Porn Time", new Vector2(170 + actionmenuscroller, 381), Color.White);
            spriteBatch.DrawString(debugfont, "Walk", new Vector2(70 + actionmenuscroller, 421), Color.White);
            spriteBatch.DrawString(debugfont, "Sleep", new Vector2(190 + actionmenuscroller, 421), Color.White);

            if (bMenu == true & actionmenuscroller >= -20 & bGamePad == true)
            {
                spriteBatch.Draw(buttonselector, new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 120, 30), Color.White);
            }

        }

        //Action Menu Animator
        protected void animateactionmenu()
        {

            #region Animation
            if (bMenu == true)
            {
                if (actionmenuscroller < -20)
                {
                    actionmenuscroller += 10;
                }
            }

            if (bMenu == false)
            {
                if (bStart == false)
                {
                    if (actionmenuscroller > -300)
                    {
                        actionmenuscroller -= 7;
                    }
                }
            }
            #endregion  //animates the menu

            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            Rectangle button3 = new Rectangle(30 + actionmenuscroller, 220, 130, 30);
            Rectangle button9 = new Rectangle(160 + actionmenuscroller, 220, 130, 30);
            Rectangle button4 = new Rectangle(30 + actionmenuscroller, 260, 130, 30);
            Rectangle button10 = new Rectangle(160 + actionmenuscroller, 260, 130, 30);
            Rectangle button5 = new Rectangle(30 + actionmenuscroller, 300, 130, 30);
            Rectangle button11 = new Rectangle(160 + actionmenuscroller, 300, 130, 30);
            Rectangle button6 = new Rectangle(30 + actionmenuscroller, 340, 130, 30);
            Rectangle button12 = new Rectangle(160 + actionmenuscroller, 340, 130, 30);
            Rectangle button7 = new Rectangle(30 + actionmenuscroller, 380, 130, 30);
            Rectangle button13 = new Rectangle(160 + actionmenuscroller, 380, 130, 30);
            Rectangle button8 = new Rectangle(30 + actionmenuscroller, 420, 130, 30);
            Rectangle button14 = new Rectangle(160 + actionmenuscroller, 420, 130, 30);

            if (bClicked == true)
            {
                if (actionmenuscroller == -20)
                {
                    if (bGamePad == false)
                    {
                        //  FOR NORMAL MOUSE OPERATION
                        if (button3.Contains(mousePosition))
                        {
                            bShowtext = true;
                            bRunevent = true;
                            eventname = "sleep";
                        }
                        if (button4.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "tv";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button5.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "xbox";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button6.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "write";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button7.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "music";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button8.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "walk";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button9.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "text";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button10.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "eat";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button11.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "homework";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button12.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "study";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button13.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "porn";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button14.Contains(mousePosition))
                        {
                            bRunevent = true;
                            eventname = "sleep";
                            bMenu = false;
                            bShowtext = true;
                        }
                    }
                    else
                    {
                        //FOR GAME PAD OPERATION
                        if (button3.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bShowtext = true;
                            bRunevent = true;
                            eventname = "sleep";
                        }
                        if (button4.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "tv";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button5.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "xbox";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button6.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "write";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button7.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "music";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button8.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "walk";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button9.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "text";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button10.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "eat";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button11.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "homework";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button12.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "study";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button13.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "porn";
                            bMenu = false;
                            bShowtext = true;
                        }
                        if (button14.Intersects(new Rectangle(SelectorPosX + actionmenuscroller, SelectorPosY, 130, 30)))
                        {
                            bRunevent = true;
                            eventname = "sleep";
                            bMenu = false;
                            bShowtext = true;
                        }

                        //Make sure the selector doesn't go out of bounds.
                        if (dpady >= 7)
                        {
                            if (dpadx == 1)
                            {
                                dpady = 1;
                                dpadx = 2;
                            }
                            else
                            {
                                dpady = 6;
                            }
                        }
                        if (dpady == 0)
                        {
                            if (dpadx == 2)
                            {
                                dpady = 6;
                                dpadx = 1;
                            }
                            else
                            {
                                dpadx = 6;
                            }
                        }
                        if (dpadx >= 3) dpadx = 2;
                        if (dpadx == 0) dpadx = 1;

                    }
                }

            }

        }


        //button selector mover
        protected void ButtonSelector()
        {         

            if (bMenu == true)
            {

                if (dpady >= 7)
                {
                    if (dpadx == 1)
                    {
                        dpady = 1;
                        dpadx = 2;
                    }
                    else
                    {
                        dpady = 6;
                    }
                }
                if (dpady == 0)
                {
                    if (dpadx == 2)
                    {
                        dpady = 6;
                        dpadx = 1;
                    }
                    else
                    {
                        dpadx = 6;
                    }
                }
                if (dpadx >= 3) dpadx = 2;
                if (dpadx == 0) dpadx = 1;

                if (dpadx == 1) SelectorPosX = 30;
                if (dpadx == 2) SelectorPosX = 160;
                if (dpady == 1) SelectorPosY = 220;
                if (dpady == 2) SelectorPosY = 260;
                if (dpady == 3) SelectorPosY = 300;
                if (dpady == 4) SelectorPosY = 340;
                if (dpady == 5) SelectorPosY = 380;
                if (dpady == 6) SelectorPosY = 420;

            }
        }

        //Text window
        protected void textwindow(string ename)
        {

            ename = eventname;

            //set the script reader to the correct script
            if (scriptreadery == 0)
            {
                while (MasterScript.Read(scriptreaderx, 0) != ename)
                {
                    scriptreaderx++;
                   
                    if (scriptreaderx >= 100)
                    {
                        ErrorReason = "There is no script found for '" + ename + "' Please check spelling or \nif the file is missing.";
                        bError = true;
                        bShowtext = false;
                        ename = MasterScript.Read(scriptreaderx, 0);

                    }
                }

                //set the script reader to the correct line.
                scriptreadery++;
                if (MasterScript.Read(scriptreaderx, scriptreadery) != null) dialouge = MasterScript.Read(scriptreaderx, scriptreadery);
                
            }
            //var mouseState = Mouse.GetState();
            if (bClicked == true)
            {
                //fixfirstscripterror = false;
                if (MasterScript.Read(scriptreaderx, scriptreadery + 1) != null)
                {
                    scriptreadery++;

                    //intercept script action things here, so actions happen and are not displayed as dialogue.
                    if (MasterScript.Read(scriptreaderx, scriptreadery) == "charaevent show 1")
                    {
                        scriptreadery++;
                        chara1 = MasterScript.Read(scriptreaderx, scriptreadery);
                        scriptreadery++;

                    }
                    if (MasterScript.Read(scriptreaderx, scriptreadery) == "charaevent show 2")
                    {
                        scriptreadery++;
                        chara2 = MasterScript.Read(scriptreaderx, scriptreadery);
                        scriptreadery++;

                    }
                    if (MasterScript.Read(scriptreaderx, scriptreadery) == "charaevent exit")
                    {
                        chara1 = null;
                        chara2 = null;
                        charamove1 = 0;
                        charamove2 = 0;
                        scriptreadery++;
                    }
                    if (MasterScript.Read(scriptreaderx, scriptreadery) == "bgchange")
                    {
                        scriptreadery++;
                        bg1 = MasterScript.Read(scriptreaderx, scriptreadery);
                        scriptreadery++;
                    }
                    if (MasterScript.Read(scriptreaderx, scriptreadery) == "gameover")
                    {
                        this.Exit();
                    }
                    if (MasterScript.Read(scriptreaderx, scriptreadery) == "music")
                    {
                        scriptreadery++;
                        SetMusic = MasterScript.Read(scriptreaderx, scriptreadery);
                        songstart = false;
                        scriptreadery++;
                    }
                    if (MasterScript.Read(scriptreaderx, scriptreadery) == "charaevent move 1")
                    {
                        scriptreadery++;
                        charadir1 = MasterScript.Read(scriptreaderx, scriptreadery);
                        bMoveChar1 = true;
                        scriptreadery++;
                    }

                    if (MasterScript.Read(scriptreaderx, scriptreadery) != null) dialouge = MasterScript.Read(scriptreaderx, scriptreadery);
                }
                else
                {
                    scriptreaderx = 0;
                    scriptreadery = 0;
                    bShowtext = false;
                    bMenu = true;
                }
            }
            //if(script[scriptreaderx,scriptreadery] != null) dialouge = script[scriptreaderx, scriptreadery];
        }
        
        //Used to add time safely
        private void addtime(int v)
        {

            int oldt;

                if (Time + v > 2359)
                {
                    oldt = Time + v - 2400;
                    Time = oldt;
                    Day++;
                    if (DayofWeek >= 7) DayofWeek = 1;
                    else DayofWeek++;
                }
                else
                {
                    Time += v;
                }

                if (DayofWeek == 1) weekday = "Monday";
                if (DayofWeek == 2) weekday = "Tuesday";
                if (DayofWeek == 3) weekday = "Wednesday";
                if (DayofWeek == 4) weekday = "Thursday";
                if (DayofWeek == 5) weekday = "Friday";
                if (DayofWeek == 6) weekday = "Saturday";
                if (DayofWeek == 7) weekday = "Sunday";

        }

        //formats time so it is readable and draws it
        private void clock()
        {

            int nTime;
            bool bPM = false;

            if (Time >= 1300)
            {
                nTime = Time - 1200;
                bPM = true;
            }
            else
            {
                bPM = false;
                nTime = Time;
            }

            if (nTime == 0) nTime = 1200;

            spriteBatch.Draw(clock_tex, new Rectangle(650, 5, 150, 50), Color.White);

            if (bPM == true) spriteBatch.DrawString(clockfont, nTime + " PM", new Vector2(666, 12), Color.Red);
            else
                spriteBatch.DrawString(clockfont, nTime + "  AM", new Vector2(666, 12), Color.Red);

        }

        private void addenergy(int v)
        {
            if (Energy + v > 100)
            {
                Energy = 100;
            }
            else Energy += v;

            if (Energy > 120) bGameover = true;
            if (Energy <= 0) bGameover = true;
        }

        private void addhp(int v)
        {
            if (HP + v > 100)
            {
                HP = 100;
            }
            else HP += v;

            if (HP <= 0) bGameover = true;
            if (HP >= 100) bGameover = true;
        }

        private void addsocial(int v)
        {

            if (social + v > 100)
            {
                social = 100;
            }
            else social += v;

            if (social > 99) bGameover = true;
            if (social <= 0) bWin = true;

        }

        private void addfat(int v)
        {
            if (Fat + v > 100)
            {
                Fat = 100;
            }
            else Fat += v;

            if (Fat > 99) bGameover = true;
        }

        //all the events!
        private void Events()
        {
            int R = 0;
            R = Rando.Next(5);

            if (eventname == "sleep")
            {
                addtime(800);
                addenergy(20);
                addfat(2);
            }
            if (eventname == "tv")
            {
                addtime(200);
                addenergy(-5);
                addfat(4);
                addhp(-1);
                addsocial(-2);
            }
            if (eventname == "xbox")
            {
                addtime(400);
                addenergy(-6);
                addfat(2);
                addhp(-7);
                addsocial(-1);
            }
            if (eventname == "write")
            {
                addtime(200);
                addenergy(-5);
                addfat(1);
                addhp(-2);
                addsocial(-1);
            }
            if (eventname == "music")
            {
                addtime(300);
                addenergy(-4);
                addhp(-4);
                addsocial(-1);
                addfat(2);
            }
            if (eventname == "walk")
            {
                addtime(200);
                addenergy(-10);
                addhp(-8);
                addfat(-3);
                addsocial(2);
                //Meet Emi for first time triggered event.
                if (Time >= 600 & Time <= 900)      //time between 6am to 9am is when you will meet emi
                {
                    if (sMetEmi == false)           //if you have already met her, you cannot get it again.
                    {
                        MetEmiTime = Day;
                        eventname = "walk_meetemi";
                        addsocial(1);
                        addtime(100);
                        addhp(-2);
                        addfat(-1);
                        sMetEmi = true;
                    }
                }
            }
            if (eventname == "text")
            {
                //this is a special case
            }
            if (eventname == "eat")
            {
                addtime(200);
                addenergy(-10);
                addhp(10);
                addfat(2);
                addsocial(1);
                if (sMetEmi == true & sEatEmi == false)
                {
                    if (MetEmiTime <= MetEmiTime + 1)
                    {
                        eventname = "eat_emi";
                        addsocial(1);
                        addtime(100);
                        sEatEmi = true;
                    }
                }
            }
            if (eventname == "homework")
            {
                addtime(200);
                addenergy(-5);
                addhp(-2);
                addfat(1);
                addsocial(-1);
            }
            if (eventname == "study")
            {
                addtime(300);
                addenergy(-6);
                addhp(-3);
                addfat(1);
                addsocial(-1);
            }
            if (eventname == "porn")
            {
                addtime(100);
                addenergy(-10);
                addhp(-8);
                addfat(6);
                addsocial(-2);
            }

        }

    }
}
