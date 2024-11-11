namespace Prog_3_Project_alpha_v0._1
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_form = new System.Windows.Forms.Panel();
            this.pnl_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.Controls.Add(this.pictureBox1);
            this.pnl_Menu.Controls.Add(this.txt_title);
            this.pnl_Menu.Location = new System.Drawing.Point(3, 1);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(158, 680);
            this.pnl_Menu.TabIndex = 3;
            // 
            // txt_title
            // 
            this.txt_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_title.Location = new System.Drawing.Point(3, 0);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(155, 57);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "𝓼𝓶𝓲𝓵𝓮𝓼";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Prog_3_Project_alpha_v0._1.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(40, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_form
            // 
            this.pnl_form.BackColor = System.Drawing.Color.White;
            this.pnl_form.BackgroundImage = global::Prog_3_Project_alpha_v0._1.Properties.Resources.wire_mesh_teeth;
            this.pnl_form.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_form.Location = new System.Drawing.Point(158, 1);
            this.pnl_form.Name = "pnl_form";
            this.pnl_form.Size = new System.Drawing.Size(805, 681);
            this.pnl_form.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(962, 682);
            this.Controls.Add(this.pnl_Menu);
            this.Controls.Add(this.pnl_form);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Staff_Form_Load);
            this.pnl_Menu.ResumeLayout(false);
            this.pnl_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnl_form;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

