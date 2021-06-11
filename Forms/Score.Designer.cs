
namespace LodeRunner.Forms
{
    partial class Score
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
            this.textScore = new System.Windows.Forms.TextBox();
            this.numScore = new System.Windows.Forms.TextBox();
            this.textEnter = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textScore
            // 
            this.textScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textScore.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textScore.Location = new System.Drawing.Point(21, 9);
            this.textScore.Name = "textScore";
            this.textScore.ReadOnly = true;
            this.textScore.Size = new System.Drawing.Size(310, 39);
            this.textScore.TabIndex = 0;
            this.textScore.Text = "Your final score is:";
            this.textScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numScore
            // 
            this.numScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numScore.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numScore.Location = new System.Drawing.Point(21, 79);
            this.numScore.Name = "numScore";
            this.numScore.ReadOnly = true;
            this.numScore.Size = new System.Drawing.Size(310, 39);
            this.numScore.TabIndex = 1;
            this.numScore.Text = "0";
            this.numScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textEnter
            // 
            this.textEnter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textEnter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textEnter.Location = new System.Drawing.Point(21, 145);
            this.textEnter.Name = "textEnter";
            this.textEnter.ReadOnly = true;
            this.textEnter.Size = new System.Drawing.Size(310, 39);
            this.textEnter.TabIndex = 2;
            this.textEnter.Text = "Enter your name:";
            this.textEnter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textName.Location = new System.Drawing.Point(21, 197);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(310, 46);
            this.textName.TabIndex = 3;
            this.textName.Text = "Name";
            this.textName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.Location = new System.Drawing.Point(21, 274);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(309, 76);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 369);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textEnter);
            this.Controls.Add(this.numScore);
            this.Controls.Add(this.textScore);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Score";
            this.ShowIcon = false;
            this.Text = "Score";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textScore;
        private System.Windows.Forms.TextBox numScore;
        private System.Windows.Forms.TextBox textEnter;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button btnSubmit;
    }
}