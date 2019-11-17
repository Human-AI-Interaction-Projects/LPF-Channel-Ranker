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

        private async Task Save_Text(int i)
        {
            
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync("Wave" + i.ToString() + ".txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, tgd_s);

        }
        private TextBlock Notice_tb = new TextBlock();

        private StackPanel myPanel = new StackPanel();
        private ScrollViewer mysViewer = new ScrollViewer();
        private Plotter myplotter1;
        private List<Canvas> scrollcanvas = new List<Canvas>();
        private List<Polyline> scrollpolyline = new List<Polyline>();


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
            #endregion
        }
        #endregion
        #region Band_Selection _ Feature
        #region declare
        private ProgressBar Delta_B_pb = new ProgressBar();
        private Button Delta_B_bt = new Button();
        private TextBlock Delta_B_tb = new TextBlock();

        private ProgressBar Theta_B_pb = new ProgressBar();
        private Button Theta_B_bt = new Button();
        private TextBlock Theta_B_tb = new TextBlock();

        private ProgressBar Alpha_B_pb = new ProgressBar();
        private Button Alpha_B_bt = new Button();
        private TextBlock Alpha_B_tb = new TextBlock();

        private ProgressBar Beta_B_pb = new ProgressBar();
        private Button Beta_B_bt = new Button();
        private TextBlock Beta_B_tb = new TextBlock();

        private ProgressBar Gamma_B_pb = new ProgressBar();
        private Button Gamma_B_bt = new Button();
        private TextBlock Gamma_B_tb = new TextBlock();
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
                Text = "0.5",
                FontSize = 16
            };
            MainGrid.Children.Add(Delta_B_tb);
            Delta_B_tb.SetValue(Grid.ColumnProperty, 71);
            Delta_B_tb.SetValue(Grid.ColumnSpanProperty, 5);
            Delta_B_tb.SetValue(Grid.RowProperty, 39);
            Delta_B_tb.SetValue(Grid.RowSpanProperty, 3);



            Delta_B_pb = new ProgressBar()
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
            MainGrid.Children.Add(Delta_B_pb);
            Delta_B_pb.SetValue(Grid.ColumnProperty, 55);
            Delta_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Delta_B_pb.SetValue(Grid.RowProperty, 39);
            Delta_B_pb.SetValue(Grid.RowSpanProperty, 3);
            #endregion
            #region Theta
            Theta_B_bt = new Button()
            {
                Content = "Delta 4-8 Hz",
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
                Text = "0.5",
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
                Value = 10,
                Maximum = 20,
                Minimum = 0

            };
            MainGrid.Children.Add(Theta_B_pb);
            Theta_B_pb.SetValue(Grid.ColumnProperty, 55);
            Theta_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Theta_B_pb.SetValue(Grid.RowProperty, 43);
            Theta_B_pb.SetValue(Grid.RowSpanProperty, 3);
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
                Text = "0.5",
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
                Value = 10,
                Maximum = 20,
                Minimum = 0
                
            };
            MainGrid.Children.Add(Alpha_B_pb);
            Alpha_B_pb.SetValue(Grid.ColumnProperty, 55);
            Alpha_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Alpha_B_pb.SetValue(Grid.RowProperty, 47);
            Alpha_B_pb.SetValue(Grid.RowSpanProperty, 3);
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
                Text = "0.5",
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
                Value = 10,
                Maximum = 20,
                Minimum = 0

            };
            MainGrid.Children.Add(Beta_B_pb);
            Beta_B_pb.SetValue(Grid.ColumnProperty, 55);
            Beta_B_pb.SetValue(Grid.ColumnSpanProperty, 15);
            Beta_B_pb.SetValue(Grid.RowProperty, 51);
            Beta_B_pb.SetValue(Grid.RowSpanProperty, 3);
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
            #endregion

        }
        #endregion
        private List<double> Arduino_Input = new List<double>();
        private async void MainPage_loaded(object sender, RoutedEventArgs e)
        {
            Band_Selection_Setup();
            Tab_Sysmtem_Setup();
            Test_Gen_Data(7);
            //await Save_Text(7);
            mainpage_info.maingrid = MainGrid;
            mainpage_info.mainpage = myPage;
            mainpage_info.column = 96;
            mainpage_info.row = 64;
            mainpage_info.Width = MainGrid.ActualWidth;
            mainpage_info.Height = MainGrid.ActualHeight;
            mainpage_info.Fontsize = 1;
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

            //tgd = new List<double>() { 0.15774243, 0.69950381, 1.06226376, 0.44583132,  -0.31998660, -0.18351806, 0.13788809, 0.03892321, -0.04466375, 0.000783251152, 0.00675606236, -0.00152353381 };
            //tgd = new List<double>() { -0.00152353381, -0.00675606236, 0.000783251152, 0.04466375, 0.03892321, -0.13788809, -0.18351806, 0.31998660, 0.44583132, -1.06226376, 0.69950381, -0.15774243 };

            int i = 0;
            int ii = 0;
            i = 0;
            while(i<10)
            {
                scrollpolyline.Add(new Polyline()
                {
                    Stroke = Light_blue_brush,
                    StrokeThickness = 2
                });
                i++;
            }


            double x = 0;
            double y = 0;


            i = 0;
            
            while (i < tgd.Count)
            {
                x = (double)i * 800 / tgd.Count - 400;
                y = 100 - (tgd[i] + 20) / (20 - (-20)) * 100;
                ii = 0;
                while(ii<10)
                {
                    scrollpolyline[ii].Points.Add(new Point(x, y));
                    ii++;
                }

                i++;
            }

            myplotter1 = new Plotter(mainpage_info);
            double c1 = 3;
            double cs1 = 50;
            double r1 = 5;
            double rs1 = 25;

            myplotter1.Create(c1, cs1, r1, rs1, 3);
            myplotter1.Input_Data_Point = new List<double>(tgd);
            myplotter1.Create_Plot(15,-15);


            myPanel.AllowDrop = true;
            mysViewer = new ScrollViewer() { 
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
                CornerRadius = new CornerRadius(1,1,1,1)
            };


            i = 0;
            while (i < 10)
            {
                scrollcanvas.Add(new Canvas()
                {
                    Height = 100,
                    Background = Default_back_black_color_brush
                });
                scrollpolyline.Add(scrollpolyline[i]);
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
            

            mysViewer.Content = myPanel;

            ConnectToSerialPort();
            AdvReadByte(ReadCancellationTokenSource.Token);

        }
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
            while(i<2000)
            {
                if(x==0)
                {
                    temp = 10 * Math.Sin(Math.PI / 100 * i);
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
        private int EMG_Sig_Parse(byte x)
        {
            int result = 0;

            if (x == 0x0D)
            {
                Barrayi = 0;
                if (Print_Counter == 5)
                {
                    Print_Counter = 0;
                    Notice_tb.Text = "";
                }
                
                result = S_I(Encoding.UTF8.GetString(Barray));
                Notice_tb.Text += "received" + Encoding.UTF8.GetString(Barray) + " - ";
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
                if(Total_Input_Count%10==0)
                {
                    Total_Input_Count = 0;
                    myplotter1.Input_Data_Point = new List<double>(Arduino_Input);
                    myplotter1.Create_Plot(ardumax + 15, ardumin - 15);
                }else if(Arduino_Input.Count > 2001)
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
                Barray[Barrayi] = x;
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
