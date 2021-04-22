using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefoxRunning
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            TopMost = true;
            Thread _thread = new Thread(() =>
            {
                Application.Run(new RegisterApplication());
            });
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

    }
}
