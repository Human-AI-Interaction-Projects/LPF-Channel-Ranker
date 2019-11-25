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
using System.Diagnostics;
using Windows.ApplicationModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Channel_Select_Beta
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
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
        #region main page info
        public class MainPage_Info
        {
            public Grid maingrid;
            public Page mainpage;
            public Canvas maincanvas;
            public double column;
            public double row;
            public double Width;
            public double Height;
            public double Fontsize;
        }
        private MainPage_Info mainpage_info = new MainPage_Info();
        #endregion
        public MainPage()
        {
            this.InitializeComponent();

        }
        private DateTime modification;
        private List<double> Rank_Index = new List<double>();
        private async void Check_Date()
        {
            modification = File.GetLastWriteTime(@"C:\Users\timli\AppData\Local\Packages\16a2373a-1519-4dca-8c90-ac84a72b4cfd_kbtfgvzxh186t\LocalState\waveRank.txt");
            while (true)
            {
                try
                {
                    if(modification != File.GetLastWriteTime(@"C:\Users\timli\AppData\Local\Packages\16a2373a-1519-4dca-8c90-ac84a72b4cfd_kbtfgvzxh186t\LocalState\waveRank.txt"))
                    {
                        modification = File.GetLastWriteTime(@"C:\Users\timli\AppData\Local\Packages\16a2373a-1519-4dca-8c90-ac84a72b4cfd_kbtfgvzxh186t\LocalState\waveRank.txt");
                        //await ShowDialog("trigger","trigger");
                        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                        StorageFile sampleFile = await storageFolder.GetFileAsync("waveRank.txt");
                        Rank_Index = new List<double>(String_Data(await FileIO.ReadTextAsync(sampleFile)));
                    }
                    
                }
                catch
                {
                    await ShowDialog("Error","Error");
                    break;
                }
                await Task.Delay(20);
            }
        }
        //private List<List<Point>> Poco = new List<List<Point>>();
        private List<PointCollection> Poco = new List<PointCollection>();
        private async Task Read_Pred_Data()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            int i = 0;
            i = 0;
            Read_Data_In = new List<List<double>>();
            while (i < Total_Channel+2)
            {
                scrollpolyline.Add(new Polyline()
                {
                    Stroke = Light_blue_brush,
                    StrokeThickness = 2
                });
                Poco.Add(new PointCollection());
                StorageFile sampleFile = await storageFolder.GetFileAsync("Wave" + (10 + i).ToString() + ".txt");
                Read_Data_In.Add(new List<double>(String_Data(await FileIO.ReadTextAsync(sampleFile))));
                i++;
            }
        }
        private List<double> Test_P = new List<double>();
        private async void Run_Cont()
        {
            int i = 0;
            int ii = 0;
            scrollcanvas = new List<Canvas>();
            
            Poco = new List<PointCollection>();
            double x = 0;
            double y = 0;
            i = 0;
            while (i < Total_Channel)
            {
                scrollpolyline.Add(new Polyline()
                {
                    Stroke = Light_blue_brush,
                    StrokeThickness = 2
                });
                Poco.Add(new PointCollection());
                i++;
            }
            i = 0;
            while (i < Total_Channel)
            {

                ii = 0;
                while (ii < Read_Data_In[i].Count)
                {
                    x = (double)ii * 800 / Read_Data_In[i].Count - 400;
                    y = 100 - (Read_Data_In[(int)Rank_Index[i]][ii] + 100) / (700 - (-100)) * 100;
                    Poco[i].Add(new Point(x, y));
                    ii++;
                }

                i++;
            }
            myPanel.AllowDrop = true;
            mysViewer = new ScrollViewer()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Blue_color
            };
            mysViewer.SetValue(Grid.ColumnProperty, 54);
            mysViewer.SetValue(Grid.ColumnSpanProperty, 40);
            mysViewer.SetValue(Grid.RowProperty, 2);
            mysViewer.SetValue(Grid.RowSpanProperty, 30);
            mysViewer.AllowDrop = true;
            mysViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            MainGrid.Children.Add(mysViewer);

            myPanel = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Default_back_black_color_brush,
                BorderBrush = white_button_brush,
                BorderThickness = new Thickness(1, 1, 1, 1),
                CornerRadius = new CornerRadius(1, 1, 1, 1)
            };

            mysViewer.Content = myPanel;
            i = 0;
            while (i < Total_Channel)
            {
                Poco[i].Add(Poco[i][Poco[i].Count - 1]);
                Poco[i].RemoveAt(0);
                scrollpolyline[i].Points = Poco[i];
                scrollcanvas.Add(new Canvas()
                {
                    Height = 100,
                    Background = Default_back_black_color_brush
                });
                scrollcanvas[scrollcanvas.Count - 1].Children.Add(scrollpolyline[i]);
                myPanel.Children.Add(new Button()
                {
                    Content = scrollcanvas[i],
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 200
                });
                i++;
            }
            int basev = 0;
            int ib = 0;
            while (true)
            {
                
                i = 0;
                ib = basev;
                if(Streaming_Flag)
                {
                    Test_P = new List<double>();
                    while (i < Total_Channel)
                    {

                        ii = 0;
                        while (ii < Read_Data_In[i].Count)
                        {
                            if(i==0)
                            {
                                Test_P.Add(Read_Data_In[7][ib]);
                            }
                            x = (double)ii * 800 / Read_Data_In[i].Count - 400;
                            y = 100 - (Read_Data_In[(int)Rank_Index[i]][ib] + 100) / (700 - (-100)) * 100;
                            Poco[i].Add(new Point(x, y));
                            ii++;
                            ib++;
                            if (ib == Read_Data_In[0].Count)
                            {
                                ib = 0;
                            }
                        }

                        i++;

                    }
                    i = 0;
                    while (i < Total_Channel)
                    {

                        scrollpolyline[i].Points = Poco[i];
                        i++;

                    }
                    Poco = new List<PointCollection>();
                    i = 0;
                    while (i < Total_Channel)
                    {
                        Poco.Add(new PointCollection());
                        i++;
                    }

                    myplotter1.Input_Data_Point = new List<double>(Test_P);
                    myplotter1.Create_Plot(Plotter_max, Plotter_min);
                }
                await Task.Delay(11);
                basev += 1;
                if (basev >= Read_Data_In[0].Count)
                {
                    basev = 0;
                }
            }
        }
        private async Task Save_Text(int i)
        {
            
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync("Wave0.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, Data_String(myplotter1.Input_Data_Point));

        }
        private int Total_Channel = 6;
        private List<List<double>> Read_Data_In = new List<List<double>>();
        private List<Polyline> SPOLY = new List<Polyline>();
        private async void Work_Begin()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            int i = 0;
            i = 0;
            while (i < Total_Channel)
            {
                StorageFile sampleFile = await storageFolder.CreateFileAsync("Matlab" + i.ToString() + ".txt", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(sampleFile, Data_String(myplotter1.Input_Data_Point));
                i++;
            }
        }
        private async void Refresh_Channel_Raw()
        {
            int i = 10;
            int ii = 0;
            double x = 0;
            double y = 0;
            SPOLY = new List<Polyline>();
            scrollcanvas = new List<Canvas>();
            Read_Data_In = new List<List<double>>();
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            i = 0;
            while(i< Total_Channel)
            {
                SPOLY.Add(new Polyline()
                {
                    Stroke = Light_blue_brush,
                    StrokeThickness = 2
                });

                StorageFile sampleFile = await storageFolder.GetFileAsync("Wave" + (10+i).ToString() + ".txt");
                Read_Data_In.Add(new List<double>(String_Data(await FileIO.ReadTextAsync(sampleFile))));
                i++;
            }
            myPanel.Children.Clear();
            i = 0;
            while (i < Read_Data_In.Count)
            {

                ii = 0;
                while (ii < Read_Data_In[i].Count)
                {
                    x = (double)ii * 800 / Read_Data_In[i].Count - 400;
                    y = 100 - (Read_Data_In[i][ii] + 100) / (700 - (-100)) * 100;
                    SPOLY[i].Points.Add(new Point(x, y));
                    ii++;
                }

                i++;
            }
            i = 0;
            while (i < Total_Channel)
            {
                scrollcanvas.Add(new Canvas()
                {
                    Height = 100,
                    Background = Default_back_black_color_brush
                });
                SPOLY.Add(SPOLY[i]);
                scrollcanvas[scrollcanvas.Count - 1].Children.Add(SPOLY[i]);
                myPanel.Children.Add(new Button()
                {
                    Content = scrollcanvas[i],
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 200
                });
                i++;
            }
            
        }
        private string Data_String(List<double> x)
        {
            int i = 0;
            string result = "";
            i = 0;
            while(i<x.Count)
            {
                result += x[i].ToString() + ",";
                i++;
            }

            return result;
            
        }
        private List<double> String_Data(string x)
        {
            int i = 0;
            i = 0;
            string sti = "";
            List<double> result = new List<double>();
            while(i<x.Length)
            {
                if(x[i]==',')
                {
                    result.Add(S_D(sti));
                    sti = "";
                }
                else
                {
                    sti += x[i].ToString();
                }
                i++;
            }
            return result;
        }

        private TextBlock Notice_tb = new TextBlock();

        private StackPanel myPanel = new StackPanel();
        private ScrollViewer mysViewer = new ScrollViewer();
        private Plotter myplotter1;
        private List<Canvas> scrollcanvas = new List<Canvas>();
        private List<Polyline> scrollpolyline = new List<Polyline>();

        private Slider Threshold_sd = new Slider();

        private double Plotter_max = 800;
        private double Plotter_min = 0;

        private async void UI_Setup()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("Result.txt");
            Rank_Index = new List<double>(String_Data(await FileIO.ReadTextAsync(sampleFile)));
            Tab_Sysmtem_Setup();
            Band_Selection_Setup();
            Predefined_Setup();
            Magnitude_Feature_Setup();
            Support_Setup();
            Test_Gen_Data(7);


            await Read_Pred_Data();


            Check_Date();
            Tab_Decolor();
            Feature_UI_Hide();
            Magnitude_Feature_Show();
            Magnitude_bt.BorderThickness = new Thickness(5,5,5,5);
            //Band_Selection_Show();
            //Frequency_Band_bt.BorderThickness = new Thickness(5, 5, 5, 5);
            Run_Cont();
        }
        #region Pre-defined configuration
        private TextBlock Predefined_tb = new TextBlock();
        private ComboBox Predefined_cb = new ComboBox();
        private void Predefined_Setup()
        {
            Predefined_tb = new TextBlock() {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = white_button_brush,
                FontSize = 22,
                FontWeight = FontWeights.ExtraBold,
                Text = "Pre-defined Configuration"
            };
            //MainGrid.Children.Add(Predefined_tb);
            Predefined_tb.SetValue(Grid.ColumnProperty, 5);
            Predefined_tb.SetValue(Grid.ColumnSpanProperty, 15);
            Predefined_tb.SetValue(Grid.RowProperty, 37);
            Predefined_tb.SetValue(Grid.RowSpanProperty, 5);

            Predefined_cb = new ComboBox() {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Default_back_black_color_brush,
                Background = white_button_brush,
                FontSize = 18,
                FontWeight = FontWeights.ExtraBold,
                PlaceholderText = "Pre-defined Configuration",
                PlaceholderForeground = Default_back_black_color_brush
                
            };
            MainGrid.Children.Add(Predefined_cb);
            Predefined_cb.SetValue(Grid.ColumnProperty, 5);
            Predefined_cb.SetValue(Grid.ColumnSpanProperty, 15);
            Predefined_cb.SetValue(Grid.RowProperty, 40);
            Predefined_cb.SetValue(Grid.RowSpanProperty, 3);

            Predefined_cb.Items.Add("Configuration 1");
            Predefined_cb.Items.Add("Configuration 2");
            Predefined_cb.Items.Add("Configuration 3");
            Predefined_cb.Items.Add("Configuration 4");
            Predefined_cb.Items.Add("Configuration 5");
        }
        #endregion

        #region Tab _ Feature
        private Button Frequency_Band_bt = new Button();
        private Button Shape_bt = new Button();
        private Button Magnitude_bt = new Button();
        private Button Miscellaneous_bt = new Button();
        private Border Tab_bd = new Border();
        private void Tab_Sysmtem_Setup()
        {
            Tab_bd = new Border() { 
                BorderBrush = Light_blue_brush,
                BorderThickness = new Thickness(3,0,0,3),
                CornerRadius = new CornerRadius(4,4,4,4),
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Default_back_black_color_brush
            };
            Canvas.SetZIndex(Tab_bd, -1);
            MainGrid.Children.Add(Tab_bd);
            Tab_bd.SetValue(Grid.ColumnProperty, 30);
            Tab_bd.SetValue(Grid.ColumnSpanProperty, 14);
            Tab_bd.SetValue(Grid.RowProperty, 34);
            Tab_bd.SetValue(Grid.RowSpanProperty, 25);
            #region frequency
            Frequency_Band_bt = new Button() {
                BorderBrush = Light_blue_brush,
                BorderThickness = new Thickness(0,0,0,1),
                Content = "Frequency Feature",
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Default_back_black_color_brush,
                Foreground = white_button_brush,
                FontSize = 18,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Frequency_Band_bt);
            Frequency_Band_bt.SetValue(Grid.ColumnProperty, 32);
            Frequency_Band_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Frequency_Band_bt.SetValue(Grid.RowProperty, 35);
            Frequency_Band_bt.SetValue(Grid.RowSpanProperty, 4);

            Frequency_Band_bt.Click += Frequency_Band_bt_Click;
            #endregion
            #region Shape
            Shape_bt = new Button()
            {
                BorderBrush = Light_blue_brush,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Content = "Shape Feature",
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Default_back_black_color_brush,
                Foreground = white_button_brush,
                FontSize = 18,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Shape_bt);
            Shape_bt.SetValue(Grid.ColumnProperty, 32);
            Shape_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Shape_bt.SetValue(Grid.RowProperty, 41);
            Shape_bt.SetValue(Grid.RowSpanProperty, 4);

            Shape_bt.Click += Shape_bt_Click;
            #endregion
            #region Magnitude
            Magnitude_bt = new Button()
            {
                BorderBrush = Light_blue_brush,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Content = "Magnitude Feature",
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Default_back_black_color_brush,
                Foreground = white_button_brush,
                FontSize = 18,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Magnitude_bt);
            Magnitude_bt.SetValue(Grid.ColumnProperty, 32);
            Magnitude_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Magnitude_bt.SetValue(Grid.RowProperty, 47);
            Magnitude_bt.SetValue(Grid.RowSpanProperty, 4);

            Magnitude_bt.Click += Magnitude_bt_Click;
            #endregion
            #region  Miscellaneous
            Miscellaneous_bt = new Button()
            {
                BorderBrush = Light_blue_brush,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Content = "Miscellaneous",
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Default_back_black_color_brush,
                Foreground = white_button_brush,
                FontSize = 18,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Miscellaneous_bt);
            Miscellaneous_bt.SetValue(Grid.ColumnProperty, 32);
            Miscellaneous_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Miscellaneous_bt.SetValue(Grid.RowProperty, 53);
            Miscellaneous_bt.SetValue(Grid.RowSpanProperty, 4);
            Miscellaneous_bt.Click += Miscellaneous_bt_Click;
            #endregion
        }
        private void Tab_Decolor()
        {
            Miscellaneous_bt.BorderThickness = new Thickness(0, 0, 0, 1);
            Magnitude_bt.BorderThickness = new Thickness(0, 0, 0, 1);
            Shape_bt.BorderThickness = new Thickness(0, 0, 0, 1);
            Frequency_Band_bt.BorderThickness = new Thickness(0, 0, 0, 1);
        }
        private void Miscellaneous_bt_Click(object sender, RoutedEventArgs e)
        {
            Tab_Decolor();
            Feature_UI_Hide();
            Miscellaneous_bt.BorderThickness = new Thickness(5, 5, 5, 5);
        }

        private void Magnitude_bt_Click(object sender, RoutedEventArgs e)
        {
            Tab_Decolor();
            Feature_UI_Hide();
            Magnitude_Feature_Show();
            Magnitude_bt.BorderThickness = new Thickness(5, 5, 5, 5);
        }

        private void Shape_bt_Click(object sender, RoutedEventArgs e)
        {
            Tab_Decolor();
            Feature_UI_Hide();
            Shape_bt.BorderThickness = new Thickness(5, 5, 5, 5);
        }

        private void Frequency_Band_bt_Click(object sender, RoutedEventArgs e)
        {
            Tab_Decolor();
            Feature_UI_Hide();
            Band_Selection_Show();
            Frequency_Band_bt.BorderThickness = new Thickness(5, 5, 5, 5);
        }

        private void Feature_UI_Hide()
        {
            Band_Selection_Hide();
            Magnitude_Feature_Hide();
        }
        #endregion

        #region Band_Selection _ Feature
        #region declare
        private ProgressBar Delta_B_pb = new ProgressBar();
        private Button Delta_B_bt = new Button();
        private TextBlock Delta_B_tb = new TextBlock();
        private Button Delta_B_bt_act = new Button();
        private Slider Delta_B_sd_act = new Slider();
        private TextBlock Delta_B_tb_act = new TextBlock();

        private ProgressBar Theta_B_pb = new ProgressBar();
        private Button Theta_B_bt = new Button();
        private TextBlock Theta_B_tb = new TextBlock();
        private Button Theta_B_bt_act = new Button();
        private Slider Theta_B_sd_act = new Slider();
        private TextBlock Theta_B_tb_act = new TextBlock();

        private ProgressBar Alpha_B_pb = new ProgressBar();
        private Button Alpha_B_bt = new Button();
        private TextBlock Alpha_B_tb = new TextBlock();
        private Button Alpha_B_bt_act = new Button();
        private Slider Alpha_B_sd_act = new Slider();
        private TextBlock Alpha_B_tb_act = new TextBlock();

        private ProgressBar Beta_B_pb = new ProgressBar();
        private Button Beta_B_bt = new Button();
        private TextBlock Beta_B_tb = new TextBlock();
        private Button Beta_B_bt_act = new Button();
        private Slider Beta_B_sd_act = new Slider();
        private TextBlock Beta_B_tb_act = new TextBlock();

        private ProgressBar Gamma_B_pb = new ProgressBar();
        private Button Gamma_B_bt = new Button();
        private TextBlock Gamma_B_tb = new TextBlock();
        private Button Gamma_B_bt_act = new Button();
        private Slider Gamma_B_sd_act = new Slider();
        private TextBlock Gamma_B_tb_act = new TextBlock();
        #endregion
        private void Band_Selection_Setup()
        {
            #region Delta



            Delta_B_bt = new Button()
            {
                Content = "Delta 0.5-4 Hz",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Delta_B_bt);
            Delta_B_bt.SetValue(Grid.ColumnProperty, 47);
            Delta_B_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Delta_B_bt.SetValue(Grid.RowProperty, 39);
            Delta_B_bt.SetValue(Grid.RowSpanProperty, 3);

            Delta_B_tb = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "0.7",
                FontSize = 16
            };
            MainGrid.Children.Add(Delta_B_tb);
            Delta_B_tb.SetValue(Grid.ColumnProperty, 71);
            Delta_B_tb.SetValue(Grid.ColumnSpanProperty, 4);
            Delta_B_tb.SetValue(Grid.RowProperty, 39);
            Delta_B_tb.SetValue(Grid.RowSpanProperty, 3);

            Delta_B_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2,2,2,2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Delta_B_bt_act);
            Delta_B_bt_act.SetValue(Grid.ColumnProperty, 76);
            Delta_B_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Delta_B_bt_act.SetValue(Grid.RowProperty, 39);
            Delta_B_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Delta_B_bt_act.Click += Delta_B_bt_act_Click;

            Delta_B_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12,
                Value = 0
            };
            MainGrid.Children.Add(Delta_B_sd_act);
            Delta_B_sd_act.SetValue(Grid.ColumnProperty, 81);
            Delta_B_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Delta_B_sd_act.SetValue(Grid.RowProperty, 39);
            Delta_B_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Delta_B_sd_act.ValueChanged += Delta_B_sd_act_ValueChanged;

            Delta_B_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Delta_B_tb_act);
            Delta_B_tb_act.SetValue(Grid.ColumnProperty, 81);
            Delta_B_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Delta_B_tb_act.SetValue(Grid.RowProperty, 41);
            Delta_B_tb_act.SetValue(Grid.RowSpanProperty, 2);

            Delta_B_pb = new ProgressBar()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Light_blue_brush,
                Background = Default_back_black_color_brush,
                BorderThickness = new Thickness(1, 1, 1, 1),
                CornerRadius = new CornerRadius(2, 2, 2, 2),
                BorderBrush = white_button_brush,
                Value = 14,
                Maximum = 20,
                Minimum = 0

            };
            MainGrid.Children.Add(Delta_B_pb);
            Delta_B_pb.SetValue(Grid.ColumnProperty, 55);
            Delta_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Delta_B_pb.SetValue(Grid.RowProperty, 39);
            Delta_B_pb.SetValue(Grid.RowSpanProperty, 3);
            #endregion
            #region Theta
            Theta_B_bt = new Button()
            {
                Content = "Theta 4-8 Hz",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Theta_B_bt);
            Theta_B_bt.SetValue(Grid.ColumnProperty, 47);
            Theta_B_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Theta_B_bt.SetValue(Grid.RowProperty, 43);
            Theta_B_bt.SetValue(Grid.RowSpanProperty, 3);

            Theta_B_tb = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "0.1",
                FontSize = 16
            };
            MainGrid.Children.Add(Theta_B_tb);
            Theta_B_tb.SetValue(Grid.ColumnProperty, 71);
            Theta_B_tb.SetValue(Grid.ColumnSpanProperty, 5);
            Theta_B_tb.SetValue(Grid.RowProperty, 43);
            Theta_B_tb.SetValue(Grid.RowSpanProperty, 3);



            Theta_B_pb = new ProgressBar()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Light_blue_brush,
                Background = Default_back_black_color_brush,
                BorderThickness = new Thickness(1, 1, 1, 1),
                CornerRadius = new CornerRadius(2, 2, 2, 2),
                BorderBrush = white_button_brush,
                Value = 2,
                Maximum = 20,
                Minimum = 0

            };
            MainGrid.Children.Add(Theta_B_pb);
            Theta_B_pb.SetValue(Grid.ColumnProperty, 55);
            Theta_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Theta_B_pb.SetValue(Grid.RowProperty, 43);
            Theta_B_pb.SetValue(Grid.RowSpanProperty, 3);

            Theta_B_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Theta_B_bt_act);
            Theta_B_bt_act.SetValue(Grid.ColumnProperty, 76);
            Theta_B_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Theta_B_bt_act.SetValue(Grid.RowProperty, 43);
            Theta_B_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Theta_B_bt_act.Click += Theta_B_bt_act_Click;

            Theta_B_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12,
                Value = 0
            };
            MainGrid.Children.Add(Theta_B_sd_act);
            Theta_B_sd_act.SetValue(Grid.ColumnProperty, 81);
            Theta_B_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Theta_B_sd_act.SetValue(Grid.RowProperty, 43);
            Theta_B_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Theta_B_sd_act.ValueChanged += Theta_B_sd_act_ValueChanged;

            Theta_B_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Theta_B_tb_act);
            Theta_B_tb_act.SetValue(Grid.ColumnProperty, 81);
            Theta_B_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Theta_B_tb_act.SetValue(Grid.RowProperty, 45);
            Theta_B_tb_act.SetValue(Grid.RowSpanProperty, 2);
            #endregion
            #region Alpha
            Alpha_B_bt = new Button() { 
                Content = "Alpha 8-13 Hz",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Alpha_B_bt);
            Alpha_B_bt.SetValue(Grid.ColumnProperty, 47);
            Alpha_B_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Alpha_B_bt.SetValue(Grid.RowProperty, 47);
            Alpha_B_bt.SetValue(Grid.RowSpanProperty, 3);

            Alpha_B_tb = new TextBlock() { 
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "0.4",
                FontSize = 16
            };
            MainGrid.Children.Add(Alpha_B_tb);
            Alpha_B_tb.SetValue(Grid.ColumnProperty, 71);
            Alpha_B_tb.SetValue(Grid.ColumnSpanProperty, 5);
            Alpha_B_tb.SetValue(Grid.RowProperty, 47);
            Alpha_B_tb.SetValue(Grid.RowSpanProperty, 3);



            Alpha_B_pb = new ProgressBar() {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Light_blue_brush,
                Background = Default_back_black_color_brush,
                BorderThickness = new Thickness(1, 1, 1, 1),
                CornerRadius = new CornerRadius(2,2,2,2),
                BorderBrush = white_button_brush,
                Value = 8,
                Maximum = 20,
                Minimum = 0
                
            };
            MainGrid.Children.Add(Alpha_B_pb);
            Alpha_B_pb.SetValue(Grid.ColumnProperty, 55);
            Alpha_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Alpha_B_pb.SetValue(Grid.RowProperty, 47);
            Alpha_B_pb.SetValue(Grid.RowSpanProperty, 3);

            Alpha_B_bt_act = new Button()
            {
                Content = "Deactivate",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Alpha_B_bt_act);
            Alpha_B_bt_act.SetValue(Grid.ColumnProperty, 76);
            Alpha_B_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Alpha_B_bt_act.SetValue(Grid.RowProperty, 47);
            Alpha_B_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Alpha_B_bt_act.Click += Alpha_B_bt_act_Click;

            Alpha_B_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12,
                Value = 0
            };
            MainGrid.Children.Add(Alpha_B_sd_act);
            Alpha_B_sd_act.SetValue(Grid.ColumnProperty, 81);
            Alpha_B_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Alpha_B_sd_act.SetValue(Grid.RowProperty, 47);
            Alpha_B_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Alpha_B_sd_act.ValueChanged += Alpha_B_sd_act_ValueChanged;

            Alpha_B_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivate",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Alpha_B_tb_act);
            Alpha_B_tb_act.SetValue(Grid.ColumnProperty, 81);
            Alpha_B_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Alpha_B_tb_act.SetValue(Grid.RowProperty, 49);
            Alpha_B_tb_act.SetValue(Grid.RowSpanProperty, 2);
            #endregion
            #region Beta
            Beta_B_bt = new Button()
            {
                Content = "Beta 16-32 Hz",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Beta_B_bt);
            Beta_B_bt.SetValue(Grid.ColumnProperty, 47);
            Beta_B_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Beta_B_bt.SetValue(Grid.RowProperty, 51);
            Beta_B_bt.SetValue(Grid.RowSpanProperty, 3);

            Beta_B_tb = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "0.8",
                FontSize = 16
            };
            MainGrid.Children.Add(Beta_B_tb);
            Beta_B_tb.SetValue(Grid.ColumnProperty, 71);
            Beta_B_tb.SetValue(Grid.ColumnSpanProperty, 5);
            Beta_B_tb.SetValue(Grid.RowProperty, 51);
            Beta_B_tb.SetValue(Grid.RowSpanProperty, 3);



            Beta_B_pb = new ProgressBar()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Light_blue_brush,
                Background = Default_back_black_color_brush,
                BorderThickness = new Thickness(1, 1, 1, 1),
                CornerRadius = new CornerRadius(2, 2, 2, 2),
                BorderBrush = white_button_brush,
                Value = 16,
                Maximum = 20,
                Minimum = 0

            };
            MainGrid.Children.Add(Beta_B_pb);
            Beta_B_pb.SetValue(Grid.ColumnProperty, 55);
            Beta_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Beta_B_pb.SetValue(Grid.RowProperty, 51);
            Beta_B_pb.SetValue(Grid.RowSpanProperty, 3);

            Beta_B_bt_act = new Button()
            {
                Content = "Deactivate",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Beta_B_bt_act);
            Beta_B_bt_act.SetValue(Grid.ColumnProperty, 76);
            Beta_B_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Beta_B_bt_act.SetValue(Grid.RowProperty, 51);
            Beta_B_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Beta_B_bt_act.Click += Beta_B_bt_act_Click;

            Beta_B_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12,
                Value = 0
            };
            MainGrid.Children.Add(Beta_B_sd_act);
            Beta_B_sd_act.SetValue(Grid.ColumnProperty, 81);
            Beta_B_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Beta_B_sd_act.SetValue(Grid.RowProperty, 51);
            Beta_B_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Beta_B_sd_act.ValueChanged += Beta_B_sd_act_ValueChanged;

            Beta_B_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivate",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Beta_B_tb_act);
            Beta_B_tb_act.SetValue(Grid.ColumnProperty, 81);
            Beta_B_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Beta_B_tb_act.SetValue(Grid.RowProperty, 53);
            Beta_B_tb_act.SetValue(Grid.RowSpanProperty, 2);
            #endregion
            #region Gamma
            Gamma_B_bt = new Button()
            {
                Content = "Gamma 32+ Hz",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Gamma_B_bt);
            Gamma_B_bt.SetValue(Grid.ColumnProperty, 47);
            Gamma_B_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Gamma_B_bt.SetValue(Grid.RowProperty, 55);
            Gamma_B_bt.SetValue(Grid.RowSpanProperty, 3);

            Gamma_B_tb = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "0.5",
                FontSize = 16
            };
            MainGrid.Children.Add(Gamma_B_tb);
            Gamma_B_tb.SetValue(Grid.ColumnProperty, 71);
            Gamma_B_tb.SetValue(Grid.ColumnSpanProperty, 5);
            Gamma_B_tb.SetValue(Grid.RowProperty, 55);
            Gamma_B_tb.SetValue(Grid.RowSpanProperty, 3);



            Gamma_B_pb = new ProgressBar()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Light_blue_brush,
                Background = Default_back_black_color_brush,
                BorderThickness = new Thickness(1, 1, 1, 1),
                CornerRadius = new CornerRadius(2, 2, 2, 2),
                BorderBrush = white_button_brush,
                Value = 10,
                Maximum = 20,
                Minimum = 0

            };
            MainGrid.Children.Add(Gamma_B_pb);
            Gamma_B_pb.SetValue(Grid.ColumnProperty, 55);
            Gamma_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Gamma_B_pb.SetValue(Grid.RowProperty, 55);
            Gamma_B_pb.SetValue(Grid.RowSpanProperty, 3);

            Gamma_B_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Gamma_B_bt_act);
            Gamma_B_bt_act.SetValue(Grid.ColumnProperty, 76);
            Gamma_B_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Gamma_B_bt_act.SetValue(Grid.RowProperty, 55);
            Gamma_B_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Gamma_B_bt_act.Click += Gamma_B_bt_act_Click;

            Gamma_B_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12,
                Value = 0
            };
            MainGrid.Children.Add(Gamma_B_sd_act);
            Gamma_B_sd_act.SetValue(Grid.ColumnProperty, 81);
            Gamma_B_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Gamma_B_sd_act.SetValue(Grid.RowProperty, 55);
            Gamma_B_sd_act.SetValue(Grid.RowSpanProperty, 2);

            Gamma_B_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Gamma_B_tb_act);
            Gamma_B_tb_act.SetValue(Grid.ColumnProperty, 81);
            Gamma_B_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Gamma_B_tb_act.SetValue(Grid.RowProperty, 57);
            Gamma_B_tb_act.SetValue(Grid.RowSpanProperty, 2);
            Gamma_B_sd_act.ValueChanged += Gamma_B_sd_act_ValueChanged;
            #endregion

        }

        private void Beta_B_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Beta_B_sd_act.Value == 0)
            {
                Beta_B_tb_act.Text = "Deactivated";
                Beta_B_bt_act.BorderBrush = red_bright_button_brush;
                Beta_B_bt_act.Content = "Deactivated";
                Beta_B_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Beta_B_sd_act.Value == 0.25)
            {
                Beta_B_tb_act.Text = "Low Importance";
                Beta_B_bt_act.BorderBrush = green_bright_button_brush;
                Beta_B_bt_act.Content = "Activated";
                Beta_B_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Beta_B_sd_act.Value == 0.5)
            {
                Beta_B_tb_act.Text = "Normal Importance";

            }
            else if (Beta_B_sd_act.Value == 0.75)
            {
                Beta_B_tb_act.Text = "High Importance";

            }
            else if (Beta_B_sd_act.Value == 1)
            {
                Beta_B_tb_act.Text = "Max Importance";

            }
        }

        private void Alpha_B_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Alpha_B_sd_act.Value == 0)
            {
                Alpha_B_tb_act.Text = "Deactivated";
                Alpha_B_bt_act.BorderBrush = red_bright_button_brush;
                Alpha_B_bt_act.Content = "Deactivated";
                Alpha_B_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Alpha_B_sd_act.Value == 0.25)
            {
                Alpha_B_tb_act.Text = "Low Importance";
                Alpha_B_bt_act.BorderBrush = green_bright_button_brush;
                Alpha_B_bt_act.Content = "Activated";
                Alpha_B_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Alpha_B_sd_act.Value == 0.5)
            {
                Alpha_B_tb_act.Text = "Normal Importance";

            }
            else if (Alpha_B_sd_act.Value == 0.75)
            {
                Alpha_B_tb_act.Text = "High Importance";

            }
            else if (Alpha_B_sd_act.Value == 1)
            {
                Alpha_B_tb_act.Text = "Max Importance";

            }
        }

        private void Theta_B_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Theta_B_sd_act.Value == 0)
            {
                Theta_B_tb_act.Text = "Deactivated";
                Theta_B_bt_act.BorderBrush = red_bright_button_brush;
                Theta_B_bt_act.Content = "Deactivated";
                Theta_B_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Theta_B_sd_act.Value == 0.25)
            {
                Theta_B_tb_act.Text = "Low Importance";
                Theta_B_bt_act.BorderBrush = green_bright_button_brush;
                Theta_B_bt_act.Content = "Activated";
                Theta_B_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Theta_B_sd_act.Value == 0.5)
            {
                Theta_B_tb_act.Text = "Normal Importance";

            }
            else if (Theta_B_sd_act.Value == 0.75)
            {
                Theta_B_tb_act.Text = "High Importance";

            }
            else if (Theta_B_sd_act.Value == 1)
            {
                Theta_B_tb_act.Text = "Max Importance";

            }
        }

        private void Delta_B_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Delta_B_sd_act.Value == 0)
            {
                Delta_B_tb_act.Text = "Deactivated";
                Delta_B_bt_act.BorderBrush = red_bright_button_brush;
                Delta_B_bt_act.Content = "Deactivated";
                Delta_B_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Delta_B_sd_act.Value == 0.25)
            {
                Delta_B_tb_act.Text = "Low Importance";
                Delta_B_bt_act.BorderBrush = green_bright_button_brush;
                Delta_B_bt_act.Content = "Activated";
                Delta_B_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Delta_B_sd_act.Value == 0.5)
            {
                Delta_B_tb_act.Text = "Normal Importance";

            }
            else if (Delta_B_sd_act.Value == 0.75)
            {
                Delta_B_tb_act.Text = "High Importance";

            }
            else if (Delta_B_sd_act.Value == 1)
            {
                Delta_B_tb_act.Text = "Max Importance";

            }
        }

        private void Gamma_B_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Gamma_B_sd_act.Value == 0)
            {
                Gamma_B_tb_act.Text = "Deactivated";
                Gamma_B_bt_act.BorderBrush = red_bright_button_brush;
                Gamma_B_bt_act.Content = "Deactivated";
                Gamma_B_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Gamma_B_sd_act.Value == 0.25)
            {
                Gamma_B_tb_act.Text = "Low Importance";
                Gamma_B_bt_act.BorderBrush = green_bright_button_brush;
                Gamma_B_bt_act.Content = "Activated";
                Gamma_B_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Gamma_B_sd_act.Value == 0.5)
            {
                Gamma_B_tb_act.Text = "Normal Importance";

            }
            else if (Gamma_B_sd_act.Value == 0.75)
            {
                Gamma_B_tb_act.Text = "High Importance";

            }
            else if (Gamma_B_sd_act.Value == 1)
            {
                Gamma_B_tb_act.Text = "Max Importance";

            }
        }

        private void Gamma_B_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if(Gamma_B_sd_act.Value == 0)
            {
                Gamma_B_sd_act.Value = 0.5;
                Gamma_B_bt_act.BorderBrush = green_bright_button_brush;
                Gamma_B_bt_act.Content = "Activated";
                Gamma_B_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Gamma_B_sd_act.Value = 0;
                Gamma_B_bt_act.BorderBrush = red_bright_button_brush;
                Gamma_B_bt_act.Content = "Deactivated";
                Gamma_B_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Beta_B_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Beta_B_sd_act.Value == 0)
            {
                Beta_B_sd_act.Value = 0.5;
                Beta_B_bt_act.BorderBrush = green_bright_button_brush;
                Beta_B_bt_act.Content = "Activated";
                Beta_B_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Beta_B_sd_act.Value = 0;
                Beta_B_bt_act.BorderBrush = red_bright_button_brush;
                Beta_B_bt_act.Content = "Deactivated";
                Beta_B_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Alpha_B_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Alpha_B_sd_act.Value == 0)
            {
                Alpha_B_sd_act.Value = 0.5;
                Alpha_B_bt_act.BorderBrush = green_bright_button_brush;
                Alpha_B_bt_act.Content = "Activated";
                Alpha_B_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Alpha_B_sd_act.Value = 0;
                Alpha_B_bt_act.BorderBrush = red_bright_button_brush;
                Alpha_B_bt_act.Content = "Deactivated";
                Alpha_B_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Theta_B_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Theta_B_sd_act.Value == 0)
            {
                Theta_B_sd_act.Value = 0.5;
                Theta_B_bt_act.BorderBrush = green_bright_button_brush;
                Theta_B_bt_act.Content = "Activated";
                Theta_B_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Theta_B_sd_act.Value = 0;
                Theta_B_bt_act.BorderBrush = red_bright_button_brush;
                Theta_B_bt_act.Content = "Deactivated";
                Theta_B_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Delta_B_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Delta_B_sd_act.Value == 0)
            {
                Delta_B_sd_act.Value = 0.5;
                Delta_B_bt_act.BorderBrush = green_bright_button_brush;
                Delta_B_bt_act.Content = "Activated";
                Delta_B_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Delta_B_sd_act.Value = 0;
                Delta_B_bt_act.BorderBrush = red_bright_button_brush;
                Delta_B_bt_act.Content = "Deactivated";
                Delta_B_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Band_Selection_Hide()
        {
            Delta_B_bt.Visibility = Visibility.Collapsed;
            Delta_B_tb.Visibility = Visibility.Collapsed;
            Delta_B_pb.Visibility = Visibility.Collapsed;
            Delta_B_sd_act.Visibility = Visibility.Collapsed;
            Delta_B_bt_act.Visibility = Visibility.Collapsed;
            Delta_B_tb_act.Visibility = Visibility.Collapsed;


            Theta_B_bt.Visibility = Visibility.Collapsed;
            Theta_B_tb.Visibility = Visibility.Collapsed;
            Theta_B_pb.Visibility = Visibility.Collapsed;
            Theta_B_sd_act.Visibility = Visibility.Collapsed;
            Theta_B_bt_act.Visibility = Visibility.Collapsed;
            Theta_B_tb_act.Visibility = Visibility.Collapsed;

            Alpha_B_bt.Visibility = Visibility.Collapsed;
            Alpha_B_tb.Visibility = Visibility.Collapsed;
            Alpha_B_pb.Visibility = Visibility.Collapsed;
            Alpha_B_sd_act.Visibility = Visibility.Collapsed;
            Alpha_B_bt_act.Visibility = Visibility.Collapsed;
            Alpha_B_tb_act.Visibility = Visibility.Collapsed;

            Beta_B_bt.Visibility = Visibility.Collapsed;
            Beta_B_tb.Visibility = Visibility.Collapsed;
            Beta_B_pb.Visibility = Visibility.Collapsed;
            Beta_B_sd_act.Visibility = Visibility.Collapsed;
            Beta_B_bt_act.Visibility = Visibility.Collapsed;
            Beta_B_tb_act.Visibility = Visibility.Collapsed;

            Gamma_B_bt.Visibility = Visibility.Collapsed;
            Gamma_B_tb.Visibility = Visibility.Collapsed;
            Gamma_B_pb.Visibility = Visibility.Collapsed;
            Gamma_B_sd_act.Visibility = Visibility.Collapsed;
            Gamma_B_bt_act.Visibility = Visibility.Collapsed;
            Gamma_B_tb_act.Visibility = Visibility.Collapsed;
        }

        private void Band_Selection_Show()
        {
            Delta_B_bt.Visibility = Visibility.Visible;
            Delta_B_tb.Visibility = Visibility.Visible;
            Delta_B_pb.Visibility = Visibility.Visible;
            Delta_B_sd_act.Visibility = Visibility.Visible;
            Delta_B_bt_act.Visibility = Visibility.Visible;
            Delta_B_tb_act.Visibility = Visibility.Visible;

            Theta_B_bt.Visibility = Visibility.Visible;
            Theta_B_tb.Visibility = Visibility.Visible;
            Theta_B_pb.Visibility = Visibility.Visible;
            Theta_B_sd_act.Visibility = Visibility.Visible;
            Theta_B_bt_act.Visibility = Visibility.Visible;
            Theta_B_tb_act.Visibility = Visibility.Visible;

            Alpha_B_bt.Visibility = Visibility.Visible;
            Alpha_B_tb.Visibility = Visibility.Visible;
            Alpha_B_pb.Visibility = Visibility.Visible;
            Alpha_B_sd_act.Visibility = Visibility.Visible;
            Alpha_B_bt_act.Visibility = Visibility.Visible;
            Alpha_B_tb_act.Visibility = Visibility.Visible;

            Beta_B_bt.Visibility = Visibility.Visible;
            Beta_B_tb.Visibility = Visibility.Visible;
            Beta_B_pb.Visibility = Visibility.Visible;
            Beta_B_sd_act.Visibility = Visibility.Visible;
            Beta_B_bt_act.Visibility = Visibility.Visible;
            Beta_B_tb_act.Visibility = Visibility.Visible;

            Gamma_B_bt.Visibility = Visibility.Visible;
            Gamma_B_tb.Visibility = Visibility.Visible;
            Gamma_B_pb.Visibility = Visibility.Visible;
            Gamma_B_sd_act.Visibility = Visibility.Visible;
            Gamma_B_bt_act.Visibility = Visibility.Visible;
            Gamma_B_tb_act.Visibility = Visibility.Visible;
        }
        #endregion

        #region Magnitude Feature
        private Button Max_Amp_bt = new Button();
        private TextBlock Max_Amp_tb1 = new TextBlock();
        private TextBlock Max_Amp_tb2 = new TextBlock();
        private Button Max_Amp_bt_act = new Button();
        private Slider Max_Amp_sd_act = new Slider();
        private TextBlock Max_Amp_tb_act = new TextBlock();

        private Button Charge_Den_bt = new Button();
        private TextBlock Charge_Den_tb1 = new TextBlock();
        private TextBlock Charge_Den_tb2 = new TextBlock();
        private Button Charge_Den_bt_act = new Button();
        private Slider Charge_Den_sd_act = new Slider();
        private TextBlock Charge_Den_tb_act = new TextBlock();

        private Button Charge_Tot_bt = new Button();
        private TextBlock Charge_Tot_tb1 = new TextBlock();
        private TextBlock Charge_Tot_tb2 = new TextBlock();
        private Button Charge_Tot_bt_act = new Button();
        private Slider Charge_Tot_sd_act = new Slider();
        private TextBlock Charge_Tot_tb_act = new TextBlock();

        private Button SNR_bt = new Button();
        private TextBlock SNR_tb1 = new TextBlock();
        private TextBlock SNR_tb2 = new TextBlock();
        private Button SNR_bt_act = new Button();
        private Slider SNR_sd_act = new Slider();
        private TextBlock SNR_tb_act = new TextBlock();

        private Button Spike_Activity_bt = new Button();
        private TextBlock Spike_Activity_tb1 = new TextBlock();
        private TextBlock Spike_Activity_tb2 = new TextBlock();
        private Button Spike_Activity_bt_act = new Button();
        private Slider Spike_Activity_sd_act = new Slider();
        private TextBlock Spike_Activity_tb_act = new TextBlock();

        private Button Reference_bt = new Button();
        private Button Targe_bt = new Button();
        private void Magnitude_Feature_Setup()
        {
            #region Max Amp
            Max_Amp_bt = new Button()
            {
                Content = "Max Amplitude",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Max_Amp_bt);
            Max_Amp_bt.SetValue(Grid.ColumnProperty, 44);
            Max_Amp_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Max_Amp_bt.SetValue(Grid.RowProperty, 39);
            Max_Amp_bt.SetValue(Grid.RowSpanProperty, 3);

            Max_Amp_tb1 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Max Amp",
                FontSize = 20
            };
            MainGrid.Children.Add(Max_Amp_tb1);
            Max_Amp_tb1.SetValue(Grid.ColumnProperty, 55);
            Max_Amp_tb1.SetValue(Grid.ColumnSpanProperty, 8);
            Max_Amp_tb1.SetValue(Grid.RowProperty, 39);
            Max_Amp_tb1.SetValue(Grid.RowSpanProperty, 3);

            Max_Amp_tb2 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Max Amp",
                FontSize = 20
            };
            MainGrid.Children.Add(Max_Amp_tb2);
            Max_Amp_tb2.SetValue(Grid.ColumnProperty, 64);
            Max_Amp_tb2.SetValue(Grid.ColumnSpanProperty, 8);
            Max_Amp_tb2.SetValue(Grid.RowProperty, 39);
            Max_Amp_tb2.SetValue(Grid.RowSpanProperty, 3);

            Max_Amp_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Max_Amp_bt_act);
            Max_Amp_bt_act.SetValue(Grid.ColumnProperty, 76);
            Max_Amp_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Max_Amp_bt_act.SetValue(Grid.RowProperty, 39);
            Max_Amp_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Max_Amp_bt_act.Click += Max_Amp_bt_act_Click;

            Max_Amp_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12,
                Value = 0
            };
            MainGrid.Children.Add(Max_Amp_sd_act);
            Max_Amp_sd_act.SetValue(Grid.ColumnProperty, 81);
            Max_Amp_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Max_Amp_sd_act.SetValue(Grid.RowProperty, 39);
            Max_Amp_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Max_Amp_sd_act.ValueChanged += Max_Amp_sd_act_ValueChanged;

           Max_Amp_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Max_Amp_tb_act);
            Max_Amp_tb_act.SetValue(Grid.ColumnProperty, 81);
            Max_Amp_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Max_Amp_tb_act.SetValue(Grid.RowProperty, 41);
            Max_Amp_tb_act.SetValue(Grid.RowSpanProperty, 2);

            #endregion
            #region Charge_Den
            Charge_Den_bt = new Button()
            {
                Content = "Charge Density",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Charge_Den_bt);
            Charge_Den_bt.SetValue(Grid.ColumnProperty, 44);
            Charge_Den_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Charge_Den_bt.SetValue(Grid.RowProperty, 43);
            Charge_Den_bt.SetValue(Grid.RowSpanProperty, 3);

            Charge_Den_tb1 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Charge Den",
                FontSize = 20
            };
            MainGrid.Children.Add(Charge_Den_tb1);
            Charge_Den_tb1.SetValue(Grid.ColumnProperty, 55);
            Charge_Den_tb1.SetValue(Grid.ColumnSpanProperty, 8);
            Charge_Den_tb1.SetValue(Grid.RowProperty, 43);
            Charge_Den_tb1.SetValue(Grid.RowSpanProperty, 3);

            Charge_Den_tb2 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Charge_Den",
                FontSize = 20
            };
            MainGrid.Children.Add(Charge_Den_tb2);
            Charge_Den_tb2.SetValue(Grid.ColumnProperty, 64);
            Charge_Den_tb2.SetValue(Grid.ColumnSpanProperty, 8);
            Charge_Den_tb2.SetValue(Grid.RowProperty, 43);
            Charge_Den_tb2.SetValue(Grid.RowSpanProperty, 3);

            Charge_Den_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Charge_Den_bt_act);
            Charge_Den_bt_act.SetValue(Grid.ColumnProperty, 76);
            Charge_Den_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Charge_Den_bt_act.SetValue(Grid.RowProperty, 43);
            Charge_Den_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Charge_Den_bt_act.Click += Charge_Den_bt_act_Click;

             Charge_Den_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12
            };
            MainGrid.Children.Add(Charge_Den_sd_act);
            Charge_Den_sd_act.SetValue(Grid.ColumnProperty, 81);
            Charge_Den_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Charge_Den_sd_act.SetValue(Grid.RowProperty, 43);
            Charge_Den_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Charge_Den_sd_act.ValueChanged += Charge_Den_sd_act_ValueChanged;

             Charge_Den_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Charge_Den_tb_act);
            Charge_Den_tb_act.SetValue(Grid.ColumnProperty, 81);
            Charge_Den_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Charge_Den_tb_act.SetValue(Grid.RowProperty, 45);
            Charge_Den_tb_act.SetValue(Grid.RowSpanProperty, 2);

            #endregion
            #region Charge_Tot
            Charge_Tot_bt = new Button()
            {
                Content = "Total Charge",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Charge_Tot_bt);
            Charge_Tot_bt.SetValue(Grid.ColumnProperty, 44);
            Charge_Tot_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Charge_Tot_bt.SetValue(Grid.RowProperty, 47);
            Charge_Tot_bt.SetValue(Grid.RowSpanProperty, 3);

            Charge_Tot_tb1 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Charge_Tot",
                FontSize = 20
            };
            MainGrid.Children.Add(Charge_Tot_tb1);
            Charge_Tot_tb1.SetValue(Grid.ColumnProperty, 55);
            Charge_Tot_tb1.SetValue(Grid.ColumnSpanProperty, 8);
            Charge_Tot_tb1.SetValue(Grid.RowProperty, 47);
            Charge_Tot_tb1.SetValue(Grid.RowSpanProperty, 3);

            Charge_Tot_tb2 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Charge_Tot",
                FontSize = 20
            };
            MainGrid.Children.Add(Charge_Tot_tb2);
            Charge_Tot_tb2.SetValue(Grid.ColumnProperty, 64);
            Charge_Tot_tb2.SetValue(Grid.ColumnSpanProperty, 8);
            Charge_Tot_tb2.SetValue(Grid.RowProperty, 47);
            Charge_Tot_tb2.SetValue(Grid.RowSpanProperty, 3);   

            Charge_Tot_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Charge_Tot_bt_act);
            Charge_Tot_bt_act.SetValue(Grid.ColumnProperty, 76);
            Charge_Tot_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Charge_Tot_bt_act.SetValue(Grid.RowProperty, 47);
            Charge_Tot_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Charge_Tot_bt_act.Click += Charge_Tot_bt_act_Click;

            Charge_Tot_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12
            };
            MainGrid.Children.Add(Charge_Tot_sd_act);
            Charge_Tot_sd_act.SetValue(Grid.ColumnProperty, 81);
            Charge_Tot_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Charge_Tot_sd_act.SetValue(Grid.RowProperty, 47);
            Charge_Tot_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Charge_Tot_sd_act.ValueChanged += Charge_Tot_sd_act_ValueChanged;

            Charge_Tot_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Charge_Tot_tb_act);
            Charge_Tot_tb_act.SetValue(Grid.ColumnProperty, 81);
            Charge_Tot_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Charge_Tot_tb_act.SetValue(Grid.RowProperty, 49);
            Charge_Tot_tb_act.SetValue(Grid.RowSpanProperty, 2);

            #endregion
            #region SNR
            SNR_bt = new Button()
            {
                Content = "Approx SNR",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(SNR_bt);
            SNR_bt.SetValue(Grid.ColumnProperty, 44);
            SNR_bt.SetValue(Grid.ColumnSpanProperty, 10);
            SNR_bt.SetValue(Grid.RowProperty, 51);
            SNR_bt.SetValue(Grid.RowSpanProperty, 3);

            SNR_tb1 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "SNR",
                FontSize = 20
            };
            MainGrid.Children.Add(SNR_tb1);
            SNR_tb1.SetValue(Grid.ColumnProperty, 55);
            SNR_tb1.SetValue(Grid.ColumnSpanProperty, 8);
            SNR_tb1.SetValue(Grid.RowProperty, 51);
            SNR_tb1.SetValue(Grid.RowSpanProperty, 3);

            SNR_tb2 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "SNR",
                FontSize = 20
            };
            MainGrid.Children.Add(SNR_tb2);
            SNR_tb2.SetValue(Grid.ColumnProperty, 64);
            SNR_tb2.SetValue(Grid.ColumnSpanProperty, 8);
            SNR_tb2.SetValue(Grid.RowProperty, 51);
            SNR_tb2.SetValue(Grid.RowSpanProperty, 3);

            SNR_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(SNR_bt_act);
            SNR_bt_act.SetValue(Grid.ColumnProperty, 76);
            SNR_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            SNR_bt_act.SetValue(Grid.RowProperty, 51);
            SNR_bt_act.SetValue(Grid.RowSpanProperty, 3);
            SNR_bt_act.Click += SNR_bt_act_Click;

           SNR_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12
            };
            MainGrid.Children.Add(SNR_sd_act);
            SNR_sd_act.SetValue(Grid.ColumnProperty, 81);
            SNR_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            SNR_sd_act.SetValue(Grid.RowProperty, 51);
            SNR_sd_act.SetValue(Grid.RowSpanProperty, 2);
            SNR_sd_act.ValueChanged += SNR_sd_act_ValueChanged;

            SNR_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(SNR_tb_act);
            SNR_tb_act.SetValue(Grid.ColumnProperty, 81);
            SNR_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            SNR_tb_act.SetValue(Grid.RowProperty, 53);
            SNR_tb_act.SetValue(Grid.RowSpanProperty, 2);

            #endregion
            #region Thres_Avg
            Targe_bt = new Button()
            {
                Content = "Target",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = Light_blue_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold,
                BorderBrush = Light_blue_brush,
                BorderThickness = new Thickness(3,3,3,3)
            };
            MainGrid.Children.Add(Targe_bt);
            Targe_bt.SetValue(Grid.ColumnProperty, 64);
            Targe_bt.SetValue(Grid.ColumnSpanProperty, 8);
            Targe_bt.SetValue(Grid.RowProperty, 35);
            Targe_bt.SetValue(Grid.RowSpanProperty, 3);

            Reference_bt = new Button()
            {
                Content = "Reference",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = Light_blue_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold,
                BorderBrush = Light_blue_brush,
                BorderThickness = new Thickness(3, 3, 3, 3)
            };
            MainGrid.Children.Add(Reference_bt);
            Reference_bt.SetValue(Grid.ColumnProperty, 55);
            Reference_bt.SetValue(Grid.ColumnSpanProperty, 8);
            Reference_bt.SetValue(Grid.RowProperty, 35);
            Reference_bt.SetValue(Grid.RowSpanProperty, 3);

            Spike_Activity_bt = new Button()
            {
                Content = "Spike Activity",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Spike_Activity_bt);
            Spike_Activity_bt.SetValue(Grid.ColumnProperty, 44);
            Spike_Activity_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Spike_Activity_bt.SetValue(Grid.RowProperty, 55);
            Spike_Activity_bt.SetValue(Grid.RowSpanProperty, 3);

            Spike_Activity_tb1 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Thres_Avg",
                FontSize = 20
            };
            MainGrid.Children.Add(Spike_Activity_tb1);
            Spike_Activity_tb1.SetValue(Grid.ColumnProperty, 55);
            Spike_Activity_tb1.SetValue(Grid.ColumnSpanProperty, 8);
            Spike_Activity_tb1.SetValue(Grid.RowProperty, 55);
            Spike_Activity_tb1.SetValue(Grid.RowSpanProperty, 3);

            Spike_Activity_tb2 = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                FontWeight = FontWeights.ExtraBold,
                Foreground = white_button_brush,
                Text = "Thres_Avg",
                FontSize = 20
            };
            MainGrid.Children.Add(Spike_Activity_tb2);
            Spike_Activity_tb2.SetValue(Grid.ColumnProperty, 64);
            Spike_Activity_tb2.SetValue(Grid.ColumnSpanProperty, 8);
            Spike_Activity_tb2.SetValue(Grid.RowProperty, 55);
            Spike_Activity_tb2.SetValue(Grid.RowSpanProperty, 3);

            Spike_Activity_bt_act = new Button()
            {
                Content = "Deactivated",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = red_bright_button_brush,
                Background = Default_back_black_color_brush,
                FontSize = 14,
                FontWeight = FontWeights.ExtraBold,
                BorderThickness = new Thickness(2, 2, 2, 2),
                BorderBrush = red_bright_button_brush
            };
            MainGrid.Children.Add(Spike_Activity_bt_act);
            Spike_Activity_bt_act.SetValue(Grid.ColumnProperty, 76);
            Spike_Activity_bt_act.SetValue(Grid.ColumnSpanProperty, 4);
            Spike_Activity_bt_act.SetValue(Grid.RowProperty, 55);
            Spike_Activity_bt_act.SetValue(Grid.RowSpanProperty, 3);
            Spike_Activity_bt_act.Click += Spike_Activity_bt_act_Click;

            Spike_Activity_sd_act = new Slider()
            {
                Maximum = 1,
                Minimum = 0,
                StepFrequency = 0.25,
                TickFrequency = 0.25,
                Orientation = Orientation.Horizontal,
                Foreground = green_bright_button_brush,
                Background = Light_blue_brush,
                FontSize = 12,
                Value = 0
            };
            MainGrid.Children.Add(Spike_Activity_sd_act);
            Spike_Activity_sd_act.SetValue(Grid.ColumnProperty, 81);
            Spike_Activity_sd_act.SetValue(Grid.ColumnSpanProperty, 12);
            Spike_Activity_sd_act.SetValue(Grid.RowProperty, 55);
            Spike_Activity_sd_act.SetValue(Grid.RowSpanProperty, 2);
            Spike_Activity_sd_act.ValueChanged += Spike_Activity_sd_act_ValueChanged;

            Spike_Activity_tb_act = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                TextAlignment = TextAlignment.Center,
                Foreground = white_button_brush,
                Text = "Deactivated",
                FontWeight = FontWeights.Bold,
                FontSize = 16
            };
            MainGrid.Children.Add(Spike_Activity_tb_act);
            Spike_Activity_tb_act.SetValue(Grid.ColumnProperty, 81);
            Spike_Activity_tb_act.SetValue(Grid.ColumnSpanProperty, 12);
            Spike_Activity_tb_act.SetValue(Grid.RowProperty, 57);
            Spike_Activity_tb_act.SetValue(Grid.RowSpanProperty, 2);
            

            #endregion
        }
        private void Ref_Tar_Decolor()
        {
            Targe_bt.BorderThickness = new Thickness(0,0,0,0);
            Reference_bt.BorderThickness = new Thickness(0, 0, 0, 0);
        }
        private void Spike_Activity_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Spike_Activity_sd_act.Value == 0)
            {
                Spike_Activity_tb_act.Text = "Deactivated";
                Spike_Activity_bt_act.BorderBrush = red_bright_button_brush;
                Spike_Activity_bt_act.Content = "Deactivated";
                Spike_Activity_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Spike_Activity_sd_act.Value == 0.25)
            {
                Spike_Activity_tb_act.Text = "Low Importance";
                Spike_Activity_bt_act.BorderBrush = green_bright_button_brush;
                Spike_Activity_bt_act.Content = "Activated";
                Spike_Activity_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Spike_Activity_sd_act.Value == 0.5)
            {
                Spike_Activity_tb_act.Text = "Normal Importance";

            }
            else if (Spike_Activity_sd_act.Value == 0.75)
            {
                Spike_Activity_tb_act.Text = "High Importance";

            }
            else if (Spike_Activity_sd_act.Value == 1)
            {
                Spike_Activity_tb_act.Text = "Max Importance";

            }
        }

        private void Spike_Activity_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Spike_Activity_sd_act.Value == 0)
            {
                Spike_Activity_sd_act.Value = 0.5;
                Spike_Activity_bt_act.BorderBrush = green_bright_button_brush;
                Spike_Activity_bt_act.Content = "Activated";
                Spike_Activity_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Spike_Activity_sd_act.Value = 0;
                Spike_Activity_bt_act.BorderBrush = red_bright_button_brush;
                Spike_Activity_bt_act.Content = "Deactivated";
                Spike_Activity_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void SNR_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (SNR_sd_act.Value == 0)
            {
                SNR_tb_act.Text = "Deactivated";
                SNR_bt_act.BorderBrush = red_bright_button_brush;
                SNR_bt_act.Content = "Deactivated";
                SNR_bt_act.Foreground = red_bright_button_brush;
            }
            else if (SNR_sd_act.Value == 0.25)
            {
                SNR_tb_act.Text = "Low Importance";
                SNR_bt_act.BorderBrush = green_bright_button_brush;
                SNR_bt_act.Content = "Activated";
                SNR_bt_act.Foreground = green_bright_button_brush;
            }
            else if (SNR_sd_act.Value == 0.5)
            {
                SNR_tb_act.Text = "Normal Importance";

            }
            else if (SNR_sd_act.Value == 0.75)
            {
                SNR_tb_act.Text = "High Importance";

            }
            else if (SNR_sd_act.Value == 1)
            {
                SNR_tb_act.Text = "Max Importance";

            }
        }

        private void SNR_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (SNR_sd_act.Value == 0)
            {
                SNR_sd_act.Value = 0.5;
                SNR_bt_act.BorderBrush = green_bright_button_brush;
                SNR_bt_act.Content = "Activated";
                SNR_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                SNR_sd_act.Value = 0;
                SNR_bt_act.BorderBrush = red_bright_button_brush;
                SNR_bt_act.Content = "Deactivated";
                SNR_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Charge_Tot_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Charge_Tot_sd_act.Value == 0)
            {
                Charge_Tot_tb_act.Text = "Deactivated";
                Charge_Tot_bt_act.BorderBrush = red_bright_button_brush;
                Charge_Tot_bt_act.Content = "Deactivated";
                Charge_Tot_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Charge_Tot_sd_act.Value == 0.25)
            {
                Charge_Tot_tb_act.Text = "Low Importance";
                Charge_Tot_bt_act.BorderBrush = green_bright_button_brush;
                Charge_Tot_bt_act.Content = "Activated";
                Charge_Tot_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Charge_Tot_sd_act.Value == 0.5)
            {
                Charge_Tot_tb_act.Text = "Normal Importance";

            }
            else if (Charge_Tot_sd_act.Value == 0.75)
            {
                Charge_Tot_tb_act.Text = "High Importance";

            }
            else if (Charge_Tot_sd_act.Value == 1)
            {
                Charge_Tot_tb_act.Text = "Max Importance";

            }
        }

        private void Charge_Tot_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Charge_Tot_sd_act.Value == 0)
            {
                Charge_Tot_sd_act.Value = 0.5;
                Charge_Tot_bt_act.BorderBrush = green_bright_button_brush;
                Charge_Tot_bt_act.Content = "Activated";
                Charge_Tot_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Charge_Tot_sd_act.Value = 0;
                Charge_Tot_bt_act.BorderBrush = red_bright_button_brush;
                Charge_Tot_bt_act.Content = "Deactivated";
                Charge_Tot_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Charge_Den_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Charge_Den_sd_act.Value == 0)
            {
                Charge_Den_tb_act.Text = "Deactivated";
                Charge_Den_bt_act.BorderBrush = red_bright_button_brush;
                Charge_Den_bt_act.Content = "Deactivated";
                Charge_Den_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Charge_Den_sd_act.Value == 0.25)
            {
                Charge_Den_tb_act.Text = "Low Importance";
                Charge_Den_bt_act.BorderBrush = green_bright_button_brush;
                Charge_Den_bt_act.Content = "Activated";
                Charge_Den_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Charge_Den_sd_act.Value == 0.5)
            {
                Charge_Den_tb_act.Text = "Normal Importance";

            }
            else if (Charge_Den_sd_act.Value == 0.75)
            {
                Charge_Den_tb_act.Text = "High Importance";

            }
            else if (Charge_Den_sd_act.Value == 1)
            {
                Charge_Den_tb_act.Text = "Max Importance";

            }
        }

        private void Charge_Den_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Charge_Den_sd_act.Value == 0)
            {
                Charge_Den_sd_act.Value = 0.5;
                Charge_Den_bt_act.BorderBrush = green_bright_button_brush;
                Charge_Den_bt_act.Content = "Activated";
                Charge_Den_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Charge_Den_sd_act.Value = 0;
                Charge_Den_bt_act.BorderBrush = red_bright_button_brush;
                Charge_Den_bt_act.Content = "Deactivated";
                Charge_Den_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Max_Amp_sd_act_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (Max_Amp_sd_act.Value == 0)
            {
                Max_Amp_tb_act.Text = "Deactivated";
                Max_Amp_bt_act.BorderBrush = red_bright_button_brush;
                Max_Amp_bt_act.Content = "Deactivated";
                Max_Amp_bt_act.Foreground = red_bright_button_brush;
            }
            else if (Max_Amp_sd_act.Value == 0.25)
            {
                Max_Amp_tb_act.Text = "Low Importance";
                Max_Amp_bt_act.BorderBrush = green_bright_button_brush;
                Max_Amp_bt_act.Content = "Activated";
                Max_Amp_bt_act.Foreground = green_bright_button_brush;
            }
            else if (Max_Amp_sd_act.Value == 0.5)
            {
                Max_Amp_tb_act.Text = "Normal Importance";

            }
            else if (Max_Amp_sd_act.Value == 0.75)
            {
                Max_Amp_tb_act.Text = "High Importance";

            }
            else if (Max_Amp_sd_act.Value == 1)
            {
                Max_Amp_tb_act.Text = "Max Importance";

            }
        }

        private void Max_Amp_bt_act_Click(object sender, RoutedEventArgs e)
        {
            if (Max_Amp_sd_act.Value == 0)
            {
                Max_Amp_sd_act.Value = 0.5;
                Max_Amp_bt_act.BorderBrush = green_bright_button_brush;
                Max_Amp_bt_act.Content = "Activated";
                Max_Amp_bt_act.Foreground = green_bright_button_brush;
            }
            else
            {
                Max_Amp_sd_act.Value = 0;
                Max_Amp_bt_act.BorderBrush = red_bright_button_brush;
                Max_Amp_bt_act.Content = "Deactivated";
                Max_Amp_bt_act.Foreground = red_bright_button_brush;
            }
        }

        private void Magnitude_Feature_Show()
        {
            Reference_bt.Visibility = Visibility.Visible;

            Max_Amp_bt.Visibility = Visibility.Visible;
            Max_Amp_tb1.Visibility = Visibility.Visible;
            Max_Amp_tb2.Visibility = Visibility.Visible;
            Max_Amp_bt_act.Visibility = Visibility.Visible;
            Max_Amp_sd_act.Visibility = Visibility.Visible;
            Max_Amp_tb_act.Visibility = Visibility.Visible;

            Charge_Den_bt.Visibility = Visibility.Visible;
            Charge_Den_tb1.Visibility = Visibility.Visible;
            Charge_Den_tb2.Visibility = Visibility.Visible;
            Charge_Den_bt_act.Visibility = Visibility.Visible;
            Charge_Den_sd_act.Visibility = Visibility.Visible;
            Charge_Den_tb_act.Visibility = Visibility.Visible;

            Charge_Tot_bt.Visibility = Visibility.Visible;
            Charge_Tot_tb1.Visibility = Visibility.Visible;
            Charge_Tot_tb2.Visibility = Visibility.Visible;
            Charge_Tot_bt_act.Visibility = Visibility.Visible;
            Charge_Tot_sd_act.Visibility = Visibility.Visible;
            Charge_Tot_tb_act.Visibility = Visibility.Visible;

            SNR_bt.Visibility = Visibility.Visible;
            SNR_tb1.Visibility = Visibility.Visible;
            SNR_tb2.Visibility = Visibility.Visible;
            SNR_bt_act.Visibility = Visibility.Visible;
            SNR_sd_act.Visibility = Visibility.Visible;
            SNR_tb_act.Visibility = Visibility.Visible;

            Spike_Activity_bt.Visibility = Visibility.Visible;
            Spike_Activity_tb1.Visibility = Visibility.Visible;
            Spike_Activity_tb2.Visibility = Visibility.Visible;
            Spike_Activity_bt_act.Visibility = Visibility.Visible;
            Spike_Activity_sd_act.Visibility = Visibility.Visible;
            Spike_Activity_tb_act.Visibility = Visibility.Visible;

        }

        private void Magnitude_Feature_Hide()
        {
            Reference_bt.Visibility = Visibility.Collapsed;

            Max_Amp_bt.Visibility = Visibility.Collapsed;
            Max_Amp_tb1.Visibility = Visibility.Collapsed;
            Max_Amp_tb2.Visibility = Visibility.Collapsed;
            Max_Amp_bt_act.Visibility = Visibility.Collapsed;
            Max_Amp_sd_act.Visibility = Visibility.Collapsed;
            Max_Amp_tb_act.Visibility = Visibility.Collapsed;

            Charge_Den_bt.Visibility = Visibility.Collapsed;
            Charge_Den_tb1.Visibility = Visibility.Collapsed;
            Charge_Den_tb2.Visibility = Visibility.Collapsed;
            Charge_Den_bt_act.Visibility = Visibility.Collapsed;
            Charge_Den_sd_act.Visibility = Visibility.Collapsed;
            Charge_Den_tb_act.Visibility = Visibility.Collapsed;

            Charge_Tot_bt.Visibility = Visibility.Collapsed;
            Charge_Tot_tb1.Visibility = Visibility.Collapsed;
            Charge_Tot_tb2.Visibility = Visibility.Collapsed;
            Charge_Tot_bt_act.Visibility = Visibility.Collapsed;
            Charge_Tot_sd_act.Visibility = Visibility.Collapsed;
            Charge_Tot_tb_act.Visibility = Visibility.Collapsed;

            SNR_bt.Visibility = Visibility.Collapsed;
            SNR_tb1.Visibility = Visibility.Collapsed;
            SNR_tb2.Visibility = Visibility.Collapsed;
            SNR_bt_act.Visibility = Visibility.Collapsed;
            SNR_sd_act.Visibility = Visibility.Collapsed;
            SNR_tb_act.Visibility = Visibility.Collapsed;

            Spike_Activity_bt.Visibility = Visibility.Collapsed;
            Spike_Activity_tb1.Visibility = Visibility.Collapsed;
            Spike_Activity_tb2.Visibility = Visibility.Collapsed;
            Spike_Activity_bt_act.Visibility = Visibility.Collapsed;
            Spike_Activity_sd_act.Visibility = Visibility.Collapsed;
            Spike_Activity_tb_act.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Support
        private Button Suggestion_bt = new Button();

        private void Support_Setup()
        {
            Suggestion_bt = new Button()
            {
                Content = "Action",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Foreground = white_button_brush,
                Background = Default_back_black_color_brush,
                VerticalContentAlignment = VerticalAlignment.Top,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold
            };
            MainGrid.Children.Add(Suggestion_bt);
            Suggestion_bt.SetValue(Grid.ColumnProperty, 5);
            Suggestion_bt.SetValue(Grid.ColumnSpanProperty, 10);
            Suggestion_bt.SetValue(Grid.RowProperty, 49);
            Suggestion_bt.SetValue(Grid.RowSpanProperty, 4);
            Suggestion_bt.Click += Suggestion_bt_Click;
        }
        private void Update_Info()
        {
            #region tb1
            Max_Amp_tb1.Text = myplotter1.Input_Data_Point[maxi].ToString() + " uV";
            Max_Amp_tb1.Foreground = ardu_brush;
            Max_Amp_tb1.FontSize = 24;

            //Thres_Avg_bt

            //Ref_Aprox_SNR

            SNR_tb1.Text = Ref_Aprox_SNR.ToString("F3");
            SNR_tb1.Foreground = ardu_brush;
            SNR_tb1.FontSize = 24;

            Spike_Activity_tb1.Text = Zero_Crossing.Count.ToString();
            Spike_Activity_tb1.Foreground = ardu_brush;
            Spike_Activity_tb1.FontSize = 24;

            Charge_Den_tb1.Text = info_avg.ToString("F3");
            Charge_Den_tb1.Foreground = ardu_brush;
            Charge_Den_tb1.FontSize = 24;

            Charge_Tot_tb1.Text = info_Tcharge.ToString("E3");
            Charge_Tot_tb1.Foreground = ardu_brush;
            Charge_Tot_tb1.FontSize = 24;
            //Min_Amp_tb1.Text = myplotter1.Input_Data_Point[mini].ToString();
            //Min_Amp_tb1.Foreground = Teal_color;
            #endregion

            #region tb2
            Max_Amp_tb2.Text = Read_Data_In[(int)Rank_Index[0]][T_maxi].ToString() + " uV";
            Max_Amp_tb2.Foreground = ardu_brush;
            Max_Amp_tb2.FontSize = 24;

            //Thres_Avg_bt

            //Ref_Aprox_SNR

            SNR_tb2.Text = T_Ref_Aprox_SNR.ToString("F3");
            SNR_tb2.Foreground = ardu_brush;
            SNR_tb2.FontSize = 24;

            Spike_Activity_tb2.Text = T_Zero_Crossing.Count.ToString();
            Spike_Activity_tb2.Foreground = ardu_brush;
            Spike_Activity_tb2.FontSize = 24;

            Charge_Den_tb2.Text = T_info_avg.ToString("F3");
            Charge_Den_tb2.Foreground = ardu_brush;
            Charge_Den_tb2.FontSize = 24;

            Charge_Tot_tb2.Text = T_info_Tcharge.ToString("E3");
            Charge_Tot_tb2.Foreground = ardu_brush;
            Charge_Tot_tb2.FontSize = 24;
            #endregion
        }
        private async void Suggestion_bt_Click(object sender, RoutedEventArgs e)
        {
            
            if(Streaming_Flag)
            {
                await Save_Text(0);
                //Refresh_Channel_Raw();
                Streaming_Flag = false;
                await Task.Delay(100);
                Suggestion_bt.Content = "Resume";
                myplotter1.Create_Plot(Plotter_max, Plotter_min);

                Info_Cal(myplotter1.Input_Data_Point, new List<double>() { 1, 1, 1, 1, 1 }); // data, filter, thres
                T_Info_Cal(Read_Data_In[(int)Rank_Index[0]], new List<double>() { 1, 1, 1, 1, 1 });
                //myplotter1.Add_Plot(Plotter_max, Plotter_min, myplotter1.Input_Data_Point, Light_blue_brush);
                myplotter1.Add_Plot(Plotter_max, Plotter_min, Denoise_Signal, green_bright_button_brush);
                //myplotter1.Add_Zcross(Zero_Crossing, myplotter1.Input_Data_Point.Count, Sky_blue_color);
                Notice_tb.Text = Zero_Crossing.Count.ToString();
                Notice_tb.Text += Threshold_sd.Value.ToString();
                //myplotter1.Add_Point(Plotter_max, Plotter_min, myplotter1.Input_Data_Point, new List<int>() { maxi } ,Violet_Red); 
                //myplotter1.Add_Point(Plotter_max, Plotter_min, myplotter1.Input_Data_Point, new List<int>() { mini }, Dodge_blue_brush);
                //myplotter1.Add_PolyGon(Plotter_max, Plotter_min, Zero_Crossing[0], Zero_Crossing[1], myplotter1.Input_Data_Point, Teal_color);
                Update_Info();

            }
            else
            {
                Streaming_Flag = true;
                Suggestion_bt.Content = "Action";  
                
            }
            
        }

        #endregion
        private List<double> Arduino_Input = new List<double>();
        private async void MainPage_loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int ii = 0;
            UI_Setup();
            //await Save_Text(7);
            #region mainpage_info
            mainpage_info.maingrid = MainGrid;
            mainpage_info.mainpage = myPage;
            mainpage_info.column = 96;
            mainpage_info.row = 64;
            mainpage_info.Width = MainGrid.ActualWidth;
            mainpage_info.Height = MainGrid.ActualHeight;
            mainpage_info.Fontsize = 1;
            #endregion
            #region Header Textblock
            Notice_tb = new TextBlock() { 
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = white_button_brush,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap
            };
            MainGrid.Children.Add(Notice_tb);
            Notice_tb.SetValue(Grid.ColumnProperty,0);
            Notice_tb.SetValue(Grid.ColumnSpanProperty, 90);
            Notice_tb.SetValue(Grid.RowProperty, 0);
            Notice_tb.SetValue(Grid.RowSpanProperty, 5);
            Notice_tb.Text = ApplicationData.Current.LocalFolder.Path;
            #endregion
            //tgd = new List<double>() { 0.15774243, 0.69950381, 1.06226376, 0.44583132,  -0.31998660, -0.18351806, 0.13788809, 0.03892321, -0.04466375, 0.000783251152, 0.00675606236, -0.00152353381 };
            //tgd = new List<double>() { -0.00152353381, -0.00675606236, 0.000783251152, 0.04466375, 0.03892321, -0.13788809, -0.18351806, 0.31998660, 0.44583132, -1.06226376, 0.69950381, -0.15774243 };

            //#region Scroll
            //i = 0;
            //while(i<10)
            //{
            //    scrollpolyline.Add(new Polyline()
            //    {
            //        Stroke = Light_blue_brush,
            //        StrokeThickness = 2
            //    });
            //    i++;
            //}


            //double x = 0;
            //double y = 0;
            //i = 0;
            //while (i < tgd.Count)
            //{
            //    x = (double)i * 800 / tgd.Count - 400;
            //    y = 100 - (tgd[i] + 20) / (20 - (-20)) * 100;
            //    ii = 0;
            //    while(ii<10)
            //    {
            //        scrollpolyline[ii].Points.Add(new Point(x, y));
            //        ii++;
            //    }

            //    i++;
            //}


            //myPanel.AllowDrop = true;
            //mysViewer = new ScrollViewer() { 
            //    VerticalAlignment = VerticalAlignment.Stretch,
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    Background = Blue_color
            //};
            //mysViewer.SetValue(Grid.ColumnProperty, 54);
            //mysViewer.SetValue(Grid.ColumnSpanProperty, 40);
            //mysViewer.SetValue(Grid.RowProperty, 2);
            //mysViewer.SetValue(Grid.RowSpanProperty, 30);
            //mysViewer.AllowDrop = true;
            //mysViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            //MainGrid.Children.Add(mysViewer);

            //myPanel = new StackPanel()
            //{
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    VerticalAlignment = VerticalAlignment.Stretch,
            //    Background = Default_back_black_color_brush,
            //    BorderBrush = white_button_brush,
            //    BorderThickness = new Thickness(1, 1, 1, 1),
            //    CornerRadius = new CornerRadius(1,1,1,1)
            //};

            //mysViewer.Content = myPanel;

            //i = 0;
            //while (i < 10)
            //{
            //    scrollcanvas.Add(new Canvas()
            //    {
            //        Height = 100,
            //        Background = Default_back_black_color_brush
            //    });
            //    scrollpolyline.Add(scrollpolyline[i]);
            //    scrollcanvas[scrollcanvas.Count - 1].Children.Add(scrollpolyline[i]);
            //    myPanel.Children.Add(new Button()
            //    {
            //        Content = scrollcanvas[i],
            //        VerticalAlignment = VerticalAlignment.Stretch,
            //        HorizontalAlignment = HorizontalAlignment.Stretch,
            //        Height = 200
            //    });
            //    i++;
            //}


            //mysViewer.Content = myPanel;
            //#endregion
            #region Main plotter
            myplotter1 = new Plotter(mainpage_info);
            double c1 = 8;
            double cs1 = 45;
            double r1 = 5;
            double rs1 = 25;

            myplotter1.Create(c1, cs1, r1, rs1, 3);
            myplotter1.Input_Data_Point = new List<double>(tgd);
            myplotter1.Create_Plot(15, -15);
            #endregion
            #region Threshold Slider
            Threshold_sd = new Slider() {
                Maximum = Plotter_max,
                Minimum = Plotter_min,
                Value = 200,
                StepFrequency = 0.5,
                Orientation = Orientation.Vertical,
                Foreground = Light_blue_brush,
                Background =Default_back_black_color_brush,
                FontSize = 12
            };
            MainGrid.Children.Add(Threshold_sd);
            Threshold_sd.SetValue(Grid.ColumnProperty,1);
            Threshold_sd.SetValue(Grid.ColumnSpanProperty, 3);
            Threshold_sd.SetValue(Grid.RowProperty, r1);
            Threshold_sd.SetValue(Grid.RowSpanProperty, rs1-1);
            Threshold_sd.ValueChanged += Threshold_sd_ValueChanged;
            #endregion
            ConnectToSerialPort();
            AdvReadByte(ReadCancellationTokenSource.Token);
            Thres_Update();
            //Gen_Wavelet_Coeficient(0);
            //Gen_Freq_Data();

        }

        private void Threshold_sd_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Thres_Update();
        }
        private void Thres_Update()
        {
            myplotter1.Create_Threshold((Threshold_sd.Value - Threshold_sd.Minimum) / (Threshold_sd.Maximum - Threshold_sd.Minimum));
            myplotter1.Threshold_Value = Threshold_sd.Value;
        }
        #region tgd
        private List<double> tgd = new List<double>();
        private string tgd_s = "";
        private void Test_Gen_Data(int x)
        {
            tgd_s = "";
            tgd = new List<double>();
            double temp = 0;
            int i = 0;
            int ii = 0;
            ii = 0;
            i = 0;
            while(i<1000)
            {
                if(x==0)
                {
                    temp = 10 * Math.Sin(Math.PI / 200 * i);
                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                else if (x == 1)
                {
                    temp = 10 * Math.Sin(Math.PI / 100 * i) + 20 * Math.Sin(Math.PI / 150 * i);
                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                else if (x == 2)
                {
                    temp = 10 * Math.Sin(Math.PI / 100 * i) + 20 * Math.Sin(Math.PI / 150 * i) + 15 * Math.Sin(Math.PI / 170 * i);
                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                else if (x == 3)
                {
                    temp = (double)(i + ii)/10;
                    if((i+100)%100==0)
                    {
                        ii -= 100;
                    }
                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                else if (x == 4)
                {
                    temp = (double)(i + ii) / 15;
                    if (i% 200 == 0)
                    {
                        ii -= 200;
                    }
                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                else if (x == 5)
                {
                    temp = (int)(i/200);
                    temp = temp % 2 * 10;
                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                else if (x == 6)
                {
                    if((i/100)%2==0)
                    {
                        temp = 10 * Math.Sin(Math.PI / 100 * i) + 20 * Math.Sin(Math.PI / 150 * i);
                    }else
                    {
                       
                    }

                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                else if (x == 7)
                {
                    if ((i / 120) % 2 == 0)
                    {
                        temp = 10 * Math.Sin(Math.PI / 30 * i) + 20 * Math.Sin(Math.PI / 40 * i);
                        temp = temp / 4;
                    }
                    else
                    {

                    }

                    tgd.Add(temp);
                    tgd_s += temp.ToString() + ",";
                }
                i++;
            }
        }
        #endregion
        #region Freq Analysis
        private double MaxFreqData = 0;
        private List<double> FreqD = new List<double>();
        private List<double> Wavelet_Coef = new List<double>();
        private int Wavelet_WindowSize = 1000;
        private double Wavelet_Freq = 320;
        private void Gen_Wavelet_Coeficient(int mode)
        {
            int i = 0;
            Wavelet_Coef = new List<double>();
            double temp = 0;

            if (mode==0)
            {
                i = 0;
                while(i<Wavelet_WindowSize)
                {
                    temp = Math.Sin(Math.PI * 2 / Wavelet_Freq * i);
                    Wavelet_Coef.Add(temp);
                    i++;
                }
            }

        }
        private void Gen_Freq_Data()
        {
            FreqD = new List<double>();
            int i = 0;
            int ii = 0;
            double temp = 0;
            i = 0;
            while(i< (Wavelet_WindowSize/2))
            {
                FreqD.Add(0);
                i++;
            }
            i = 0;
            while(i<(tgd.Count- (Wavelet_WindowSize) -1))
            {
                temp = 0;
                ii = 0;
                while(ii< Wavelet_WindowSize)
                {
                    temp += Wavelet_Coef[ii] * tgd[ii + i];
                    ii++;
                }
                temp = Math.Abs(temp);
                if(MaxFreqData<temp)
                {
                    MaxFreqData = temp;
                }
                FreqD.Add(temp);
                i++;
            }
            while(FreqD.Count<tgd.Count)
            {
                FreqD.Add(0);
            }
            myplotter1.Input_Freq_Point = new List<double>(FreqD);
            myplotter1.Create_Freq_Ana(MaxFreqData);
        }
        #endregion
        private void MainPage_sizechange(object sender, SizeChangedEventArgs e)
        {

        }

        #region communication
        SerialDevice serialDevice = null;
        DataReader d_reader = null;
        DataWriter d_writer = null;
        CancellationTokenSource ReadCancellationTokenSource = new CancellationTokenSource();
        bool USB_Connected_flag = false;
        private async void ConnectToSerialPort()
        {
            while (true)
            {
                if (!USB_Connected_flag)
                {
                    string selector = SerialDevice.GetDeviceSelector();
                    DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);
                    if (devices.Count > 0)
                    {
                        Notice_tb.Text = selector;
                        Notice_tb.Text += "\r\n " + devices.Count.ToString();
                        Notice_tb.Text += "\r\n " + devices[0].Name.ToString();

                        DeviceInformation deviceInfo = devices[0];

                        Notice_tb.Text += "\r\n " + deviceInfo.Id.ToString();
                        try
                        {
                            serialDevice = await SerialDevice.FromIdAsync(deviceInfo.Id);
                            Notice_tb.Text += "\r\n Connected" + serialDevice.ToString();
                            serialDevice.BaudRate = 9600;
                            serialDevice.DataBits = 8;
                            serialDevice.StopBits = SerialStopBitCount.Two;
                            serialDevice.Parity = SerialParity.None;
                            d_reader = new DataReader(serialDevice.InputStream);
                            d_writer = new DataWriter(serialDevice.OutputStream);
                            USB_Connected_flag = true;
                        }
                        catch (Exception es)
                        {
                            Notice_tb.Text += "\r\n " + es.ToString();
                            await Task.Delay(3000);
                        }




                    }
                    else
                    {

                    }
                }
                else
                {
                    await Task.Delay(2000);
                }
            }
        }
        private byte[] Barray = new byte[4];
        private int Barrayi = 0;
        private int Total_Input_Count = 0;
        private int ardumax = 1000;
        private int ardumin = 0;

        private int Watch_Counter = 0;
        Stopwatch stopWatch = new Stopwatch();
        bool Streaming_Flag = true;
        private int EMG_Sig_Parse(byte x)
        {
            int result = 0;

            if (x == 0x0D)
            {
                
                if(Watch_Counter==210)
                {
                    Watch_Counter = 0;
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;
                    Notice_tb.Text = ts.ToString();
                    stopWatch = new Stopwatch();
                }
                else if(Watch_Counter == 10)
                {
                    stopWatch.Start();
                }
                Watch_Counter++;
                Barrayi = 0;
                //if (Print_Counter == 5)
                //{
                //    Print_Counter = 0;
                //    Notice_tb.Text = "";
                //}
                
                result = S_I(Encoding.UTF8.GetString(Barray));
                //Notice_tb.Text += "received" + Encoding.UTF8.GetString(Barray) + " - ";
                Arduino_Input.Add(result);
                if(result>ardumax)
                {
                    ardumax = result;
                }
                if(result<ardumin)
                {
                    ardumin = result;
                }
                Print_Counter++;
                Total_Input_Count++;
                if(Total_Input_Count%10==0 && Streaming_Flag)
                {
                    Total_Input_Count = 0;
                    myplotter1.Input_Data_Point = new List<double>(Arduino_Input);
                    myplotter1.Create_Plot(ardumax + 15, ardumin - 15);
                }
                if(Arduino_Input.Count > 501)
                {
                    //myplotter1.Input_Data_Point = new List<double>(Arduino_Input);
                    //myplotter1.Create_Plot(ardumax + 15, ardumin - 15);
                    //Arduino_Input = new List<double>();
                    //Total_Input_Count = 0;
                    //ardumin = 50;
                    //ardumax = 50;
                    Arduino_Input.RemoveAt(0);
                }

            }
            else if (x == 0x0A)
            {

                Barray[0] = 0;
                Barray[1] = 0;
                Barray[2] = 0;
                Barray[3] = 0;

            }
            else
            {
                if(Barray.Length> Barrayi)
                {
                    Barray[Barrayi] = x;
                }
                Barrayi++;

            }
            return result;
        }
        private int Print_Counter = 0;
        private async void AdvReadByte(CancellationToken cancellationToken)
        {
            Task<UInt32> loadAsyncTask;
            int bytesRead = 0;
            while (true)
            {
                if (USB_Connected_flag)
                {
                    try
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        d_reader.InputStreamOptions = InputStreamOptions.Partial;
                        loadAsyncTask = d_reader.LoadAsync(1).AsTask(cancellationToken);
                        bytesRead = Convert.ToInt32(await loadAsyncTask);
                    }
                    catch
                    {
                        throw;
                    }



                    int i = 0;
                    byte[] resultb = new byte[bytesRead];
                    while (i < bytesRead)
                    {
                        resultb[i] = d_reader.ReadByte();
                        EMG_Sig_Parse(resultb[i]);
                        i++;
                    }
                }
                else
                {
                    await Task.Delay(2000);
                }
            }
        }

        private int Text_Mode = 0;
        private int Text_row_n = 0;
        private string Text_T = "";

        #endregion
        #region feature extra
        private List<int> Zero_Crossing = new List<int>();
        private List<double> Denoise_Signal = new List<double>();
        private double Ref_Aprox_SNR = 0;
        private double info_avg = 0;
        private double info_Tcharge = 0;
        private int maxi = 0;
        private int mini = 0;

        private void Info_Cal(List<double> x, List<double> y)
        {
            double max = Plotter_min;
            double min = Plotter_max;
            List<double> result = new List<double>();
            double thres = Threshold_sd.Value;
            Denoise_Signal = new List<double>();
            Zero_Crossing = new List<int>();
            int i = 0;
            int ii = 0;
            double temp = 0;
            bool zflag = false;
            i = 0;

            while (i < x.Count)
            {
                #region max min
                info_avg += x[i];
                if (x[i] >= max)
                {
                    max = x[i];
                    maxi = i;
                }
                else if (x[i] <= min)
                {
                    min = x[i];
                    mini = i;
                }
                #endregion
                #region Zeros crossing
                if (i == 0)
                {
                    if (x[i] < thres)
                    {
                        zflag = false;
                    }
                    else
                    {
                        zflag = true;
                    }
                }
                else
                {
                    if (x[i] < thres)
                    {
                        if (zflag)
                        {
                            Zero_Crossing.Add(i);
                            zflag = false;
                        }
                    }
                    else
                    {
                        if (!zflag)
                        {
                            Zero_Crossing.Add(i);
                            zflag = true;
                        }
                    }
                }
                #endregion
                #region noise
                if (i < y.Count)
                {
                    Denoise_Signal.Add(0);
                }
                else if (i < x.Count - y.Count)
                {
                    ii = 0;
                    temp = 0;
                    while (ii < y.Count)
                    {
                        temp += x[i - y.Count / 2 + ii] * y[ii];

                        ii++;
                    }
                    Denoise_Signal.Add(temp / ii);
                    Ref_Aprox_SNR += Math.Abs(x[i - y.Count / 2] - temp) / x[i - y.Count / 2];
                }
                else
                {
                    Denoise_Signal.Add(0.0);
                }
                #endregion
                i++;
            }
            info_Tcharge = info_avg;
            info_avg /= x.Count;
            Ref_Aprox_SNR /= x.Count;

        }


        private List<int> T_Zero_Crossing = new List<int>();
        private List<double> T_Denoise_Signal = new List<double>();
        private double T_Ref_Aprox_SNR = 0;
        private double T_info_avg = 0;
        private double T_info_Tcharge = 0;
        private int T_maxi = 0;
        private int T_mini = 0;

        private void T_Info_Cal(List<double> x, List<double> y)
        {
            double max = Plotter_min;
            double min = Plotter_max;
            List<double> result = new List<double>();
            double thres = Threshold_sd.Value;
            T_Denoise_Signal = new List<double>();
            T_Zero_Crossing = new List<int>();
            int i = 0;
            int ii = 0;
            double temp = 0;
            bool zflag = false;
            i = 0;

            while (i < x.Count)
            {
                #region max min
                T_info_avg += x[i];
                if (x[i] >= max)
                {
                    max = x[i];
                    T_maxi = i;
                }
                else if (x[i] <= min)
                {
                    min = x[i];
                    T_mini = i;
                }
                #endregion
                #region Zeros crossing
                if (i == 0)
                {
                    if (x[i] < thres)
                    {
                        zflag = false;
                    }
                    else
                    {
                        zflag = true;
                    }
                }
                else
                {
                    if (x[i] < thres)
                    {
                        if (zflag)
                        {
                            T_Zero_Crossing.Add(i);
                            zflag = false;
                        }
                    }
                    else
                    {
                        if (!zflag)
                        {
                            T_Zero_Crossing.Add(i);
                            zflag = true;
                        }
                    }
                }
                #endregion
                #region noise
                if (i < y.Count)
                {
                    T_Denoise_Signal.Add(0);
                }
                else if (i < x.Count - y.Count)
                {
                    ii = 0;
                    temp = 0;
                    while (ii < y.Count)
                    {
                        temp += x[i - y.Count / 2 + ii] * y[ii];

                        ii++;
                    }
                    T_Denoise_Signal.Add(temp / ii);
                    T_Ref_Aprox_SNR += Math.Abs(x[i - y.Count / 2] - temp) / x[i - y.Count / 2];
                }
                else
                {
                    T_Denoise_Signal.Add(0.0);
                }
                #endregion
                i++;
            }
            T_info_Tcharge = T_info_avg;
            T_info_avg /= x.Count;
            T_Ref_Aprox_SNR /= x.Count;

        }
        #endregion
        #region others


        private async Task ShowDialog(string x, string y)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = x,
                Content = y,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
        private double S_D(string x)
        {
            double result = 0;
            double sign = 1;
            string before = "";
            string after = "";
            int i = 0;
            int tenpower = 1;
            int len = x.Length;
            int beforeflag = 0;
            if (len >= 1)
            {
                if (x[0] == '-')
                {
                    sign = -1;
                }
            }
            while (i < len)
            {
                if (beforeflag == 0 && x[i] != '.')
                {
                    before += x[i].ToString();
                }
                else if (beforeflag == 1 && x[i] != '.')
                {
                    after += x[i].ToString();
                    tenpower = tenpower * 10;
                }
                else if (x[i] == '.')
                {
                    beforeflag = 1;
                }
                else if (x[i] == '-')
                {
                    //sign = -1;
                }
                else
                {
                    //sign = -1;
                }
                i++;
            }
            result = (double)S_I(before) + ((double)S_I(after)) / tenpower;
            result = result * sign;
            return result;
        }
        private int S_I(string x)
        {
            int result = 0;
            int index = 0;
            int rindex = 0;
            index = x.Length;
            while (index > 0)
            {
                if (C_I(x[rindex]) != -1)
                {
                    result = result * 10 + C_I(x[rindex]);
                }
                else
                {

                }

                rindex++;
                index--;
            }
            return result;
        }
        private int C_I(char x)
        {
            int reint = 0;
            if (x == '0')
            {
                reint = 0;
            }
            else if (x == '1')
            {
                reint = 1;
            }
            else if (x == '2')
            {
                reint = 2;

            }
            else if (x == '3')
            {
                reint = 3;
            }
            else if (x == '4')
            {
                reint = 4;
            }
            else if (x == '5')
            {
                reint = 5;
            }
            else if (x == '6')
            {
                reint = 6;
            }
            else if (x == '7')
            {
                reint = 7;
            }
            else if (x == '8')
            {
                reint = 8;
            }
            else if (x == '9')
            {
                reint = 9;
            }
            else
            {
                reint = -1;
            }
            return reint;
        }
        private int S_H(string x)
        {
            int result = 0;
            int index = 0;
            int rindex = 0;
            index = x.Length;
            while (index > 0)
            {
                if (C_H(x[rindex]) != -1)
                {
                    result = result * 16 + C_H(x[rindex]);
                }
                else
                {

                }

                rindex++;
                index--;
            }
            return result;
        }
        private int C_H(char x)
        {
            int reint = 0;
            if (x == '0')
            {
                reint = 0;
            }
            else if (x == '1')
            {
                reint = 1;
            }
            else if (x == '2')
            {
                reint = 2;

            }
            else if (x == '3')
            {
                reint = 3;
            }
            else if (x == '4')
            {
                reint = 4;
            }
            else if (x == '5')
            {
                reint = 5;
            }
            else if (x == '6')
            {
                reint = 6;
            }
            else if (x == '7')
            {
                reint = 7;
            }
            else if (x == '8')
            {
                reint = 8;
            }
            else if (x == '9')
            {
                reint = 9;
            }
            else if (x == 'a' || x == 'A')
            {
                reint = 10;
            }
            else if (x == 'b' || x == 'B')
            {
                reint = 11;
            }
            else if (x == 'c' || x == 'C')
            {
                reint = 12;
            }
            else if (x == 'd' || x == 'D')
            {
                reint = 13;
            }
            else if (x == 'e' || x == 'E')
            {
                reint = 14;
            }
            else if (x == 'f' || x == 'F')
            {
                reint = 15;
            }
            else
            {
                reint = -1;
            }
            return reint;
        }
        #endregion
    }
}
