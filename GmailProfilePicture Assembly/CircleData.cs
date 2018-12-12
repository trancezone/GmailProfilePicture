using System;

namespace Techiix.Librarian.Android.Views
{
    /// <name>CircleData</name>
    /// <summary>
    /// Defines the basic functionality of a principal object.
    /// </summary>
    internal class CircleData
    {
        public float X = 0; //a X cooridante of the circle's center
        public float Y = 0; //a Y cooridante of the circle's center
        public float Radius = 0; //the circle's radius

        /// <summary>
        /// Initializes an object
        /// </summary>
        /// 
        /// <Parameters>
        /// radiusDpi: A radius of the circle in screen independent coordinates 
        /// density: a density of screen
        /// </Parameters>
        /// 
        /// <Precondition>
        /// the input arguments are not checked
        /// </Precondition>
        /// 
        /// <Postcondition>
        /// the radius is calculated from the input arguments and assigned to the property
        /// </Postcondition>  
        public CircleData(float radiusDpi, float density)
        {
            this.Radius = radiusDpi * density;
        }
    }
}