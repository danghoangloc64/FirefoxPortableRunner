﻿using FirefoxPortableDatabase.BLL;
using System;
using System.Windows.Forms;

namespace FirefoxPortableClient
{
    public partial class MainForm : Form
    {
        private TaiKhoanBLL m_objTaiKhoanBLL;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(m_objTaiKhoanBLL.CheckKey(txtKey.Text))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("!OK");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_objTaiKhoanBLL = new TaiKhoanBLL();
            m_objTaiKhoanBLL.FirstLoadFirefoxPortableDatabaseContext();
        }
    }
}
