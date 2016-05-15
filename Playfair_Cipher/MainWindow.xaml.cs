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

namespace Playfair_Cipher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            keyTable kt = new keyTable();
            Break breakCode = new Break();
            Encode encode = new Encode();
            KnownBreak known = new KnownBreak();

            InitializeComponent();
            //breakCode.breakLoop();
            known.keyBreak();
            encode.prepMessage(encode.message);
        }
    }
}
