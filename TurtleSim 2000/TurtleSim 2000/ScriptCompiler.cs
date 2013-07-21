using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim_2000
{
    class ScriptCompiler
    {

        string[,] MasterScript = new string[101, 500];
        Basic basic = new Basic();  //Declares all basic script pages
        Emi emi = new Emi();    //Declares Emi's script pages
        Minor minor = new Minor();   //Declares all minor chara's pages
        int S;  //Script number
        int L;  //Line Number  (used to WRITE TO master)
        int _L;  //used to read FROM pages

        public ScriptCompiler()
        {
        }

        public int Compile()
        {

            //compile Basic scripts into Master Script Book
            while (basic.readline(_L) != "!")
            {
                if (basic.readline(_L) == "break")
                {
                    _L++;
                    L = 0;
                    S++;
                }
                MasterScript[S, L] = basic.readline(_L);
                L++;
                _L++;

            }

            //compile Emi's Scripts into Master Script Book
            _L = 0;
            L = 0;
            S++;
            while (emi.readline(_L) != "!")
            {
                if (emi.readline(_L) == "break")
                {
                    _L++;
                    L = 0;
                    S++;
                }

                MasterScript[S, L] = emi.readline(_L);
                L++;
                _L++;
            }

            //compile Minor's Scripts into Master Script Book
            _L = 0;
            L = 0;
            S++;
            while (minor.readline(_L) != "!")
            {
                if (minor.readline(_L) == "break")
                {
                    _L++;
                    L = 0;
                    S++;
                }

                MasterScript[S, L] = minor.readline(_L);
                L++;
                _L++;
            }

            return S;
            

        }

        public string Read(int S, int L)
        {

            return MasterScript[S, L];

        }

    }
}
