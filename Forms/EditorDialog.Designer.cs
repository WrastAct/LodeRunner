
namespace LodeRunner.Forms
{
    partial class EditorDialog
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
            this.btnBrick = new System.Windows.Forms.Button();
            this.btnGold = new System.Windows.Forms.Button();
            this.btnLadder = new System.Windows.Forms.Button();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrick
            // 
            this.btnBrick.BackgroundImage = global::LodeRunner.Properties.Resources.brick;
            this.btnBrick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrick.Location = new System.Drawing.Point(6, 8);
            this.btnBrick.Name = "btnBrick";
            this.btnBrick.Size = new System.Drawing.Size(63, 62);
            this.btnBrick.TabIndex = 0;
            this.btnBrick.UseVisualStyleBackColor = true;
            this.btnBrick.Click += new System.EventHandler(this.btnBrick_Click);
            // 
            // btnGold
            // 
            this.btnGold.BackgroundImage = global::LodeRunner.Properties.Resources.gold;
            this.btnGold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGold.Location = new System.Drawing.Point(75, 8);
            this.btnGold.Name = "btnGold";
            this.btnGold.Size = new System.Drawing.Size(63, 62);
            this.btnGold.TabIndex = 1;
            this.btnGold.UseVisualStyleBackColor = true;
            this.btnGold.Click += new System.EventHandler(this.btnGold_Click);
            // 
            // btnLadder
            // 
            this.btnLadder.BackgroundImage = global::LodeRunner.Properties.Resources.ladder;
            this.btnLadder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLadder.Location = new System.Drawing.Point(144, 8);
            this.btnLadder.Name = "btnLadder";
            this.btnLadder.Size = new System.Drawing.Size(63, 62);
            this.btnLadder.TabIndex = 2;
            this.btnLadder.UseVisualStyleBackColor = true;
            this.btnLadder.Click += new System.EventHandler(this.btnLadder_Click);
            // 
            // btnEmpty
            // 
            this.btnEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmpty.Location = new System.Drawing.Point(213, 8);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(63, 62);
            this.btnEmpty.TabIndex = 3;
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // EditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 80);
            this.Controls.Add(this.btnEmpty);
            this.Controls.Add(this.btnLadder);
            this.Controls.Add(this.btnGold);
            this.Controls.Add(this.btnBrick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditorDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrick;
        private System.Windows.Forms.Button btnGold;
        private System.Windows.Forms.Button btnLadder;
        private System.Windows.Forms.Button btnEmpty;
    }
}