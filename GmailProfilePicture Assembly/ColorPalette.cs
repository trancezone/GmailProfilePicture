using System;
using System.Collections.Generic;
using Android.Graphics;

namespace Techiix.Librarian.Android.Views
{
    /// <name>ColorPalette</name>
    /// <summary>
    /// Selects a randomly a color from predefined pallet
    /// </summary>
    internal class ColorPalette
    {
        private static Random rnd = new Random(); //a random number generator
        private static Color[] COLOR_PALETTE; //Contains a predefined palette of colors
        private static ColorPalette instance = null; //Contains an instance of the class (singlton pattern)
        private static Dictionary<string, Color> associateCollorText = new Dictionary<string, Color>(); //a dictionary used to associate the passed text and randomly selected colors


        /// <summary>
        /// Initializes the class and creates the pallet
        /// </summary>
        /// 
        /// <Postcondition>
        /// the created pallet is stored 
        /// </Postcondition> 
        public ColorPalette()
        {
            ColorPalette.COLOR_PALETTE = new Color[] {
                Color.ParseColor("#f58559"),
                Color.ParseColor("#f9a43e"),
                Color.ParseColor("#e4c62e"),
                Color.ParseColor("#67bf74"),
                Color.ParseColor("#59a2be"),
                Color.ParseColor("#2093cd"),
                Color.ParseColor("#ad62a7")
            };
        }

        /// <summary>
        /// Selects randomly a color from the pallet and associates the passed text and the color. Subsequent calls  
        /// with the same argument value will return the same color
        /// </summary>
        /// 
        /// <Parameters>
        /// textToAssociate: A text that is associated to the color
        /// </Parameters>
        /// 
        /// <Precondition>
        /// the input arguments are not checked
        /// </Precondition>
        /// 
        /// <Postcondition>
        /// A randomly selected color is associatd with the text and stored
        /// </Postcondition> 
        /// 
        /// <Return>
        /// Color: a randomly selected color from the pallet
        /// </Return> 
        public static Color Next(string textToAssociate)
        {
            if (instance == null)
                ColorPalette.instance = new ColorPalette();

            if (ColorPalette.associateCollorText.ContainsKey(textToAssociate))
                return ColorPalette.associateCollorText[textToAssociate];

            Color randomColor = ColorPalette.COLOR_PALETTE[ColorPalette.rnd.Next(0, ColorPalette.COLOR_PALETTE.Length)];
            ColorPalette.associateCollorText.Add(textToAssociate, randomColor);
            return randomColor;
        }
    }
}