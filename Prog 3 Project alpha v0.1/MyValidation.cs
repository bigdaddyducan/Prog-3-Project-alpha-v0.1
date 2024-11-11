using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_3_Project_alpha_v0._1
{
    internal class MyValidation
    {
        public static bool validLength(string txt, int min, int max)
        {
            bool ok = true;
            if (string.IsNullOrEmpty(txt))
                ok = false;
            else if (txt.Length < min || txt.Length > max)
                ok = false;

            return ok;
        }

        public static bool validNumber(string txt)
        {
            bool ok = true;

            for (int i = 0; i < txt.Length; i++)
            {
                if (!(char.IsNumber(txt[i])))
                {
                    ok = false;
                }
            }
            return ok;
        }

        public static bool validLetter(string txt)
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    if (!(char.IsLetter(txt[i])))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validLetterWhitespace(string txt)
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = true;
            }
            else
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    if (!(char.IsLetter(txt[i])) && !(char.IsWhiteSpace(txt[i])))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool validLetterNumberWhitespace(string txt)
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = true;
            }
            else
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    if (!(char.IsLetter(txt[i])) && !(char.IsWhiteSpace(txt[i])) && !(char.IsNumber(txt[i])))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool validForename(string txt)
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    if (!(char.IsLetter(txt[i])) && !(char.IsWhiteSpace(txt[i])) && !(txt[i].Equals('-')))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }
        public static bool validSurname(string txt)
        {
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int i = 0; i < txt.Length; i++)
                {
                    if (!(char.IsLetter(txt[i])) && !(char.IsWhiteSpace(txt[i])) && !(txt[i].Equals('-')) && !(txt[i].Equals("\'")))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public static bool vaidDogDOB(string txt)
        {
            DateTime currentDate = DateTime.Now;
            DateTime dogDOB = Convert.ToDateTime(txt);

            TimeSpan t = currentDate - dogDOB;
            double NoOfDays = t.TotalDays;

            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                if (NoOfDays <= 56)
                {
                    ok = false;
                }
            }
            return ok;
        }

        public static String firstLetterEachWordToUpper(String word)
        {
            Char[] array = word.ToCharArray();

            if (Char.IsLower(array[0]))
            {
                array[0] = Char.ToUpper(array[0]);
            }


            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == '\0')
                {
                    if (Char.IsLower(array[i]))
                    {
                        array[i] = Char.ToUpper(array[i]);
                    }
                }
                else
                {
                    array[i] = Char.ToLower(array[i]);
                }
            }
            return new String(array);
        }

        public static String EachLetterToUpper(String word)
        {
            Char[] array = word.ToCharArray();

            for (int i = 1; i < array.Length; i++)
            {
                if (Char.IsLower(array[i]))
                {
                    array[i] = Char.ToUpper(array[i]);
                }
            }
            return new string(array);
        }
    }
}
