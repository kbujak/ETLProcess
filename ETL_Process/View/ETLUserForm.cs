using ETL_Process.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETL_Process
{

    public partial class ETLUserForm : Form
    {
        private ETLControler eTLControler;

        public ETLUserForm()
        {
            InitializeComponent();
            eTLControler = new ETLControler();
            SetStartup();
        }

        private void SetStartup()
        {
            
            this.transformButton.Cursor = this.loadButton.Cursor =
                this.saveToCSVButton.Cursor = Cursors.No;
            this.transformButton.ForeColor = this.loadButton.ForeColor =
                this.saveToCSVButton.ForeColor = Color.White;

            this.textArea.Text = "\r\nWelcome in beer rating parser program. \r\n\r\nChoose option from menu...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var numberOfExtractedBeers = eTLControler.Extract();
            this.textArea.Text = "\r\nNumber of exctracted beers: \r\n\r\n"+numberOfExtractedBeers;

            this.transformButton.Cursor =  Cursors.Arrow;
            this.transformButton.ForeColor = Color.Black;
        }
    }
}
