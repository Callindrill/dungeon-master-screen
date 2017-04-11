﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DungeonMasterScreen.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledIntegerUpDown : UserControl
    {
        public static readonly DependencyProperty SizeGroupProperty = DependencyProperty
            .Register("SizeGroup",
                    typeof(string),
                    typeof(LabelledIntegerUpDown),
                    new FrameworkPropertyMetadata("Controls"));

        public static readonly DependencyProperty LabelProperty = DependencyProperty
            .Register("Label",
                    typeof(string),
                    typeof(LabelledIntegerUpDown),
                    new FrameworkPropertyMetadata("Unnamed Label"));

        public static readonly DependencyProperty LabelPositionProperty = DependencyProperty
            .Register("LabelPosition",
                    typeof(LabelPosition),
                    typeof(LabelledIntegerUpDown),
                    new FrameworkPropertyMetadata()
                    {
                        DefaultValue = LabelPosition.Left,
                        IsNotDataBindable = true,
                        PropertyChangedCallback = OnLabelPositionChanged
                    }
                    );

        public static readonly DependencyProperty ValueProperty = DependencyProperty
            .Register("Value",
                    typeof(int),
                    typeof(LabelledIntegerUpDown),
                    new FrameworkPropertyMetadata()
                    {
                        DefaultValue = 0,
                        BindsTwoWayByDefault = true,
                        DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    }
                    );

        public LabelledIntegerUpDown()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        private static void OnLabelPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LabelledIntegerUpDown)d).SetUpGrid();
        }

        private void SetUpGrid()
        {
            switch (LabelPosition)
            {
                case LabelPosition.Left:
                case LabelPosition.Right:
                    ColumnDefinition LabelColumn = new ColumnDefinition();
                    ColumnDefinition ControlColumn = new ColumnDefinition();

                    LabelColumn.Width = new GridLength(0, GridUnitType.Auto);
                    LabelColumn.SharedSizeGroup = SizeGroup;

                    //ControlColumn.Width = new GridLength(1, GridUnitType.Star);
                    if (LabelPosition == LabelPosition.Left)
                    {
                        Grid.SetColumn(LabelControl, 0);
                        Grid.SetColumn(IntegerUpDown, 1);
                        Root.ColumnDefinitions.Add(LabelColumn);
                        Root.ColumnDefinitions.Add(ControlColumn);

                    }
                    else
                    {
                        Grid.SetColumn(LabelControl, 1);
                        Grid.SetColumn(IntegerUpDown, 0);
                        Root.ColumnDefinitions.Add(ControlColumn);
                        Root.ColumnDefinitions.Add(LabelColumn);
                    }
                    break;
                case LabelPosition.Top:
                case LabelPosition.Bottom:
                    RowDefinition LabelRow = new RowDefinition();
                    RowDefinition ControlRow = new RowDefinition();

                    ControlRow.Height = new GridLength(0, GridUnitType.Auto);
                    ControlRow.SharedSizeGroup = SizeGroup;

                    //LabelRow.Height = new GridLength(1, GridUnitType.Star);

                    LabelControl.HorizontalAlignment = HorizontalAlignment.Center;
                    LabelControl.Padding = new Thickness(15, 0, 15, 0);

                    if (LabelPosition == LabelPosition.Top)
                    {
                        Grid.SetRow(LabelControl, 0);
                        Grid.SetRow(IntegerUpDown, 1);
                        Root.RowDefinitions.Add(LabelRow);
                        Root.RowDefinitions.Add(ControlRow);
                    }
                    else
                    {
                        Grid.SetRow(LabelControl, 1);
                        Grid.SetRow(IntegerUpDown, 0);
                        Root.RowDefinitions.Add(ControlRow);
                        Root.RowDefinitions.Add(LabelRow);
                    }
                    break;
                default:
                    throw new ArgumentException("Unrecognized Label Position.");
            }
        }
        public string SizeGroup
        {
            get { return (string)GetValue(SizeGroupProperty); }
            set { SetValue(SizeGroupProperty, value); }
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public LabelPosition LabelPosition
        {
            get { return (LabelPosition)GetValue(LabelPositionProperty); }
            set { SetValue(LabelPositionProperty, value); }
        }
    }
}
