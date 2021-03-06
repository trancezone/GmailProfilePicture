﻿using System;

using Android.Util;
using Android.Content;
using Android.Views;
using Android.Content.Res;
using Android.Text;
using Android.Graphics;
using Android.Runtime;

namespace Techiix.Librarian.Android.Views
{
    /// <name>GmilProfilePicture</name>
    /// <summary>
    /// Displays a gmail like profile picture contating a text in middle of circle
    /// </summary>
    [Register("techiix.android.views.GmailProfilePicture")]
    public class GmailProfilePicture : View
    {
        private static readonly int     DEFAULT_RADIUS = 30;
        private static readonly string  DEFAULT_DISPLAY_TEXT = "N/A";
        private static readonly int     DEFAULT_TEXT_SIZE = 24;

        private string displayText; //Contains a text that is shown
        private int radius; //Contains a value for radius
        private int textSize; //Contains a size of the text
        private CircleData circleData; //Values of the properties defining the circle
        private TextPaint textPaint = new TextPaint(); //Used for a text measuring and drawing
        private Paint backgroundPaint = new Paint(); //Used for a drawing of the background

        /// <summary>
        /// Gets/Sets a text that is displayed
        /// </summary>
        /// 
        /// <Postcondition>
        /// a text is set
        /// the view is reinitialized
        /// </Postcondition>  
        /// 
        /// <Exceptions>
        /// ArgumentNullException - A passed value can not be null
        /// ArgumentException - A passed value can not be an empty string
        /// </Exceptions> 
        /// 
        /// <Return>
        /// string: a text that's displayed
        /// the view is reinitialized
        /// </Return> 
        public string DisplayText
        {
            set
            {
                if (value==null)
                    throw new ArgumentNullException("A passed value can not be null");
                else if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A passed value can not be an empty string");

                this.displayText = value.Trim();
                this.Init();
            }
            get
            {
                return this.displayText;
            }
        }

        /// <summary>
        /// Get/Sets a size for a text that is displayed
        /// </summary>
        /// 
        /// <Postcondition>
        /// a value for the text size is set
        /// the view is reinitialized
        /// </Postcondition>  
        /// 
        /// <Exceptions>
        /// ArgumentException - a value of the text size has to be greater than 0
        /// </Exceptions> 
        /// 
        /// <Return>
        /// int: a value that defines a size of the text
        /// </Return> 
        public int TextSize
        {
            get
            {
                return this.textSize;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("a value of the text size has to be greater than 0");

                this.textSize = value;
                this.Init();
            }
        }

        /// <summary>
        /// Gets/Sets a value of radius defining a circle
        /// </summary>
        /// 
        /// <Postcondition>
        /// a value for the radius is set
        /// </Postcondition>  
        /// 
        /// <Exceptions>
        /// ArgumentException - a value of the radius has to be greater than 0
        /// </Exceptions> 
        /// 
        /// <Return>
        /// int: the radius is calculated from the input arguments and assigned to the property
        /// </Return> 
        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentNullException("a value of the radius has to be greater than 0");

