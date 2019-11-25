using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using Windows.Devices.Power;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Windows.UI;
using Windows.UI.Popups;
using Windows.Devices.SerialCommunication;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using System.Collections.Concurrent;
using Windows.UI.Xaml.Documents;
using Windows.Storage.Search;
using Windows.Devices.Usb;
using System.Text;
using Windows.UI.Text;
using Windows.ApplicationModel;

namespace Channel_Select_Beta
{
    public class Plotter
    {
        #region color & brush
        private Color PLS_Config_canvas_color = Color.FromArgb((byte)255, (byte)64, (byte)80, (byte)80);
        private Color Back_color = Color.FromArgb((byte)255, (byte)32, (byte)32, (byte)32);
        private SolidColorBrush Transparent_brush = new SolidColorBrush(Color.FromArgb((byte)0, (byte)0, (byte)0, (byte)0));
        private SolidColorBrush Dodge_blue_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)30, (byte)144, (byte)255));
        private SolidColorBrush Default_back_black_color_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)32, (byte)32, (byte)32));
        private SolidColorBrush Light_back_black_color_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)42, (byte)42, (byte)42));
        private SolidColorBrush white_button_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)250, (byte)250, (byte)250));
        private SolidColorBrush green_text_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)140, (byte)255, (byte)140));
        private SolidColorBrush green_button_brush = new SolidColorBrush(Color.FromArgb((byte)40, (byte)20, (byte)230, (byte)20));
        private SolidColorBrush Teal_color = new SolidColorBrush(Color.FromArgb((byte)255, (byte)84, (byte)100, (byte)130));
        private SolidColorBrush Blue_color = new SolidColorBrush(Color.FromArgb((byte)255, (byte)34, (byte)50, (byte)70));
        private SolidColorBrush Sky_blue_color = new SolidColorBrush(Color.FromArgb((byte)255, (byte)170, (byte)170, (byte)255));
        private SolidColorBrush Sky_green_color = new SolidColorBrush(Color.FromArgb((byte)255, (byte)170, (byte)255, (byte)170));
        private SolidColorBrush Sky_red_color = new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)170, (byte)170));
        private SolidColorBrush Blue_Violet = new SolidColorBrush(Color.FromArgb((byte)255, (byte)138, (byte)43, (byte)226));
        private SolidColorBrush Deep_Pink = new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)20, (byte)147));
        private SolidColorBrush Sea_Green = new SolidColorBrush(Color.FromArgb((byte)255, (byte)46, (byte)139, (byte)87));
        private SolidColorBrush Violet_Red = new SolidColorBrush(Color.FromArgb((byte)255, (byte)199, (byte)21, (byte)112));
        private SolidColorBrush Navy = new SolidColorBrush(Color.FromArgb((byte)255, (byte)0, (byte)0, (byte)128));
        private SolidColorBrush Light_blue_color = new SolidColorBrush(Color.FromArgb((byte)255, (byte)210, (byte)230, (byte)250));
        private SolidColorBrush red_button_brush = new SolidColorBrush(Color.FromArgb((byte)40, (byte)230, (byte)20, (byte)20));
        private SolidColorBrush yellow_brush = new SolidColorBrush(Color.FromArgb((byte)200, (byte)250, (byte)250, (byte)20));
        private SolidColorBrush Light_blue_brush = new SolidColorBrush(Color.FromArgb((byte)250, (byte)173, (byte)216, (byte)230));
        private SolidColorBrush orange_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)180, (byte)50));
        private SolidColorBrush ardu_brush = new SolidColorBrush(Color.FromArgb((byte)250, (byte)0, (byte)139, (byte)139));
        private SolidColorBrush dark_grey_brush = new SolidColorBrush(Color.FromArgb((byte)250, (byte)169, (byte)169, (byte)169));
        private SolidColorBrush red_bright_button_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)230, (byte)10, (byte)10));
        private SolidColorBrush green_bright_button_brush = new SolidColorBrush(Color.FromArgb((byte)255, (byte)10, (byte)250, (byte)10));
        private SolidColorBrush green_ready_brush = new SolidColorBrush(Color.FromArgb((byte)155, (byte)20, (byte)230, (byte)20));
        private Brush textwhite = new SolidColorBrush(Color.FromArgb((byte)255, (byte)250, (byte)250, (byte)250));
        private List<SolidColorBrush> All_Color = new List<SolidColorBrush>();
        #endregion

        public double Threshold_Value = 0;

        public Canvas Plotter_canvas = new Canvas();
        private double Width = 0;
        private double Height = 0;
        private MainPage.MainPage_Info Parent_Info = new MainPage.MainPage_Info();

        private List<Polyline> Vertical_pl = new List<Polyline>();
        private List<Polyline> Horizontal_pl = new List<Polyline>();
        private List<List<Polyline>> Data_pl = new List<List<Polyline>>();
        private List<Polyline> Cordinate_pl = new List<Polyline>();
        public Plotter(MainPage.MainPage_Info x)
        {
            Parent_Info = x;
            Grid Parent_Grid = Parent_Info.maingrid;
            Plotter_canvas = new Canvas()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Default_back_black_color_brush
            };
            Parent_Grid.Children.Add(Plotter_canvas);
            Plotter_canvas.PointerPressed += Plotter_canvas_PointerPressed;
            Plotter_canvas.PointerMoved += Plotter_canvas_PointerMoved;
            Plotter_canvas.PointerReleased += Plotter_canvas_PointerReleased;

        }
        private bool pressed = false;
        private void Plotter_canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Create_Box(L_poly[L_poly.Count - 1]);
            pressed = false;
        }

        private Polyline polyl = new Polyline();
        private List<Polyline> L_poly = new List<Polyline>();
        private double movecount = 0;
        private void Plotter_canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if(pressed)
            {
                L_poly[L_poly.Count-1].Points.Add(e.GetCurrentPoint(Plotter_canvas).Position);
                X_Scale[0].Text = movecount.ToString();
                movecount++;
            }
            

        }

        private void Plotter_canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            L_poly.Add(new Polyline()
            {
                StrokeThickness = 2,
                Stroke = green_bright_button_brush
            });
            Plotter_canvas.Children.Add(L_poly[L_poly.Count - 1]);
            pressed = true;
        }

        public void Create(double c, double cs, double r, double rs, int z)
        {
            Width = Parent_Info.Width / Parent_Info.column * (cs) * 0.995;
            Height = Parent_Info.Height / Parent_Info.row * (rs) * 0.995;
            Plotter_canvas.SetValue(Grid.ColumnProperty, c);
            Plotter_canvas.SetValue(Grid.ColumnSpanProperty, cs);
            Plotter_canvas.SetValue(Grid.RowProperty, r);
            Plotter_canvas.SetValue(Grid.RowSpanProperty, rs);
            Canvas.SetZIndex(Plotter_canvas, z);
            Plotter_canvas.Visibility = Visibility.Visible;
            Create_Vertical_Grid(4);
            Create_Horizontal_Grid(10);
            if (Grid_On)
            {
                Show_Grid();
            }
            Create_Cordinate();
            Create_Y_Scale(5);
            Create_X_Scale(10);
            int i = 0;
            int ii = 0;
            i = 0;
            while (i < Data_pl.Count)
            {
                ii = 0;
                while (ii < Data_pl[i].Count)
                {
                    if (Plotter_canvas.Children.Contains(Data_pl[i][ii]))
                    {
                        Plotter_canvas.Children.Remove(Data_pl[i][ii]);
                    }
                    ii++;
                }
                i++;
            }

        }
        public void Hide()
        {
            Plotter_canvas.Visibility = Visibility.Collapsed;
        }
        public void Show()
        {
            Plotter_canvas.Visibility = Visibility.Visible;
        }

        private List<focus_Box> L_box = new List<focus_Box>();
        private class focus_Box
        {
            public double x1;
            public double x2;
            public double x3;
            public double x4;
            public double y1;
            public double y2;
            public double y3;
            public double y4;
        }
        private List<int> Box_x_min = new List<int>();
        private List<int> Box_x_max = new List<int>();

        private void Create_Box(Polyline x)
        {
            if(x.Points.Count>2)
            {
                L_box.Add(new focus_Box()
                {
                    x1 = x.Points.Min(p => p.X),
                    x2 = x.Points.Max(p => p.X),
                    x3 = x.Points.Max(p => p.X),
                    x4 = x.Points.Min(p => p.X),
                    y1 = x.Points.Min(p => p.Y),
                    y2 = x.Points.Min(p => p.Y),
                    y3 = x.Points.Max(p => p.Y),
                    y4 = x.Points.Max(p => p.Y),

                });
                Box_x_min.Add(Input_Data_Point.Count * (int)(L_box[L_box.Count - 1].x1 / Width));
                Box_x_max.Add(Input_Data_Point.Count * (int)(L_box[L_box.Count - 1].x2 / Width));
                create_Box_Poly(L_box[L_box.Count - 1]);
                create_Box_Button(L_box[L_box.Count - 1]);
                Create_Box_Gon(L_box[L_box.Count - 1]);
            }

        }
        private List<Polygon> Box_gon = new List<Polygon>();
        private void Create_Box_Gon(focus_Box b)
        {
            int i = 0;
            double x = 0;
            double y = 0;
            int xmax = (int)(Input_Data_Point.Count * b.x2 / Width);
            int xmin = (int)(Input_Data_Point.Count * b.x1 / Width);
            bool flag = false;
            bool crossflag = false;
            #region Input Freq
            Box_gon.Add(new Polygon()
            {
                Stroke = Light_blue_brush,
                StrokeThickness = 1,
                Fill = Violet_Red
            }) ;

            i = xmin;
            while (i < (xmax+1))
            {

                if (Input_Data_Line[Input_Data_Line.Count - 1].Points[i].Y>b.y3)
                {

                    if (flag)
                    {
                        xmax = i;
                        flag = !flag;
                        break;
                    }
                    else
                    {
                        xmin = i;
                    }

                    crossflag = true;

                }
                else
                {
                    if(!flag)
                    {
                        flag = !flag;
                    }
                    
                    Box_gon[Box_gon.Count - 1].Points.Add(Input_Data_Line[Input_Data_Line.Count - 1].Points[i]);

                }
                i++;
            }
            if (crossflag)
            {
                Box_gon[Box_gon.Count - 1].Points.Add(Box_gon[Box_gon.Count - 1].Points[0]);
            }
            else
            {
                Box_gon[Box_gon.Count - 1].Points.Add(new Point(b.x3, b.y3));
                Box_gon[Box_gon.Count - 1].Points.Add(new Point(b.x4, b.y4));
                Box_gon[Box_gon.Count - 1].Points.Add(new Point(b.x1, b.y1));
            }
            Plotter_canvas.Children.Add(Box_gon[Box_gon.Count - 1]);


            #endregion
        }


        private List<Button> Box_bt = new List<Button>();
        private void create_Box_Button(focus_Box x)
        {
            Box_bt.Add(new Button()
            {
                Width = x.x2 - x.x1,
                Height = x.y3 - x.y1,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Transparent_brush,
                FontSize = 16,
                Foreground = Light_blue_brush,
                Content = (boxpoly.Count).ToString()
            });
            Plotter_canvas.Children.Add(Box_bt[Box_bt.Count-1]);
            Canvas.SetLeft(Box_bt[Box_bt.Count - 1], x.x1);
            Canvas.SetTop(Box_bt[Box_bt.Count - 1], x.y1);
        }
        private List<Polyline> boxpoly = new List<Polyline>();
        private void create_Box_Poly(focus_Box x)
        {
            boxpoly.Add(new Polyline()
            {
                Stroke = red_bright_button_brush,
                StrokeThickness = 3
            });
            Plotter_canvas.Children.Add(boxpoly[boxpoly.Count-1]);
            boxpoly[boxpoly.Count - 1].Points.Add(new Point(x.x1, x.y1));
            boxpoly[boxpoly.Count - 1].Points.Add(new Point(x.x2, x.y2));
            boxpoly[boxpoly.Count - 1].Points.Add(new Point(x.x3, x.y3));
            boxpoly[boxpoly.Count - 1].Points.Add(new Point(x.x4, x.y4));
            boxpoly[boxpoly.Count - 1].Points.Add(new Point(x.x1, x.y1));
        }
        public List<double> Input_Data_Point = new List<double>();
        public List<Polyline> Input_Data_Line = new List<Polyline>();

        public List<double> Input_Freq_Point = new List<double>();
        public List<Polyline> Input_Freq_Line = new List<Polyline>();
        public void Create_Plot(double ymax, double ymin)
        {
            double x = 0;
            double y = 0;
            #region Input Data
            Remove_Input_Data_Line();
            Remove_Input_Data_Ellipse();
            Remove_Input_Data_PolyGon();
            Input_Data_Line.Add(new Polyline()
            {
                Stroke = Light_blue_brush,
                StrokeThickness = 1
            });
            int i = 0;
            i = 0;
            while (i < Input_Data_Point.Count)
            {
                x = i * Width / Input_Data_Point.Count;
                y = Height - (Input_Data_Point[i] - ymin) / (ymax - ymin) * Height;
                Input_Data_Line[Input_Data_Line.Count - 1].Points.Add(new Point(x, y));
                i++;
            }

            Plotter_canvas.Children.Add(Input_Data_Line[Input_Data_Line.Count - 1]);
            #endregion

        }

        private List<Polygon> Input_Data_PolyGon = new List<Polygon>();
        public void Add_PolyGon(double ymax, double ymin,int xmin, int xmax, List<double> data, SolidColorBrush b)
        {
            double x = 0;
            double y = 0;
            Input_Data_PolyGon.Add(new Polygon()
            {
                Stroke = b,
                StrokeThickness = 1,
                Fill = b
            });
            int i = 0;
            i = xmin;
            while (i < xmax)
            {
                x = i * Width / data.Count;
                y = Height - (data[i] - ymin) / (ymax - ymin) * Height;
                Input_Data_PolyGon[Input_Data_PolyGon.Count - 1].Points.Add(new Point(x, y));
                i++;
            }
            Input_Data_PolyGon[Input_Data_PolyGon.Count - 1].Points.Add(Input_Data_PolyGon[Input_Data_PolyGon.Count - 1].Points[0]);
            Plotter_canvas.Children.Add(Input_Data_PolyGon[Input_Data_PolyGon.Count - 1]);
        }

        private List<Ellipse> Input_Data_Ellipse = new List<Ellipse>();
        private double Ellipse_Width = 20;
        private double Ellipse_Height = 20;
        public void Add_Point(double ymax, double ymin, List<double> data, List<int> ind, SolidColorBrush b)
        {
            double x = 0;
            double y = 0;

            int i = 0;
            i = 0;
            while (i < ind.Count)
            {
                Input_Data_Ellipse.Add(new Ellipse()
                {
                    Stroke = b,
                    StrokeThickness = 1,
                    Fill = b,
                    Width = Ellipse_Width,
                    Height = Ellipse_Height
                });
                x = ind[i] * Width / data.Count;
                y = Height - (data[ind[i]] - ymin) / (ymax - ymin) * Height;
                Input_Data_Ellipse[Input_Data_Ellipse.Count - 1].Margin = new Thickness(x-Ellipse_Width/2,y-Ellipse_Height/2,0,0);
                i++;
            }

            Plotter_canvas.Children.Add(Input_Data_Ellipse[Input_Data_Ellipse.Count - 1]);
        }
        public void Add_Zcross(List<int> z, int c, SolidColorBrush b)
        {
            int i = 0;
            double x = 0;
            double y = 0;
            i = 0;
            while (i < z.Count)
            {
                Input_Data_Line.Add(new Polyline()
                {
                    Stroke = b,
                    StrokeThickness = 1
                });
                x = z[i] * Width / c;
                y = Height;
                Input_Data_Line[Input_Data_Line.Count - 1].Points.Add(new Point(x, y));
                y = 0;
                Input_Data_Line[Input_Data_Line.Count - 1].Points.Add(new Point(x, y));
                Plotter_canvas.Children.Add(Input_Data_Line[Input_Data_Line.Count - 1]);
                i++;
            }
        }
        public void Add_Plot(double ymax, double ymin, List<double> data, SolidColorBrush b)
        {
            double x = 0;
            double y = 0;
            Input_Data_Line.Add(new Polyline()
            {
                Stroke = b,
                StrokeThickness = 1
            });
            int i = 0;
            i = 0;
            while (i < data.Count)
            {
                x = i * Width / data.Count;
                y = Height - (data[i] - ymin) / (ymax - ymin) * Height;
                Input_Data_Line[Input_Data_Line.Count - 1].Points.Add(new Point(x, y));
                i++;
            }

            Plotter_canvas.Children.Add(Input_Data_Line[Input_Data_Line.Count - 1]);
        }
        public void Create_Freq_Ana(double fmax)
        {
            int i = 0;
            double x = 0;
            double y = 0;
            #region Input Freq
            Remove_Input_Freq_Line();
            Input_Freq_Line.Add(new Polyline()
            {
                Stroke = Light_blue_brush,
                StrokeThickness = 1
            });

            i = 0;
            while (i < Input_Freq_Point.Count)
            {
                x = i * Width / Input_Freq_Point.Count;
                y = Height - (Input_Freq_Point[i]) / fmax / 4 * Height;
                Input_Freq_Line[Input_Freq_Line.Count - 1].Points.Add(new Point(x, y));
                i++;
            }

            Plotter_canvas.Children.Add(Input_Freq_Line[Input_Freq_Line.Count - 1]);
            #endregion
        }
        private void Remove_Input_Data_PolyGon()
        {
            int i = 0;
            i = 0;
            while (i < Input_Data_PolyGon.Count)
            {
                if (Plotter_canvas.Children.Contains(Input_Data_PolyGon[i]))
                {
                    Plotter_canvas.Children.Remove(Input_Data_PolyGon[i]);
                }
                i++;
            }
            Input_Data_PolyGon = new List<Polygon>();
        }
        private void Remove_Input_Data_Line()
        {
            int i = 0;
            i = 0;
            while(i<Input_Data_Line.Count)
            {
                if(Plotter_canvas.Children.Contains(Input_Data_Line[i]))
                {
                    Plotter_canvas.Children.Remove(Input_Data_Line[i]);
                }
                i++;
            }
            Input_Data_Line = new List<Polyline>();
        }
        private void Remove_Input_Data_Ellipse()
        {
            int i = 0;
            i = 0;
            while(i<Input_Data_Ellipse.Count)
            {
                if (Plotter_canvas.Children.Contains(Input_Data_Ellipse[i]))
                {
                    Plotter_canvas.Children.Remove(Input_Data_Ellipse[i]);
                }
                i++;
            }
            Input_Data_Ellipse = new List<Ellipse>();
        }
        private void Remove_Input_Freq_Line()
        {
            int i = 0;
            i = 0;
            while (i < Input_Freq_Line.Count)
            {
                if (Plotter_canvas.Children.Contains(Input_Freq_Line[i]))
                {
                    Plotter_canvas.Children.Remove(Input_Freq_Line[i]);
                }
                i++;
            }
            Input_Freq_Line = new List<Polyline>();
        }
        private Polyline Poly_Threshold = new Polyline();
        public void Create_Threshold(double thres)
        {
            if(Plotter_canvas.Children.Contains(Poly_Threshold))
            {
                Plotter_canvas.Children.Remove(Poly_Threshold);
            }
            Poly_Threshold = new Polyline() {
                Stroke = red_bright_button_brush,
                StrokeThickness = 2
            };
            double y = 0;
            double x = 0;
            x = Width;
            y = Height - thres * Height;
            Poly_Threshold.Points.Add(new Point(x, y));
            x = 0;
            Poly_Threshold.Points.Add(new Point(x, y));
            Plotter_canvas.Children.Add(Poly_Threshold);
        }
        private void Create_Cordinate()
        {
            int i = 0;
            i = 0;
            while (i < Cordinate_pl.Count)
            {
                if (Plotter_canvas.Children.Contains(Cordinate_pl[i]))
                {
                    Plotter_canvas.Children.Remove(Cordinate_pl[i]);
                }
                i++;
            }
            Cordinate_pl = new List<Polyline>();
            Cordinate_pl.Add(new Polyline()
            {
                Stroke = dark_grey_brush,
                StrokeThickness = 0.5
            });
            Plotter_canvas.Children.Add(Cordinate_pl[0]);
            Cordinate_pl[0].Points.Add(new Point(0, 0));
            Cordinate_pl[0].Points.Add(new Point(0, Height));
            Cordinate_pl[0].Points.Add(new Point(Width, Height));

        }
        public bool Grid_On = false;

        public void Show_Grid()
        {
            int i = 0;
            i = 0;
            while (i < Vertical_pl.Count)
            {
                Vertical_pl[i].Visibility = Visibility.Visible;
                i++;
            }
            i = 0;
            while (i < Horizontal_pl.Count)
            {
                Horizontal_pl[i].Visibility = Visibility.Visible;
                i++;
            }
            Grid_On = true;
        }

        public void Hide_Grid()
        {
            int i = 0;
            i = 0;
            while (i < Vertical_pl.Count)
            {
                Vertical_pl[i].Visibility = Visibility.Collapsed;
                i++;
            }
            i = 0;
            while (i < Horizontal_pl.Count)
            {
                Horizontal_pl[i].Visibility = Visibility.Collapsed;
                i++;
            }
            Grid_On = false;
        }
        public void Dispose_Grid()
        {
            Dispose_Vertical_Grid();
            Dispose_Horizontal_Grid();
            Grid_On = false;
        }

        private void Create_Vertical_Grid(int x)
        {
            int i = 0;
            i = 0;
            while (i < Vertical_pl.Count)
            {
                if (Plotter_canvas.Children.Contains(Vertical_pl[i]))
                {
                    Plotter_canvas.Children.Remove(Vertical_pl[i]);
                }
                i++;
            }
            Vertical_pl = new List<Polyline>();
            i = 0;
            while (i < x)
            {
                Vertical_pl.Add(new Polyline()
                {
                    Stroke = dark_grey_brush,
                    StrokeThickness = 1,
                    Visibility = Visibility.Collapsed
                });
                Vertical_pl[i].Points.Add(new Point(Width, Height / x * (i + 1)));
                Vertical_pl[i].Points.Add(new Point(0, Height / x * (i + 1)));
                Plotter_canvas.Children.Add(Vertical_pl[i]);
                i++;
            }
        }
        private void Create_Horizontal_Grid(int x)
        {
            int i = 0;
            i = 0;
            while (i < Horizontal_pl.Count)
            {
                if (Plotter_canvas.Children.Contains(Horizontal_pl[i]))
                {
                    Plotter_canvas.Children.Remove(Horizontal_pl[i]);
                }
                i++;
            }
            Horizontal_pl = new List<Polyline>();
            i = 0;
            while (i < x)
            {
                Horizontal_pl.Add(new Polyline()
                {
                    Stroke = dark_grey_brush,
                    StrokeThickness = 1,
                    Visibility = Visibility.Collapsed
                });
                Horizontal_pl[i].Points.Add(new Point(Width / x * (i), 0));
                Horizontal_pl[i].Points.Add(new Point(Width / x * (i), Height));
                Plotter_canvas.Children.Add(Horizontal_pl[i]);
                i++;
            }
        }
        private void Dispose_Vertical_Grid()
        {
            int i = 0;
            i = 0;
            while (i < Vertical_pl.Count)
            {
                if (Plotter_canvas.Children.Contains(Vertical_pl[i]))
                {
                    Plotter_canvas.Children.Remove(Vertical_pl[i]);
                }
                i++;
            }
        }
        private void Dispose_Horizontal_Grid()
        {
            int i = 0;
            i = 0;
            while (i < Horizontal_pl.Count)
            {
                if (Plotter_canvas.Children.Contains(Horizontal_pl[i]))
                {
                    Plotter_canvas.Children.Remove(Horizontal_pl[i]);
                }
                i++;
            }
        }
        private List<TextBlock> Y_Scale = new List<TextBlock>();
        private void Create_Y_Scale(int x)
        {
            int i = 0;
            double Scale_Width = 40;
            double Scale_Height = 20;

            i = 0;
            while (i < Y_Scale.Count)
            {
                if (Plotter_canvas.Children.Contains(Y_Scale[i]))
                {
                    Plotter_canvas.Children.Remove(Y_Scale[i]);
                }
                i++;
            }
            Y_Scale = new List<TextBlock>();

            i = 0;
            while (i < x)
            {
                Y_Scale.Add(new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    FontSize = 12,
                    FontFamily = new FontFamily("Comic Sans MS"),
                    Foreground = white_button_brush,
                    Width = Scale_Width,
                    Height = Scale_Height,
                    TextAlignment = TextAlignment.Right,
                    Text = "0"
                });
                Canvas.SetLeft(Y_Scale[i], -Scale_Width);
                //Canvas.SetTop(Y_Scale[i], Height / x * (i+1) - Scale_Height);
                Canvas.SetTop(Y_Scale[i], Height / (x - 1) * (i) - Scale_Height / 2);
                Plotter_canvas.Children.Add(Y_Scale[i]);
                i++;
            }

        }
        private List<TextBlock> X_Scale = new List<TextBlock>();
        private void Create_X_Scale(int x)
        {
            int i = 0;
            double Scale_Width = 40;
            double Scale_Height = 20;

            i = 0;
            while (i < X_Scale.Count)
            {
                if (Plotter_canvas.Children.Contains(X_Scale[i]))
                {
                    Plotter_canvas.Children.Remove(X_Scale[i]);
                }
                i++;
            }
            X_Scale = new List<TextBlock>();

            i = 0;
            while (i < x)
            {
                X_Scale.Add(new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    FontSize = 12,
                    FontFamily = new FontFamily("Comic Sans MS"),
                    Foreground = white_button_brush,
                    Width = Scale_Width,
                    Height = Scale_Height,
                    TextAlignment = TextAlignment.Right,
                    Text = (i + 1).ToString()
                });
                Canvas.SetLeft(X_Scale[i], Width / x * (i + 1) - Scale_Width);
                //Canvas.SetTop(Y_Scale[i], Height / x * (i+1) - Scale_Height);
                Canvas.SetTop(X_Scale[i], Height + Scale_Height / 2);
                Plotter_canvas.Children.Add(X_Scale[i]);
                i++;
            }


        }
    }
}
