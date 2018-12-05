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
            cleanTransformAndLoad();
              this.saveToCSVButton.BackColor = Color.LightGray;
                this.saveToCSVButton.ForeColor = Color.White;
                this.saveToCSVButton.Enabled = false;

            this.textArea.Text = "\r\nWelcome in beer rating parser. \r\n\r\nChoose option from menu...";
        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            try
            {
                var numberOfExtractedBeers = eTLControler.Extract();
                this.textArea.Text = "\r\nNumber of exctracted beers: \r\n\r\n" + numberOfExtractedBeers;

                this.transformButton.Cursor = Cursors.Arrow;
                this.transformButton.ForeColor = Color.Black;
                this.transformButton.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error occured during data extracting process.", "Error!",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Error);
            }
        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            try
            {
                var transform = eTLControler.Transform();
                this.textArea.Text += "\r\n\r\n... Data was successfuly transformed ...";
                this.loadButton.Cursor = Cursors.Arrow;
                this.loadButton.ForeColor = Color.Black;
                this.loadButton.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error occured during data transforming process.", "Error!",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Error);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var load = eTLControler.Load();
                this.textArea.Text += "\r\n\r\n... Data was successfuly loaded ...";
                this.transformButton.Enabled = false;
                this.transformButton.ForeColor = Color.White;

                this.saveToCSVButton.Enabled = this.extractButton.Enabled = true;
                this.saveToCSVButton.ForeColor = this.extractButton.ForeColor = Color.Black;

            }
            catch
            {
                MessageBox.Show("Error occured during data loading process.", "Error!",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Error);
            }
            presentResult();

        }

        private void ETLButton_Click(object sender, EventArgs e)
        {
            try
            {
                cleanTransformAndLoad();

                var numberOfBeers = eTLControler.Extract();
                if (eTLControler.Transform() && eTLControler.Load())
                {
                    this.textArea.Text = "\r\n\r\n... ETL process successfuly finished ...";
                }
            }
            catch
            {
                MessageBox.Show("Error occured during ETL process.", "Error!",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Error);
            }
            presentResult();
        }

        private void saveToCSVButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (eTLControler.saveDataToCSVFile())
                {
                    this.textArea.Text = "\r\n\r\n... Data successfuly saved to csv. file ...";
                }
            }
            catch
            {
                MessageBox.Show("Error occured during saving data to csv file.", "Error!",
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Error);
            }
        }

        private void clearDBbutton_Click(object sender, EventArgs e)
        {
            try
            {
                cleanTransformAndLoad();
                if(eTLControler.clearDatabase())
                {
                    this.textArea.Text = "\r\n\r\n... Cleaning database process was successful ...";
                }
            }
            catch
            {
                MessageBox.Show("Error occured during cleaning database.", "Error!",
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Error);
            }
        }

        private void presentResult()
        {
            var beers = eTLControler.getAllBeers();
            foreach(var b in beers)
            {
                //todo : implement view for beer objects, add possibility to save them to text(?) file
                //punkt 12 : aplikaca powinna mieć możliwość eksportu danych ... do oddzielnych plików
                //tekstowych dla każdej opinii/ogłoszenia/oferty
                var beerInfo = "\r\n\r\n... "+b.Name + " " + b.Percentages + " " + b.Type + " " +b.Rating + " ...";
                this.textArea.Text += beerInfo;
            }
        }

        private void cleanTransformAndLoad()
        {
            this.transformButton.Enabled = this.loadButton.Enabled = false;
            this.transformButton.ForeColor = this.loadButton.ForeColor = Color.White;
            this.transformButton.BackColor = this.loadButton.BackColor = Color.LightGray;
        }
    }
}
