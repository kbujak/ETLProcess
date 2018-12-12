using ETL.Model;
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

        private async void extractButton_Click(object sender, EventArgs e)
        {
            try
            {

                this.textArea.Text = "\r\nExtracting beers...";
                await eTLControler.ExtractBeers();
                this.textArea.Text += "\r\nNumber of exctracted beers: \r\n\r\n" + eTLControler.getAllBeers().Count;

                this.textArea.Text += "\r\n\r\n";

                this.textArea.Text += "\r\nExtracting comments...";
                await eTLControler.ExtractComments();
                var numberOfComments = eTLControler.GetCommentsCount();
                this.textArea.Text += "\r\nNumber of exctracted comments: \r\n\r\n" + numberOfComments;

                this.transformButton.Cursor = Cursors.Arrow;
                this.transformButton.ForeColor = Color.Black;
                this.transformButton.Enabled = true;
            }
            catch(Exception ex)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error occured during data transforming process.", "Error!",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Error);
            }
            this.saveToCSVButton.Enabled = true;
            this.saveToCSVButton.ForeColor = Color.Black;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var load = eTLControler.Load();
                this.textArea.Text += "\r\n\r\n... Data was successfuly loaded ...";
                this.transformButton.Enabled = false;
                this.transformButton.ForeColor = Color.White;

                this.extractButton.Enabled = true;
                this.extractButton.ForeColor = Color.Black;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured during data loading process.", "Error!",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Error);
            }
            this.saveToCSVButton.ForeColor = Color.Black;

            presentResult();
        }

        private async void ETLButton_Click(object sender, EventArgs e)
        {
            try
            {
                cleanTransformAndLoad();

                this.textArea.Text = "\r\nExtracting beers...";
                await eTLControler.ExtractBeers();
                this.textArea.Text = "\r\nNumber of exctracted beers: \r\n\r\n" + eTLControler.getAllBeers().Count;

                this.textArea.Text = "\r\nExtracting comments...";
                await eTLControler.ExtractComments();
                var numberOfComments = eTLControler.GetCommentResult().GuestComments.Count + eTLControler.GetCommentResult().UserComments.Count;
                this.textArea.Text = "\r\nNumber of exctracted comments: \r\n\r\n" + numberOfComments;

                if (eTLControler.Transform().IsCompleted && eTLControler.Load())
                {
                    this.textArea.Text = "\r\n\r\n... ETL process successfuly finished ...";
                    this.saveToCSVButton.Enabled = true;
                    this.saveToCSVButton.ForeColor = Color.Black;
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
            this.saveToCSVButton.Enabled = false;
            this.saveToCSVButton.ForeColor = Color.White;
            try
            {
                cleanTransformAndLoad();
                if (eTLControler.clearDatabase())
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
            this.textArea.Text = "RESULT: \r\n";
            this.textArea.ScrollBars = ScrollBars.Vertical;
            this.textArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            var beers = eTLControler.getAllBeers();
            var comments = eTLControler.GetCommentResult();

            int i = 1;
            foreach (var b in beers)
            {
                var beerInfo = "\r\n" + i + ". '" + b.Name + "', Procent: " + b.Percentages + ", Typ: " + b.Type + ", Ocena: " + b.Rating;
                this.textArea.Text += beerInfo;

                var commUser = comments.UserComments.Where(c => c.BeerHash == b.BeerHash);
                var commGuest = comments.GuestComments.Where(c => c.BeerHash == b.BeerHash);

                this.textArea.Text += "\r\n\r\nKomentarze: \n\r\n";


                foreach (var cu in commUser)
                {
                    this.textArea.Text += "\t" + cu.Opinion + "\r\n\r\n";
                }
                this.textArea.Text += "\t - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\r\n";

                i++;
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
