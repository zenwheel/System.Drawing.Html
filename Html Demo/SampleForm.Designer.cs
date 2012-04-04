namespace Html_Demo
{
    partial class SampleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.htmlLabel1 = new System.Windows.Forms.HtmlLabel();
            this.pGrid = new System.Windows.Forms.PropertyGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.htmlPanel1 = new System.Windows.Forms.HtmlPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.htmlToolTip1 = new System.Drawing.Html.HtmlToolTip();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HtmlLabel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.htmlLabel1);
            this.panel1.Location = new System.Drawing.Point(15, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 100);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(115, 23);
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.htmlLabel1.Location = new System.Drawing.Point(15, 36);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(115, 23);
            this.htmlLabel1.TabIndex = 0;
            this.htmlLabel1.Text = "This is an <b>HtmlLabel</b>";
            this.htmlLabel1.Click += new System.EventHandler(this.htmlLabel1_Click);
            // 
            // pGrid
            // 
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.pGrid.Location = new System.Drawing.Point(355, 0);
            this.pGrid.Name = "pGrid";
            this.pGrid.Size = new System.Drawing.Size(209, 397);
            this.pGrid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "HtmlPanel";
            // 
            // htmlPanel1
            // 
            this.htmlPanel1.AutoScroll = true;
            this.htmlPanel1.AutoScrollMinSize = new System.Drawing.Size(311, 36);
            this.htmlPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlPanel1.Location = new System.Drawing.Point(15, 155);
            this.htmlPanel1.Name = "htmlPanel1";
            this.htmlPanel1.Size = new System.Drawing.Size(311, 125);
            this.htmlPanel1.TabIndex = 4;
            this.htmlPanel1.Text = "This is an HtmlPanel, click me to change my <code>Text</code> property";
            this.htmlPanel1.Click += new System.EventHandler(this.htmlPanel1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Click me to change tooltip";
            this.htmlToolTip1.SetToolTip(this.button1, "When you click this button, this tooltip will be replaced for the text of the fir" +
                    "st <b>HtmlLabel</b>");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "HtmlToolTip";
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 397);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.htmlPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pGrid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SampleForm";
            this.Text = "Sample Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HtmlLabel htmlLabel1;
        private System.Windows.Forms.PropertyGrid pGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HtmlPanel htmlPanel1;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Label label3;
    }
}