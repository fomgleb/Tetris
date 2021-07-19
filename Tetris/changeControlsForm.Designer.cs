namespace Tetris
{
    partial class ChangeControlsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rightTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rotateTextBox = new System.Windows.Forms.TextBox();
            this.downTextBox = new System.Windows.Forms.TextBox();
            this.leftTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 59);
            this.label1.TabIndex = 4;
            this.label1.Text = "Left";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 59);
            this.label2.TabIndex = 5;
            this.label2.Text = "Right";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 59);
            this.label3.TabIndex = 6;
            this.label3.Text = "Down";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 62);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rotate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightTextBox
            // 
            this.rightTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightTextBox.Location = new System.Drawing.Point(238, 19);
            this.rightTextBox.Margin = new System.Windows.Forms.Padding(10, 18, 10, 10);
            this.rightTextBox.Name = "rightTextBox";
            this.rightTextBox.ReadOnly = true;
            this.rightTextBox.Size = new System.Drawing.Size(207, 31);
            this.rightTextBox.TabIndex = 9;
            this.rightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rightTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyboard_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rotateTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.downTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.leftTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rightTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 268);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // rotateTextBox
            // 
            this.rotateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rotateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateTextBox.Location = new System.Drawing.Point(238, 217);
            this.rotateTextBox.Margin = new System.Windows.Forms.Padding(10, 18, 10, 10);
            this.rotateTextBox.Name = "rotateTextBox";
            this.rotateTextBox.ReadOnly = true;
            this.rotateTextBox.Size = new System.Drawing.Size(207, 31);
            this.rotateTextBox.TabIndex = 12;
            this.rotateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rotateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyboard_KeyDown);
            // 
            // downTextBox
            // 
            this.downTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downTextBox.Location = new System.Drawing.Point(238, 151);
            this.downTextBox.Margin = new System.Windows.Forms.Padding(10, 18, 10, 10);
            this.downTextBox.Name = "downTextBox";
            this.downTextBox.ReadOnly = true;
            this.downTextBox.Size = new System.Drawing.Size(207, 31);
            this.downTextBox.TabIndex = 11;
            this.downTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.downTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyboard_KeyDown);
            // 
            // leftTextBox
            // 
            this.leftTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftTextBox.Location = new System.Drawing.Point(238, 85);
            this.leftTextBox.Margin = new System.Windows.Forms.Padding(10, 18, 10, 10);
            this.leftTextBox.Name = "leftTextBox";
            this.leftTextBox.ReadOnly = true;
            this.leftTextBox.Size = new System.Drawing.Size(207, 31);
            this.leftTextBox.TabIndex = 10;
            this.leftTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.leftTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyboard_KeyDown);
            // 
            // ChangeControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 292);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeControlsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change controls";
            this.Load += new System.EventHandler(this.ChangeControlsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rightTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox rotateTextBox;
        private System.Windows.Forms.TextBox downTextBox;
        private System.Windows.Forms.TextBox leftTextBox;
    }
}