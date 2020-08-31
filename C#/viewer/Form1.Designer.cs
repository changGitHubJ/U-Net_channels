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
            this.btnPrepareAll = new System.Windows.Forms.Button();
            this.btnPrepClass1 = new System.Windows.Forms.Button();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrepClass2 = new System.Windows.Forms.Button();
            this.btnPrepClass3 = new System.Windows.Forms.Button();
            this.btnPrepClass4 = new System.Windows.Forms.Button();
            this.btnPrepClass5 = new System.Windows.Forms.Button();
            this.btnPrepClass6 = new System.Windows.Forms.Button();
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
            this.btnInferAll.Location = new System.Drawing.Point(301, 277);
            this.btnInferAll.Name = "btnInferAll";
            this.btnInferAll.Size = new System.Drawing.Size(82, 28);
            this.btnInferAll.TabIndex = 3;
            this.btnInferAll.Text = "Class all";
            this.btnInferAll.UseVisualStyleBackColor = true;
            this.btnInferAll.Click += new System.EventHandler(this.btnInferAll_Click);
            // 
            // btnInfer1
            // 
            this.btnInfer1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer1.Location = new System.Drawing.Point(301, 209);
            this.btnInfer1.Name = "btnInfer1";
            this.btnInfer1.Size = new System.Drawing.Size(82, 28);
            this.btnInfer1.TabIndex = 4;
            this.btnInfer1.Text = "Class 1";
            this.btnInfer1.UseVisualStyleBackColor = true;
            this.btnInfer1.Click += new System.EventHandler(this.btnInfer1_Click);
            // 
            // btnInfer2
            // 
            this.btnInfer2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer2.Location = new System.Drawing.Point(394, 209);
            this.btnInfer2.Name = "btnInfer2";
            this.btnInfer2.Size = new System.Drawing.Size(82, 28);
            this.btnInfer2.TabIndex = 5;
            this.btnInfer2.Text = "Class 2";
            this.btnInfer2.UseVisualStyleBackColor = true;
            this.btnInfer2.Click += new System.EventHandler(this.btnInfer2_Click);
            // 
            // btnInfer3
            // 
            this.btnInfer3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer3.Location = new System.Drawing.Point(486, 209);
            this.btnInfer3.Name = "btnInfer3";
            this.btnInfer3.Size = new System.Drawing.Size(82, 28);
            this.btnInfer3.TabIndex = 6;
            this.btnInfer3.Text = "Class 3";
            this.btnInfer3.UseVisualStyleBackColor = true;
            this.btnInfer3.Click += new System.EventHandler(this.btnInfer3_Click);
            // 
            // btnInfer5
            // 
            this.btnInfer5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer5.Location = new System.Drawing.Point(394, 243);
            this.btnInfer5.Name = "btnInfer5";
            this.btnInfer5.Size = new System.Drawing.Size(82, 28);
            this.btnInfer5.TabIndex = 7;
            this.btnInfer5.Text = "Class 5";
            this.btnInfer5.UseVisualStyleBackColor = true;
            this.btnInfer5.Click += new System.EventHandler(this.btnInfer5_Click);
            // 
            // btnInfer4
            // 
            this.btnInfer4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer4.Location = new System.Drawing.Point(301, 243);
            this.btnInfer4.Name = "btnInfer4";
            this.btnInfer4.Size = new System.Drawing.Size(82, 28);
            this.btnInfer4.TabIndex = 8;
            this.btnInfer4.Text = "Class 4";
            this.btnInfer4.UseVisualStyleBackColor = true;
            this.btnInfer4.Click += new System.EventHandler(this.btnInfer4_Click);
            // 
            // btnInfer6
            // 
            this.btnInfer6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnInfer6.Location = new System.Drawing.Point(486, 243);
            this.btnInfer6.Name = "btnInfer6";
            this.btnInfer6.Size = new System.Drawing.Size(82, 28);
            this.btnInfer6.TabIndex = 9;
            this.btnInfer6.Text = "Class 6";
            this.btnInfer6.UseVisualStyleBackColor = true;
            this.btnInfer6.Click += new System.EventHandler(this.btnInfer6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(301, 188);
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
            this.listBox1.Size = new System.Drawing.Size(557, 112);
            this.listBox1.TabIndex = 11;
            // 
            // btnPrepareAll
            // 
            this.btnPrepareAll.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnPrepareAll.Location = new System.Drawing.Point(301, 143);
            this.btnPrepareAll.Name = "btnPrepareAll";
            this.btnPrepareAll.Size = new System.Drawing.Size(82, 28);
            this.btnPrepareAll.TabIndex = 12;
            this.btnPrepareAll.Text = "Class All";
            this.btnPrepareAll.UseVisualStyleBackColor = true;
            this.btnPrepareAll.Click += new System.EventHandler(this.btnPrepareAll_Click);
            // 
            // btnPrepClass1
            // 
            this.btnPrepClass1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnPrepClass1.Location = new System.Drawing.Point(301, 75);
            this.btnPrepClass1.Name = "btnPrepClass1";
            this.btnPrepClass1.Size = new System.Drawing.Size(82, 28);
            this.btnPrepClass1.TabIndex = 13;
            this.btnPrepClass1.Text = "Class 1";
            this.btnPrepClass1.UseVisualStyleBackColor = true;
            this.btnPrepClass1.Click += new System.EventHandler(this.btnPrepareOne_Click);
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnLoadModel.Location = new System.Drawing.Point(301, 12);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(175, 28);
            this.btnLoadModel.TabIndex = 14;
            this.btnLoadModel.Text = "Load Model";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(298, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Prepare session";
            // 
            // btnPrepClass2
            // 
            this.btnPrepClass2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnPrepClass2.Location = new System.Drawing.Point(394, 75);
            this.btnPrepClass2.Name = "btnPrepClass2";
            this.btnPrepClass2.Size = new System.Drawing.Size(82, 28);
            this.btnPrepClass2.TabIndex = 16;
            this.btnPrepClass2.Text = "Class 2";
            this.btnPrepClass2.UseVisualStyleBackColor = true;
            this.btnPrepClass2.Click += new System.EventHandler(this.btnPrepClass2_Click);
            // 
            // btnPrepClass3
            // 
            this.btnPrepClass3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnPrepClass3.Location = new System.Drawing.Point(486, 75);
            this.btnPrepClass3.Name = "btnPrepClass3";
            this.btnPrepClass3.Size = new System.Drawing.Size(82, 28);
            this.btnPrepClass3.TabIndex = 17;
            this.btnPrepClass3.Text = "Class 3";
            this.btnPrepClass3.UseVisualStyleBackColor = true;
            this.btnPrepClass3.Click += new System.EventHandler(this.btnPrepClass3_Click);
            // 
            // btnPrepClass4
            // 
            this.btnPrepClass4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnPrepClass4.Location = new System.Drawing.Point(301, 109);
            this.btnPrepClass4.Name = "btnPrepClass4";
            this.btnPrepClass4.Size = new System.Drawing.Size(82, 28);
            this.btnPrepClass4.TabIndex = 18;
            this.btnPrepClass4.Text = "Class 4";
            this.btnPrepClass4.UseVisualStyleBackColor = true;
            this.btnPrepClass4.Click += new System.EventHandler(this.btnPrepClass4_Click);
            // 
            // btnPrepClass5
            // 
            this.btnPrepClass5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnPrepClass5.Location = new System.Drawing.Point(394, 109);
            this.btnPrepClass5.Name = "btnPrepClass5";
            this.btnPrepClass5.Size = new System.Drawing.Size(82, 28);
            this.btnPrepClass5.TabIndex = 19;
            this.btnPrepClass5.Text = "Class 5";
            this.btnPrepClass5.UseVisualStyleBackColor = true;
            this.btnPrepClass5.Click += new System.EventHandler(this.btnPrepClass5_Click);
            // 
            // btnPrepClass6
            // 
            this.btnPrepClass6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnPrepClass6.Location = new System.Drawing.Point(486, 109);
            this.btnPrepClass6.Name = "btnPrepClass6";
            this.btnPrepClass6.Size = new System.Drawing.Size(82, 28);
            this.btnPrepClass6.TabIndex = 20;
            this.btnPrepClass6.Text = "Class 6";
            this.btnPrepClass6.UseVisualStyleBackColor = true;
            this.btnPrepClass6.Click += new System.EventHandler(this.btnPrepClass6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 432);
            this.Controls.Add(this.btnPrepClass6);
            this.Controls.Add(this.btnPrepClass5);
            this.Controls.Add(this.btnPrepClass4);
            this.Controls.Add(this.btnPrepClass3);
            this.Controls.Add(this.btnPrepClass2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoadModel);
            this.Controls.Add(this.btnPrepClass1);
            this.Controls.Add(this.btnPrepareAll);
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
        private System.Windows.Forms.Button btnPrepareAll;
        private System.Windows.Forms.Button btnPrepClass1;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrepClass2;
        private System.Windows.Forms.Button btnPrepClass3;
        private System.Windows.Forms.Button btnPrepClass4;
        private System.Windows.Forms.Button btnPrepClass5;
        private System.Windows.Forms.Button btnPrepClass6;
    }
}

