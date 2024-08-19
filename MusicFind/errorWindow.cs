using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicFind
{
    public partial class errorWindow : Form
    {
        public errorWindow()
        {
            InitializeComponent();
        }

        private void errorWindow_Load(object sender, EventArgs e)
        {

        }

        public void setErrorText(string error)
        {
            errorText.Text = error;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
