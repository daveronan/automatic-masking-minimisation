namespace DeMaskingLT
{
    partial class Name
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
            this.labelName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTestType = new System.Windows.Forms.Label();
            this.radioButtonTestA = new System.Windows.Forms.RadioButton();
            this.radioButtonTestB = new System.Windows.Forms.RadioButton();
            this.tbInstructions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(216, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(121, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Please enter your name:";
            this.labelName.Visible = false;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(168, 34);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(218, 20);
            this.tbName.TabIndex = 1;
            this.tbName.Visible = false;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(231, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTestType
            // 
            this.labelTestType.AutoSize = true;
            this.labelTestType.Location = new System.Drawing.Point(198, 9);
            this.labelTestType.Name = "labelTestType";
            this.labelTestType.Size = new System.Drawing.Size(139, 13);
            this.labelTestType.TabIndex = 3;
            this.labelTestType.Text = "Please select your test type:";
            // 
            // radioButtonTestA
            // 
            this.radioButtonTestA.AutoSize = true;
            this.radioButtonTestA.Location = new System.Drawing.Point(231, 37);
            this.radioButtonTestA.Name = "radioButtonTestA";
            this.radioButtonTestA.Size = new System.Drawing.Size(32, 17);
            this.radioButtonTestA.TabIndex = 4;
            this.radioButtonTestA.Text = "A";
            this.radioButtonTestA.UseVisualStyleBackColor = true;
            this.radioButtonTestA.CheckedChanged += new System.EventHandler(this.radioButtonTestA_CheckedChanged);
            // 
            // radioButtonTestB
            // 
            this.radioButtonTestB.AutoSize = true;
            this.radioButtonTestB.Location = new System.Drawing.Point(274, 37);
            this.radioButtonTestB.Name = "radioButtonTestB";
            this.radioButtonTestB.Size = new System.Drawing.Size(32, 17);
            this.radioButtonTestB.TabIndex = 4;
            this.radioButtonTestB.Text = "B";
            this.radioButtonTestB.UseVisualStyleBackColor = true;
            this.radioButtonTestB.CheckedChanged += new System.EventHandler(this.radioButtonTestB_CheckedChanged);
            // 
            // tbInstructions
            // 
            this.tbInstructions.BackColor = System.Drawing.Color.White;
            this.tbInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInstructions.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInstructions.Location = new System.Drawing.Point(12, 5);
            this.tbInstructions.Multiline = true;
            this.tbInstructions.Name = "tbInstructions";
            this.tbInstructions.ReadOnly = true;
            this.tbInstructions.ShortcutsEnabled = false;
            this.tbInstructions.Size = new System.Drawing.Size(506, 49);
            this.tbInstructions.TabIndex = 5;
            this.tbInstructions.TabStop = false;
            this.tbInstructions.Text = "Pleas listen to each of the five mixes carefully and rank them according to the g" +
    "iven instruction on the next page.";
            this.tbInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbInstructions.Visible = false;
            // 
            // Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 88);
            this.Controls.Add(this.radioButtonTestB);
            this.Controls.Add(this.radioButtonTestA);
            this.Controls.Add(this.labelTestType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.tbInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Name";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Name_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        public System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTestType;
        public System.Windows.Forms.RadioButton radioButtonTestA;
        public System.Windows.Forms.RadioButton radioButtonTestB;
        private System.Windows.Forms.TextBox tbInstructions;
    }
}