using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaoMaDangKyFirefoxRunning
{
    public partial class TaoMaDangKyFirefoxRunningForm : Form
    {
        public TaoMaDangKyFirefoxRunningForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string key = CryptorEngine.Decrypt(txtR.Text);
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Mã đăng ký không đúng. Xin vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            key +=monthCalendar1.SelectionRange.Start.ToString("ddMMyyyy");

            txtS.Text = CryptorEngine.Encrypt(key);
        }
    }
}
