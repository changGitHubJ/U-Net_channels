namespace Viewer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInferAll = new System.Windows.Forms.Button();
            this.btnInfer1 = new System.Windows.Forms.Button();
            this.btnInfer2 = new System.Windows.Forms.Button();
            this.btnInfer3 = new System.Windows.Forms.Button();
            this.btnInfer5 = new System.Windows.Forms.Button();
            this.btnInfer4 = new System.Windows.Forms.Button();
            this.btnInfer6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AllowDrop = true;
            this.panel.Controls.Add(this.pictureBox1);
            this.panel.Location = new System.Drawing.Point(11, 26);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(274, 271);
            this.panel.TabIndex = 1;
            this.panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);
            this.panel.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnInferAll
            // 
            this.btnInferAll.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInferAll.Location = new System.Drawing.Point(301, 63);
            this.btnInferAll.Name = "btnInferAll";
            this.btnInferAll.Size = new System.Drawing.Size(179, 49);
            this.btnInferAll.TabIndex = 3;
            this.btnInferAll.Text = "Class all";
            this.btnInferAll.UseVisualStyleBackColor = true;
            this.btnInferAll.Click += new System.EventHandler(this.btnInferAll_Click);
            // 
            // btnInfer1
            // 
            this.btnInfer1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer1.Location = new System.Drawing.Point(301, 118);
            this.btnInfer1.Name = "btnInfer1";
            this.btnInfer1.Size = new System.Drawing.Size(82, 49);
            this.btnInfer1.TabIndex = 4;
            this.btnInfer1.Text = "Class 1";
            this.btnInfer1.UseVisualStyleBackColor = true;
            this.btnInfer1.Click += new System.EventHandler(this.btnInfer1_Click);
            // 
            // btnInfer2
            // 
            this.btnInfer2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer2.Location = new System.Drawing.Point(398, 118);
            this.btnInfer2.Name = "btnInfer2";
            this.btnInfer2.Size = new System.Drawing.Size(82, 49);
            this.btnInfer2.TabIndex = 5;
            this.btnInfer2.Text = "Class 2";
            this.btnInfer2.UseVisualStyleBackColor = true;
            this.btnInfer2.Click += new System.EventHandler(this.btnInfer2_Click);
            // 
            // btnInfer3
            // 
            this.btnInfer3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer3.Location = new System.Drawing.Point(301, 173);
            this.btnInfer3.Name = "btnInfer3";
            this.btnInfer3.Size = new System.Drawing.Size(82, 49);
            this.btnInfer3.TabIndex = 6;
            this.btnInfer3.Text = "Class 3";
            this.btnInfer3.UseVisualStyleBackColor = true;
            this.btnInfer3.Click += new System.EventHandler(this.btnInfer3_Click);
            // 
            // btnInfer5
            // 
            this.btnInfer5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer5.Location = new System.Drawing.Point(301, 228);
            this.btnInfer5.Name = "btnInfer5";
            this.btnInfer5.Size = new System.Drawing.Size(82, 49);
            this.btnInfer5.TabIndex = 7;
            this.btnInfer5.Text = "Class 5";
            this.btnInfer5.UseVisualStyleBackColor = true;
            this.btnInfer5.Click += new System.EventHandler(this.btnInfer5_Click);
            // 
            // btnInfer4
            // 
            this.btnInfer4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer4.Location = new System.Drawing.Point(398, 173);
            this.btnInfer4.Name = "btnInfer4";
            this.btnInfer4.Size = new System.Drawing.Size(82, 49);
            this.btnInfer4.TabIndex = 8;
            this.btnInfer4.Text = "Class 4";
            this.btnInfer4.UseVisualStyleBackColor = true;
            this.btnInfer4.Click += new System.EventHandler(this.btnInfer4_Click);
            // 
            // btnInfer6
            // 
            this.btnInfer6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer6.Location = new System.Drawing.Point(398, 228);
            this.btnInfer6.Name = "btnInfer6";
            this.btnInfer6.Size = new System.Drawing.Size(82, 49);
            this.btnInfer6.TabIndex = 9;
            this.btnInfer6.Text = "Class 6";
            this.btnInfer6.UseVisualStyleBackColor = true;
            this.btnInfer6.Click += new System.EventHandler(this.btnInfer6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(301, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Inference";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(11, 312);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(469, 112);
            this.listBox1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 432);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInfer6);
            this.Controls.Add(this.btnInfer4);
            this.Controls.Add(this.btnInfer5);
            this.Controls.Add(this.btnInfer3);
            this.Controls.Add(this.btnInfer2);
            this.Controls.Add(this.btnInfer1);
            this.Controls.Add(this.btnInferAll);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFromClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInferAll;
        private System.Windows.Forms.Button btnInfer1;
        private System.Windows.Forms.Button btnInfer2;
        private System.Windows.Forms.Button btnInfer3;
        private System.Windows.Forms.Button btnInfer5;
        private System.Windows.Forms.Button btnInfer4;
        private System.Windows.Forms.Button btnInfer6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

