﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTouchExpress.Effects
{
    public static class ShadowEffect
    {
        public static readonly BindableProperty HasShadowProperty =
    BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(ShadowEffect), false, propertyChanged: OnHasShadowChanged);
        public static readonly BindableProperty ColorProperty =
          BindableProperty.CreateAttached("Color", typeof(Color), typeof(ShadowEffect), Color.FromArgb("#000000"));
        public static readonly BindableProperty RadiusProperty =
          BindableProperty.CreateAttached("Radius", typeof(double), typeof(ShadowEffect), 1.0);
        public static readonly BindableProperty DistanceXProperty =
          BindableProperty.CreateAttached("DistanceX", typeof(double), typeof(ShadowEffect), 0.0);
        public static readonly BindableProperty DistanceYProperty =
          BindableProperty.CreateAttached("DistanceY", typeof(double), typeof(ShadowEffect), 0.0);

        public static bool GetHasShadow(BindableObject view)
        {
            return (bool)view.GetValue(HasShadowProperty);
        }

        public static void SetHasShadow(BindableObject view, bool value)
        {
            view.SetValue(HasShadowProperty, value);
        }

        public static Color GetColor(BindableObject view)
        {
            return (Color)view.GetValue(ColorProperty);
        }
        public static void SetColor(BindableObject view, Color value)
        {
            view.SetValue(ColorProperty, value);
        }

        public static double GetRadius(BindableObject view)
        {
            return (double)view.GetValue(RadiusProperty);
        }
        public static void SetRadius(BindableObject view, double value)
        {
            view.SetValue(RadiusProperty, value);
        }

        public static double GetDistanceX(BindableObject view)
        {
            return (double)view.GetValue(DistanceXProperty);
        }
        public static void SetDistanceX(BindableObject view, double value)
        {
            view.SetValue(DistanceXProperty, value);
        }

        public static double GetDistanceY(BindableObject view)
        {
            return (double)view.GetValue(DistanceYProperty);
        }
        public static void SetDistanceY(BindableObject view, double value)
        {
            view.SetValue(DistanceYProperty, value);
        }

        static void OnHasShadowChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            bool hasShadow = (bool)newValue;
            if (hasShadow)
            {
                view.Effects.Add(new LabelShadowEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is LabelShadowEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }

        class LabelShadowEffect : RoutingEffect
        {
            public LabelShadowEffect() : base("PalmSens.LabelShadowEffect")
            {
            }
        }
    }
}
