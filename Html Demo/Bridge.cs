using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Html_Demo
{
    public static class Bridge
    {   
        #region Properties

        /// <summary>
        /// Gets the stylesheet for sample documents
        /// </summary>
        public static string StyleSheet
        {
            get {
                return @"
                    h1, h2, h3 { color: navy; font-weight:normal; }
                    body { font:10pt Tahoma }
		            pre  { border:solid 1px gray; background-color:#eee; padding:1em }
                    .gray    { color:gray; }
                    .example { background-color:#efefef; corner-radius:5px; padding:0.5em; }
                    .caption { font-weight:bold }
                    .whitehole { background-color:white; corner-radius:5px; padding:10px; }
                ";
            }
        }

        /// <summary>
        /// Gets a star image
        /// </summary>
        public static Image StarIcon
        {
            get { return Properties.Resources.favorites32; }
        }

        /// <summary>
        /// Gets the font icon
        /// </summary>
        public static Image FontIcon
        {
            get { return Properties.Resources.font32; }
        }

        /// <summary>
        /// Gets the comment icon
        /// </summary>
        public static Image CommentIcon
        {
            get { return Properties.Resources.comment16; }
        }
        
        /// <summary>
        /// Gets the image icon
        /// </summary>
        public static Image ImageIcon
        {
            get { return Properties.Resources.image32; }
        }

        /// <summary>
        /// Gets the method icon
        /// </summary>
        public static Image MethodIcon
        {
            get { return Properties.Resources.method16; }
        }

        /// <summary>
        /// Gets the property icon
        /// </summary>
        public static Image PropertyIcon
        {
            get { return Properties.Resources.property16; }
        }



        #endregion

        #region Methods

        /// <summary>
        /// Says hello with a message box
        /// </summary>
        public static void SayHello()
        {
            MessageBox.Show("Hello you!");
        }

        public static void ShowSampleForm()
        {
            using (SampleForm f = new SampleForm())
            {
                f.ShowDialog();
            }
        }

        #endregion
    }
}