                this.radius = value;
                this.Init();
            }
        }

        #region Initialization
        /// <summary>
        /// Initializes an object with default values
        /// </summary>
        /// 
        /// <Parameters>
        /// context: Interface to global information about an application environment
        /// </Parameters>
        /// 
        /// <Postcondition>
        /// An object is initialized with default values wich are defined by the constants of class
        /// </Postcondition>  
        public GmailProfilePicture(Context context) : base(context)
        {
            this.radius = GmailProfilePicture.DEFAULT_RADIUS;
            this.displayText = GmailProfilePicture.DEFAULT_DISPLAY_TEXT;
            this.textSize = GmailProfilePicture.DEFAULT_TEXT_SIZE;

            this.Init();
        }

        /// <summary>
        /// Initializes an object with values extracted from the argument attrs
        /// </summary>
        /// 
        /// <Parameters>
        /// context: Interface to global information about an application environment
        /// attrs: A collection of attributes, as found associated with a tag in an XML document
        /// </Parameters>
        /// 
        /// <Precondition>
        /// this constructor is supposed to be call by Android framework
        /// </Precondition>
        /// 
        /// <Postcondition>
        /// an object is initialized with values extracted from the argument attrs 
        /// </Postcondition>
        /// 
        /// <Exceptions>
        /// ArgumentException - The parameter {0} is expected to be defined in XML or IAttributeSet but it is ommited
        /// </Exceptions> 
        public GmailProfilePicture(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            TypedArray typedArray = this.Context.ObtainStyledAttributes(attrs, Resource.Styleable.GmailProfilePicture);
           
            string exceptionMessageRequired= "The parameter {0} is expected to be defined in XML or IAttributeSet but it is ommited";
            string exceptionMessageWrongFormat = "The parameter {0} does not have a correct format. The format’s type has to be {2}";

            int tmpRadius = 0;
            string tmpDisplayText=String.Empty;
            int tmpTextSize=0;


            try
            {
                tmpRadius = typedArray.GetInteger(Resource.Styleable.GmailProfilePicture_radius, int.MinValue);
            }
            catch(Exception)
            {
                throw new ArgumentException(String.Format(exceptionMessageWrongFormat,"radius","int"));
            }

            try
            {
                tmpDisplayText = typedArray.GetString(Resource.Styleable.GmailProfilePicture_display_text);
            }
            catch (Exception)
            {
                throw new ArgumentException(String.Format(exceptionMessageWrongFormat, "display_text", "string"));
            }

            try
            {
                tmpTextSize = typedArray.GetInteger(Resource.Styleable.GmailProfilePicture_text_size, int.MinValue);
            }
            catch (Exception)
            {
                throw new ArgumentException(String.Format(exceptionMessageWrongFormat, "text_size", "int"));
            }


            if (tmpRadius == int.MinValue)
                throw new ArgumentException(String.Format(exceptionMessageRequired, "Radius"));
            else if (tmpTextSize == int.MinValue)
                throw new ArgumentException(String.Format(exceptionMessageRequired, "TextSize"));
            else if (tmpDisplayText == null)
                throw new ArgumentException(String.Format(exceptionMessageRequired, "DisplayText"));

            this.displayText = tmpDisplayText;
            this.textSize = tmpTextSize;
            this.radius = tmpRadius;
            
            this.Init();
        }

        /// <summary>
        /// Initializes the objects used for a measuring and drawing of 
        /// the text and background 
        /// </summary>
        /// 
        /// <Postcondition>
        /// the objects used for a measuring and drawing of the text and background 
        /// are initialized
        /// </Postcondition>  
        private void Init()
        {
            this.textPaint.Color = Color.White;
            this.textPaint.AntiAlias = true;
            this.textPaint.SetStyle(Paint.Style.Fill);
            this.textPaint.TextSize = this.TextSize * this.Resources.DisplayMetrics.Density;

            this.backgroundPaint.Color = ColorPalette.Next(this.displayText);
            this.backgroundPaint.SetStyle(Paint.Style.Fill);
            this.backgroundPaint.AntiAlias = true;
            this.backgroundPaint.StrokeWidth = 0;

            this.circleData = new CircleData(this.radius, this.Resources.DisplayMetrics.Density);
        }
        #endregion

        /// <summary>
        /// Measures the view and its content to determine the measured width and the measured height.
        /// </summary>
        /// 
        /// <Precondition>
        /// the method is supposed to be called by Android framework
        /// </Precondition> 
        /// 
        /// <Postcondition>
        /// Appropriate height and width is set for the view
        /// </Postcondition>  
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int measuredHeight = MeasureSpec.GetSize(heightMeasureSpec);
            int measuredWidth = MeasureSpec.GetSize(widthMeasureSpec);
       

            int minDimension = Math.Min(measuredHeight, measuredWidth);
            int minRadious = (int)Math.Min(minDimension, this.circleData.Radius * 2);
            if (minRadious == 0)
                minRadious = (int)this.circleData.Radius * 2;

            this.SetMeasuredDimension(minRadious, minRadious);
        }

        /// <summary>
        /// Callback method to be invoked when the view tree is about to be drawn
        /// </summary>
        /// 
        /// <Precondition>
        /// the method is supposed to be called by Android framework
        /// </Precondition> 
        /// 
        /// <Postcondition>
        /// the view is drawn
        /// </Postcondition>  
        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawColor(Color.White);
            this.circleData.X = (float)canvas.Width / 2;
            this.circleData.Y = (float)canvas.Height / 2;
            canvas.DrawCircle(this.circleData.X, this.circleData.Y, this.circleData.Radius, this.backgroundPaint);

            Rect textBounds = new Rect();
            textPaint.GetTextBounds(this.DisplayText, 0, this.DisplayText.Length, textBounds);

            canvas.DrawText(this.DisplayText, this.circleData.X - (textBounds.Left + textBounds.Width() / 2), this.circleData.Y + (textBounds.Bottom + textBounds.Height() / 2), this.textPaint);
        }
    }
}