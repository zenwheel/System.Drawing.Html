/*
 * Syntax highlighting by Parsing the RTF file format.
 * Sample program.
 * Copyright Alun Evans 2006
 * */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Html_Demo
{
    public static class SyntaxHilight
    {
        public static void AddColoredText(string strTextToAdd, RichTextBox rtb)
        {
            //Use the RichTextBox to create the initial RTF code
            rtb.Clear();
            rtb.AppendText(strTextToAdd);
            string strRTF = rtb.Rtf;
            rtb.Clear();

            /* 
             * ADD COLOUR TABLE TO THE HEADER FIRST 
             * */

            // Search for colour table info, if it exists (which it shouldn't)
            // remove it and replace with our one
            int iCTableStart = strRTF.IndexOf("colortbl;");

            if (iCTableStart != -1) //then colortbl exists
            {
                //find end of colortbl tab by searching
                //forward from the colortbl tab itself
                int iCTableEnd = strRTF.IndexOf('}', iCTableStart);
                strRTF = strRTF.Remove(iCTableStart, iCTableEnd - iCTableStart);

                //now insert new colour table at index of old colortbl tag
                strRTF = strRTF.Insert(iCTableStart,
                    // CHANGE THIS STRING TO ALTER COLOUR TABLE
                    "colortbl ;\\red255\\green0\\blue0;\\red0\\green128\\blue0;\\red0\\green0\\blue255;}");
            }

            //colour table doesn't exist yet, so let's make one
            else
            {
                // find index of start of header
                int iRTFLoc = strRTF.IndexOf("\\rtf");
                // get index of where we'll insert the colour table
                // try finding opening bracket of first property of header first                
                int iInsertLoc = strRTF.IndexOf('{', iRTFLoc);

                // if there is no property, we'll insert colour table
                // just before the end bracket of the header
                if (iInsertLoc == -1) iInsertLoc = strRTF.IndexOf('}', iRTFLoc) - 1;

                // insert the colour table at our chosen location                
                strRTF = strRTF.Insert(iInsertLoc,
                    // CHANGE THIS STRING TO ALTER COLOUR TABLE
                    "{\\colortbl ;\\red128\\green0\\blue0;\\red0\\green128\\blue0;\\red0\\green0\\blue255;}");
            }

            /*
             * NOW PARSE THROUGH RTF DATA, ADDING RTF COLOUR TAGS WHERE WE WANT THEM
             * In our colour table we defined:
             * cf1 = red  
             * cf2 = green
             * cf3 = blue             
             * */

            for (int i = 0; i < strRTF.Length; i++)
            {
                if (strRTF[i] == '<')
                {
                    //add RTF tags after symbol 
                    //Check for comments tags 
                    if (strRTF[i + 1] == '!')
                        strRTF = strRTF.Insert(i + 4, "\\cf2 ");
                    else
                        strRTF = strRTF.Insert(i + 1, "\\cf1 ");
                    //add RTF before symbol
                    strRTF = strRTF.Insert(i, "\\cf3 ");

                    //skip forward past the characters we've just added
                    //to avoid getting trapped in the loop
                    i += 6;
                }
                else if (strRTF[i] == '>')
                {
                    //add RTF tags after character
                    strRTF = strRTF.Insert(i + 1, "\\cf0 ");
                    //Check for comments tags
                    if (strRTF[i - 1] == '-')
                    {
                        strRTF = strRTF.Insert(i - 2, "\\cf3 ");
                        //skip forward past the 6 characters we've just added
                        i += 8;
                    }
                    else
                    {
                        strRTF = strRTF.Insert(i, "\\cf3 ");
                        //skip forward past the 6 characters we've just added
                        i += 6;
                    }
                }
            }
            rtb.Rtf = strRTF;
        }
    }
}
