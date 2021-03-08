
namespace Assign4
{
    partial class Form1
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
            this.Graph = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.XMin = new System.Windows.Forms.NumericUpDown();
            this.YMin = new System.Windows.Forms.NumericUpDown();
            this.XMax = new System.Windows.Forms.NumericUpDown();
            this.XInterval = new System.Windows.Forms.NumericUpDown();
            this.YMax = new System.Windows.Forms.NumericUpDown();
            this.YInterval = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // Graph
            // 
            this.Graph.BackColor = System.Drawing.Color.White;
            this.Graph.Location = new System.Drawing.Point(12, 38);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(800, 800);
            this.Graph.TabIndex = 0;
            this.Graph.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 847);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X-Minimum Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 873);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X-Maximum Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 896);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "X-Interval";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 847);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y-Minimum Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 873);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Y-Maximum Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 896);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y-Interval";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Graphing Field";
            // 
            // XMin
            // 
            this.XMin.DecimalPlaces = 2;
            this.XMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.XMin.Location = new System.Drawing.Point(99, 847);
            this.XMin.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.XMin.Minimum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            -2147483648});
            this.XMin.Name = "XMin";
            this.XMin.Size = new System.Drawing.Size(120, 20);
            this.XMin.TabIndex = 15;
            this.XMin.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.XMin.ValueChanged += new System.EventHandler(this.XMin_ValueChanged);
            // 
            // YMin
            // 
            this.YMin.DecimalPlaces = 2;
            this.YMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.YMin.Location = new System.Drawing.Point(339, 845);
            this.YMin.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.YMin.Minimum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            -2147483648});
            this.YMin.Name = "YMin";
            this.YMin.Size = new System.Drawing.Size(120, 20);
            this.YMin.TabIndex = 16;
            this.YMin.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.YMin.ValueChanged += new System.EventHandler(this.YMin_ValueChanged);
            // 
            // XMax
            // 
            this.XMax.DecimalPlaces = 2;
            this.XMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.XMax.Location = new System.Drawing.Point(99, 871);
            this.XMax.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.XMax.Minimum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            -2147483648});
            this.XMax.Name = "XMax";
            this.XMax.Size = new System.Drawing.Size(120, 20);
            this.XMax.TabIndex = 17;
            this.XMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.XMax.ValueChanged += new System.EventHandler(this.XMax_ValueChanged);
            // 
            // XInterval
            // 
            this.XInterval.DecimalPlaces = 2;
            this.XInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.XInterval.Location = new System.Drawing.Point(99, 894);
            this.XInterval.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.XInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            1114112});
            this.XInterval.Name = "XInterval";
            this.XInterval.Size = new System.Drawing.Size(120, 20);
            this.XInterval.TabIndex = 18;
            this.XInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.XInterval.ValueChanged += new System.EventHandler(this.XInterval_ValueChanged);
            // 
            // YMax
            // 
            this.YMax.DecimalPlaces = 2;
            this.YMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.YMax.Location = new System.Drawing.Point(339, 871);
            this.YMax.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.YMax.Minimum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            -2147483648});
            this.YMax.Name = "YMax";
            this.YMax.Size = new System.Drawing.Size(120, 20);
            this.YMax.TabIndex = 19;
            this.YMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.YMax.ValueChanged += new System.EventHandler(this.YMax_ValueChanged);
            // 
            // YInterval
            // 
            this.YInterval.DecimalPlaces = 2;
            this.YInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.YInterval.Location = new System.Drawing.Point(339, 894);
            this.YInterval.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.YInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            1114112});
            this.YInterval.Name = "YInterval";
            this.YInterval.Size = new System.Drawing.Size(120, 20);
            this.YInterval.TabIndex = 20;
            this.YInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.YInterval.ValueChanged += new System.EventHandler(this.YInterval_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1441, 922);
            this.Controls.Add(this.YInterval);
            this.Controls.Add(this.YMax);
            this.Controls.Add(this.XInterval);
            this.Controls.Add(this.XMax);
            this.Controls.Add(this.YMin);
            this.Controls.Add(this.XMin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Graph);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Graph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown XMin;
        private System.Windows.Forms.NumericUpDown YMin;
        private System.Windows.Forms.NumericUpDown XMax;
        private System.Windows.Forms.NumericUpDown XInterval;
        private System.Windows.Forms.NumericUpDown YMax;
        private System.Windows.Forms.NumericUpDown YInterval;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialog3;
    }
}

