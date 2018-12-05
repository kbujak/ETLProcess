using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ETL_Process
{
    partial class ETLUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETLUserForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.extractButton = new System.Windows.Forms.Button();
            this.transformButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.ETLButton = new System.Windows.Forms.Button();
            this.clearDBbutton = new System.Windows.Forms.Button();
            this.saveToCSVButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textPanel = new System.Windows.Forms.Panel();
            this.textArea = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.textPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 366);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.extractButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.transformButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.loadButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ETLButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.clearDBbutton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.saveToCSVButton, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(210, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // extractButton
            // 
            this.extractButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.extractButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extractButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.extractButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extractButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.extractButton.Location = new System.Drawing.Point(10, 10);
            this.extractButton.Margin = new System.Windows.Forms.Padding(10);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(190, 48);
            this.extractButton.TabIndex = 0;
            this.extractButton.Text = "EXTRACT";
            this.extractButton.UseVisualStyleBackColor = false;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // transformButton
            // 
            this.transformButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.transformButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transformButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transformButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transformButton.ForeColor = System.Drawing.SystemColors.InfoText;
            this.transformButton.Location = new System.Drawing.Point(10, 78);
            this.transformButton.Margin = new System.Windows.Forms.Padding(10);
            this.transformButton.Name = "transformButton";
            this.transformButton.Size = new System.Drawing.Size(190, 48);
            this.transformButton.TabIndex = 1;
            this.transformButton.Text = "TRANSFORM";
            this.transformButton.UseVisualStyleBackColor = false;
            this.transformButton.Click += new System.EventHandler(this.transformButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.BackColor = System.Drawing.Color.LightBlue;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loadButton.Location = new System.Drawing.Point(10, 146);
            this.loadButton.Margin = new System.Windows.Forms.Padding(10);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(190, 48);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "LOAD";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // ETLButton
            // 
            this.ETLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ETLButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ETLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ETLButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ETLButton.Location = new System.Drawing.Point(10, 214);
            this.ETLButton.Margin = new System.Windows.Forms.Padding(10);
            this.ETLButton.Name = "ETLButton";
            this.ETLButton.Size = new System.Drawing.Size(190, 48);
            this.ETLButton.TabIndex = 3;
            this.ETLButton.Text = "ETL";
            this.ETLButton.UseVisualStyleBackColor = false;
            this.ETLButton.Click += new System.EventHandler(this.ETLButton_Click);
            // 
            // clearDBbutton
            // 
            this.clearDBbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearDBbutton.BackColor = System.Drawing.Color.SlateGray;
            this.clearDBbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearDBbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearDBbutton.Location = new System.Drawing.Point(8, 280);
            this.clearDBbutton.Margin = new System.Windows.Forms.Padding(8);
            this.clearDBbutton.Name = "clearDBbutton";
            this.clearDBbutton.Size = new System.Drawing.Size(194, 29);
            this.clearDBbutton.TabIndex = 4;
            this.clearDBbutton.Text = "CLEAR DATABASE";
            this.clearDBbutton.UseVisualStyleBackColor = false;
            this.clearDBbutton.Click += new System.EventHandler(this.clearDBbutton_Click);
            // 
            // saveToCSVButton
            // 
            this.saveToCSVButton.BackColor = System.Drawing.Color.Silver;
            this.saveToCSVButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveToCSVButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveToCSVButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveToCSVButton.Location = new System.Drawing.Point(8, 325);
            this.saveToCSVButton.Margin = new System.Windows.Forms.Padding(8);
            this.saveToCSVButton.Name = "saveToCSVButton";
            this.saveToCSVButton.Size = new System.Drawing.Size(194, 33);
            this.saveToCSVButton.TabIndex = 5;
            this.saveToCSVButton.Text = "SAVE TO .CSV FILE";
            this.saveToCSVButton.UseVisualStyleBackColor = false;
            this.saveToCSVButton.Click += new System.EventHandler(this.saveToCSVButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.textPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(210, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(20);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(531, 366);
            this.panel2.TabIndex = 1;
            // 
            // textPanel
            // 
            this.textPanel.AutoScroll = true;
            this.textPanel.AutoSize = true;
            this.textPanel.BackColor = System.Drawing.Color.White;
            this.textPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPanel.Controls.Add(this.textArea);
            this.textPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPanel.Location = new System.Drawing.Point(20, 20);
            this.textPanel.Name = "textPanel";
            this.textPanel.Size = new System.Drawing.Size(491, 326);
            this.textPanel.TabIndex = 0;
            // 
            // textArea
            // 
            this.textArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textArea.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.textArea.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textArea.Location = new System.Drawing.Point(0, 0);
            this.textArea.Margin = new System.Windows.Forms.Padding(100);
            this.textArea.Multiline = true;
            this.textArea.Name = "textArea";
            this.textArea.ReadOnly = true;
            this.textArea.Size = new System.Drawing.Size(489, 324);
            this.textArea.TabIndex = 0;
            this.textArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ETLUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(741, 366);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Himalaya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ETLUserForm";
            this.Text = "ETL Process- \"Beer\" project";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.textPanel.ResumeLayout(false);
            this.textPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.Button transformButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button ETLButton;
        private System.Windows.Forms.Button clearDBbutton;
        private System.Windows.Forms.Button saveToCSVButton;
        private System.Windows.Forms.Panel textPanel;
        private System.Windows.Forms.TextBox textArea;
    }
}