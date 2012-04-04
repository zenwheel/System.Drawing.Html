namespace Html_Demo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tv = new System.Windows.Forms.TreeView();
            this.sptTreeView = new System.Windows.Forms.Splitter();
            this.rtf = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tmrRepaint = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.HtmlPanel();
            this.htmlToolTip1 = new System.Drawing.Html.HtmlToolTip();
            this.colorPicker1 = new Html_Demo.ColorPicker();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv.HideSelection = false;
            this.tv.Location = new System.Drawing.Point(4, 4);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(126, 220);
            this.tv.TabIndex = 1;
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            // 
            // sptTreeView
            // 
            this.sptTreeView.Location = new System.Drawing.Point(130, 4);
            this.sptTreeView.Name = "sptTreeView";
            this.sptTreeView.Size = new System.Drawing.Size(4, 220);
            this.sptTreeView.TabIndex = 2;
            this.sptTreeView.TabStop = false;
            // 
            // rtf
            // 
            this.rtf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtf.Location = new System.Drawing.Point(134, 62);
            this.rtf.Name = "rtf";
            this.rtf.Size = new System.Drawing.Size(393, 162);
            this.rtf.TabIndex = 3;
            this.rtf.Text = "";
            this.rtf.WordWrap = false;
            this.rtf.TextChanged += new System.EventHandler(this.rtf_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(134, 58);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(393, 4);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // tmrRepaint
            // 
            this.tmrRepaint.Interval = 50;
            this.tmrRepaint.Tick += new System.EventHandler(this.tmrRepaint_Tick);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.AutoScrollMinSize = new System.Drawing.Size(393, 0);
            this.panel.BackColor = System.Drawing.SystemColors.Window;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(134, 4);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel.Size = new System.Drawing.Size(393, 54);
            this.panel.TabIndex = 4;
            this.htmlToolTip1.SetToolTip(this.panel, resources.GetString("panel.ToolTip"));
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // colorPicker1
            // 
            this.colorPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorPicker1.Location = new System.Drawing.Point(4, 103);
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.SelectedColor = System.Drawing.Color.Empty;
            this.colorPicker1.Size = new System.Drawing.Size(211, 121);
            this.colorPicker1.TabIndex = 6;
            this.colorPicker1.Visible = false;
            this.colorPicker1.ColorSelected += new System.EventHandler(this.colorPicker1_ColorSelected);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(531, 228);
            this.Controls.Add(this.colorPicker1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rtf);
            this.Controls.Add(this.sptTreeView);
            this.Controls.Add(this.tv);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "HTML Renderer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Splitter sptTreeView;
        private System.Windows.Forms.RichTextBox rtf;
        private System.Windows.Forms.HtmlPanel panel;
        private System.Windows.Forms.Splitter splitter1;
        private ColorPicker colorPicker1;
        private System.Windows.Forms.Timer tmrRepaint;
        private System.Drawing.Html.HtmlToolTip htmlToolTip1;




    }
}

