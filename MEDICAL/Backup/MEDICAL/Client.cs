﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MEDICAL
{
    public partial class Client : Form
    {
        DS.DS_CLIENT.ClientMst_SelectDataTable CDT = new MEDICAL.DS.DS_CLIENT.ClientMst_SelectDataTable();
        DS.DS_CLIENTTableAdapters.ClientMst_SelectTableAdapter CAdapter = new MEDICAL.DS.DS_CLIENTTableAdapters.ClientMst_SelectTableAdapter();
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int inst = CAdapter.Insert(txtame.Text, txtsurname.Text, Convert.ToDouble(txtmobile.Text), txtadd.Text, txtcity.Text);
            MessageBox.Show("Client Added Susscessfully !!", "Medical System");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            { 
            
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                CDT = CAdapter.SelectClient();
                comboBox1.DataSource = CDT;
                comboBox1.DisplayMember = "cu_name";
                comboBox1.ValueMember = "cu_id";

            }
            else if (tabControl1.SelectedIndex == 2)
            {
                CDT = CAdapter.SelectClient();
                dataGridView1.DataSource = CDT;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int del = CAdapter.Delete(Convert.ToInt32(comboBox1.SelectedValue));
            MessageBox.Show("Client Deleted !", "Medical System");
            CDT = CAdapter.SelectClient();
            comboBox1.DataSource = CDT;
            comboBox1.DisplayMember = "cu_name";
            comboBox1.ValueMember = "cu_id";

        }
    }
}
