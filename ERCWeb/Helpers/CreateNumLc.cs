using ERCWeb.Models;
using System;
using System.Collections;
using System.Linq;

namespace ERCWeb.Helpers
{
    public class CreateNumLc
    {
        public static string GenNumLc()
        {
            Random rnd = new Random();

            string NewNumLc = string.Empty;
            for (int i = 0; i < 10; i++)
                NewNumLc = String.Concat(NewNumLc, rnd.Next(10).ToString());
            return NewNumLc;
        }
        
        public static string CheckNum(LcModel lc) {

            string NewNumLc = GenNumLc();

            foreach (var item in lc.NumLc)
            {
                if (NewNumLc == item.ToString())
                {
                    NewNumLc = GenNumLc();
                }
            }
            return NewNumLc;
        }

    }
}
