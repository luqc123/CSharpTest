using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;


namespace CustomControls
{
    [TemplatePart(Name="PART_RedSlider",Type=typeof(Slider))]
    [TemplatePart(Name ="PART_BlueSlider",Type =typeof(Slider))]
    [TemplatePart(Name ="PART_GreenSlider",Type =typeof(Slider))]
    [TemplatePart(Name ="PART_PreviewBrush",Type =typeof(SolidColorBrush))]
    public class ColorPicker : Control
    {
        static ColorPicker()
        {
            //This OverrideMetadata call tells the system that this element wants to provoide a style
            //that is different than its base class
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));

            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorChanged)));

            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker),new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker),new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        }

        public static readonly DependencyProperty ColorProperty;
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public static readonly DependencyProperty RedProperty;
        public static readonly DependencyProperty BlueProperty;
        public static readonly DependencyProperty GreenProperty;

        public byte Red
        {
            get
            {
                return (byte)GetValue(RedProperty);
            }
            set
            {
                SetValue(RedProperty, value);
            }
        }
        
        public byte Blue
        {
            get
            {
                return (byte)GetValue(BlueProperty);
            }
            set
            {
                SetValue(BlueProperty, value);
            }
        }

        public byte Green
        {
            get
            {
                return (byte)GetValue(GreenProperty);
            }
            set
            {
                SetValue(GreenProperty, value);
            }
        }

        private static void OnColorChanged(DependencyObject sender,DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color oldColor = (Color)e.OldValue;
            Color newColor = (Color)e.NewValue;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;

            colorPicker.OnColorChanged(oldColor, newColor);
        }
        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;

            if (e.Property == RedProperty) color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty) color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty) color.B = (byte)e.NewValue;

            colorPicker.Color = color; //will call OnColorChanged
        }

        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }
        private void OnColorChanged(Color oldValue,Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorPicker.ColorChangedEvent;
            RaiseEvent(args);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Slider slider = GetTemplateChild("PART_RedSlider") as Slider;
            if(slider != null)
            {
                Binding binding = new Binding("Red");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(Slider.ValueProperty, binding);
            }
            slider = GetTemplateChild("PART_GreenSlider") as Slider;
            if(slider != null)
            {
                Binding binding = new Binding("Green");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(Slider.ValueProperty, binding);
            }
            slider = GetTemplateChild("PART_BlueSlider") as Slider;
            if(slider != null)
            {
                Binding binding = new Binding("Blue");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(Slider.ValueProperty, binding);
            }
            SolidColorBrush solidColorBrush = GetTemplateChild("PART_PreviewBrush") as SolidColorBrush;
            if(solidColorBrush != null)
            {
                Binding binding = new Binding("Color");
                binding.Source = solidColorBrush;
                binding.Mode = BindingMode.OneWayToSource;
                this.SetBinding(ColorPicker.ColorProperty, binding);
            }
        }
    }
}
