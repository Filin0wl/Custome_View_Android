using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Second_attempt_custome_view
{
    [Register("second_attempt_custome_view.StarsRatingView")]
    public class StarsRatingView : LinearLayout
    {
        Drawable empty;
        Drawable fill;
        Drawable highlighted;
        int countRating;
        List<ImageButton> buttons;

        public StarsRatingView(Context context) : base(context)
        {
            Initialize(context);
        }

        public StarsRatingView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context, attrs);
        }



        private void Initialize(Context context, IAttributeSet attrs = null)
        {
            Inflate(context, Resource.Layout.layout_star, this);
            //LayoutInflater inflater = LayoutInflater.FromContext(context);
            buttons = new List<ImageButton>();
            InitAttrProperties(context, attrs);


        }

        private void InitAttrProperties(Context context, IAttributeSet attrs)
        {
            if (context == null || attrs == null)
            {
                return;
            }

            Android.Content.Res.TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.ItemRating);
            empty = typedArray.GetDrawable(Resource.Styleable.ItemRating_emptyPic);
            fill = typedArray.GetDrawable(Resource.Styleable.ItemRating_filledPic);
            highlighted = typedArray.GetDrawable(Resource.Styleable.ItemRating_highlightedPic);
            countRating = typedArray.GetInteger(Resource.Styleable.ItemRating_numberItem, 0);
            var layout = FindViewById<LinearLayout>(Resource.Id.linearLayoutStar);
            for (int i = 0; i < layout.ChildCount; i++)
            {
                ImageButton btn = (ImageButton)layout.GetChildAt(i);
                btn.Click += Btn_Click;
                if (i < countRating)
                    btn.SetImageDrawable(fill);
                else
                    btn.SetImageDrawable(empty);
                buttons.Add(btn);
            }






        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int rating = 0;
            foreach(ImageButton btn in buttons)
            {
                rating++;
                if (sender.Equals(btn))
                    break;

            }
            int i = 0;
            foreach (ImageButton btn in buttons)
            {
                i++;
                if (i <= rating)
                    btn.SetImageDrawable(fill);
                else
                    btn.SetImageDrawable(empty);
            }
           

            /*((ImageButton)sender).SetImageDrawable(fill);*/
        }


    }
}