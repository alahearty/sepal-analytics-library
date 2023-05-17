using System;
using System.Collections.Generic;
using System.IO;
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

namespace WebView2.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // LoadHTML();
            InitializeWebView();
        }
        private async void InitializeWebView()
        {
            await webview2.EnsureCoreWebView2Async();

            // Replace "index.html" with the actual path to your HTML file
            //string htmlFilePath = "C:\\Users\\alapher.woriayibapri\\Desktop\\sepal-analytics-library\\WebView2.wpf\\Portfolio\\index.html";
            //webview2.CoreWebView2.Navigate("file://" + htmlFilePath);
            webview2.CoreWebView2.Navigate("http://localhost:8080");
        }
        private void LoadHTML()
        {
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Portfolio", "index.html").Replace(@"\\", @"\").Replace(@"\WebView2.wpf\", @"\").Replace(@"\bin\Debug\", @"\");
            // string fileName = $"{Environment.CurrentDirectory}\\index.html";
            webview2.Source = new Uri($"file://{filePath}");
            //if (File.Exists(filePath))
            //{
            //    webview2.Source = new Uri($"file://{filePath}");
            //}
        }
    }
}
