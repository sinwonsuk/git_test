namespace JSONConverter
{
    partial class JSONConverterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.ConvertTypeTab = new System.Windows.Forms.TabControl();
            this.ConvertTypeTabBatch = new System.Windows.Forms.TabPage();
            this.BatchResultText = new System.Windows.Forms.RichTextBox();
            this.BatchCovertButton = new System.Windows.Forms.Button();
            this.OutputPathText = new System.Windows.Forms.TextBox();
            this.OutputPathSelectButton = new System.Windows.Forms.Button();
            this.OriginalPathText = new System.Windows.Forms.TextBox();
            this.OriginalPathSelectButton = new System.Windows.Forms.Button();
            this.ConvertTypeTabSingle = new System.Windows.Forms.TabPage();
            this.SinglePathText = new System.Windows.Forms.TextBox();
            this.SingleCovertButton = new System.Windows.Forms.Button();
            this.SingleResultText = new System.Windows.Forms.RichTextBox();
            this.SinglePathSelectButton = new System.Windows.Forms.Button();
            this.OriginalPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OutputPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SinglePathDialog = new System.Windows.Forms.OpenFileDialog();
            this.ConvertTypeTab.SuspendLayout();
            this.ConvertTypeTabBatch.SuspendLayout();
            this.ConvertTypeTabSingle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertTypeTab
            // 
            this.ConvertTypeTab.Controls.Add(this.ConvertTypeTabBatch);
            this.ConvertTypeTab.Controls.Add(this.ConvertTypeTabSingle);
            this.ConvertTypeTab.Location = new System.Drawing.Point(3, 2);
            this.ConvertTypeTab.Name = "ConvertTypeTab";
            this.ConvertTypeTab.SelectedIndex = 0;
            this.ConvertTypeTab.Size = new System.Drawing.Size(796, 442);
            this.ConvertTypeTab.TabIndex = 0;
            // 
            // ConvertTypeTabBatch
            // 
            this.ConvertTypeTabBatch.Controls.Add(this.BatchResultText);
            this.ConvertTypeTabBatch.Controls.Add(this.BatchCovertButton);
            this.ConvertTypeTabBatch.Controls.Add(this.OutputPathText);
            this.ConvertTypeTabBatch.Controls.Add(this.OutputPathSelectButton);
            this.ConvertTypeTabBatch.Controls.Add(this.OriginalPathText);
            this.ConvertTypeTabBatch.Controls.Add(this.OriginalPathSelectButton);
            this.ConvertTypeTabBatch.Location = new System.Drawing.Point(4, 22);
            this.ConvertTypeTabBatch.Name = "ConvertTypeTabBatch";
            this.ConvertTypeTabBatch.Padding = new System.Windows.Forms.Padding(3);
            this.ConvertTypeTabBatch.Size = new System.Drawing.Size(788, 416);
            this.ConvertTypeTabBatch.TabIndex = 0;
            this.ConvertTypeTabBatch.Text = "일괄변환";
            this.ConvertTypeTabBatch.UseVisualStyleBackColor = true;
            // 
            // BatchResultText
            // 
            this.BatchResultText.Location = new System.Drawing.Point(6, 121);
            this.BatchResultText.Name = "BatchResultText";
            this.BatchResultText.ReadOnly = true;
            this.BatchResultText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.BatchResultText.Size = new System.Drawing.Size(775, 289);
            this.BatchResultText.TabIndex = 6;
            this.BatchResultText.TabStop = false;
            this.BatchResultText.Text = "";
            // 
            // BatchCovertButton
            // 
            this.BatchCovertButton.Location = new System.Drawing.Point(6, 84);
            this.BatchCovertButton.Name = "BatchCovertButton";
            this.BatchCovertButton.Size = new System.Drawing.Size(170, 33);
            this.BatchCovertButton.TabIndex = 4;
            this.BatchCovertButton.Text = "변환시작";
            this.BatchCovertButton.UseVisualStyleBackColor = true;
            this.BatchCovertButton.Click += new System.EventHandler(this.CovertButton_Click);
            // 
            // OutputPathText
            // 
            this.OutputPathText.Location = new System.Drawing.Point(116, 52);
            this.OutputPathText.Name = "OutputPathText";
            this.OutputPathText.Size = new System.Drawing.Size(665, 21);
            this.OutputPathText.TabIndex = 3;
            this.OutputPathText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FolderPath_KeyEvent);
            // 
            // OutputPathSelectButton
            // 
            this.OutputPathSelectButton.Location = new System.Drawing.Point(6, 45);
            this.OutputPathSelectButton.Name = "OutputPathSelectButton";
            this.OutputPathSelectButton.Size = new System.Drawing.Size(104, 33);
            this.OutputPathSelectButton.TabIndex = 2;
            this.OutputPathSelectButton.Text = "출력폴더선택";
            this.OutputPathSelectButton.UseVisualStyleBackColor = true;
            this.OutputPathSelectButton.Click += new System.EventHandler(this.OutputPathSelectButton_Click);
            // 
            // OriginalPathText
            // 
            this.OriginalPathText.Location = new System.Drawing.Point(116, 13);
            this.OriginalPathText.Name = "OriginalPathText";
            this.OriginalPathText.Size = new System.Drawing.Size(665, 21);
            this.OriginalPathText.TabIndex = 1;
            this.OriginalPathText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FolderPath_KeyEvent);
            // 
            // OriginalPathSelectButton
            // 
            this.OriginalPathSelectButton.Location = new System.Drawing.Point(6, 6);
            this.OriginalPathSelectButton.Name = "OriginalPathSelectButton";
            this.OriginalPathSelectButton.Size = new System.Drawing.Size(104, 33);
            this.OriginalPathSelectButton.TabIndex = 0;
            this.OriginalPathSelectButton.Text = "원본폴더선택";
            this.OriginalPathSelectButton.UseVisualStyleBackColor = true;
            this.OriginalPathSelectButton.Click += new System.EventHandler(this.OriginalPathSelectButton_Click);
            // 
            // ConvertTypeTabSingle
            // 
            this.ConvertTypeTabSingle.Controls.Add(this.SinglePathText);
            this.ConvertTypeTabSingle.Controls.Add(this.SingleCovertButton);
            this.ConvertTypeTabSingle.Controls.Add(this.SingleResultText);
            this.ConvertTypeTabSingle.Controls.Add(this.SinglePathSelectButton);
            this.ConvertTypeTabSingle.Location = new System.Drawing.Point(4, 22);
            this.ConvertTypeTabSingle.Name = "ConvertTypeTabSingle";
            this.ConvertTypeTabSingle.Padding = new System.Windows.Forms.Padding(3);
            this.ConvertTypeTabSingle.Size = new System.Drawing.Size(788, 416);
            this.ConvertTypeTabSingle.TabIndex = 1;
            this.ConvertTypeTabSingle.Text = "단일변환";
            this.ConvertTypeTabSingle.UseVisualStyleBackColor = true;
            // 
            // SinglePathText
            // 
            this.SinglePathText.Location = new System.Drawing.Point(116, 13);
            this.SinglePathText.Name = "SinglePathText";
            this.SinglePathText.Size = new System.Drawing.Size(665, 21);
            this.SinglePathText.TabIndex = 3;
            // 
            // SingleCovertButton
            // 
            this.SingleCovertButton.Location = new System.Drawing.Point(6, 45);
            this.SingleCovertButton.Name = "SingleCovertButton";
            this.SingleCovertButton.Size = new System.Drawing.Size(170, 33);
            this.SingleCovertButton.TabIndex = 2;
            this.SingleCovertButton.Text = "변환시작";
            this.SingleCovertButton.UseVisualStyleBackColor = true;
            this.SingleCovertButton.Click += new System.EventHandler(this.SingleCovertButton_Click);
            // 
            // SingleResultText
            // 
            this.SingleResultText.Location = new System.Drawing.Point(6, 84);
            this.SingleResultText.Name = "SingleResultText";
            this.SingleResultText.ReadOnly = true;
            this.SingleResultText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.SingleResultText.Size = new System.Drawing.Size(780, 332);
            this.SingleResultText.TabIndex = 1;
            this.SingleResultText.TabStop = false;
            this.SingleResultText.Text = "";
            // 
            // SinglePathSelectButton
            // 
            this.SinglePathSelectButton.Location = new System.Drawing.Point(6, 6);
            this.SinglePathSelectButton.Name = "SinglePathSelectButton";
            this.SinglePathSelectButton.Size = new System.Drawing.Size(104, 33);
            this.SinglePathSelectButton.TabIndex = 0;
            this.SinglePathSelectButton.Text = "파일선택";
            this.SinglePathSelectButton.UseVisualStyleBackColor = true;
            this.SinglePathSelectButton.Click += new System.EventHandler(this.SinglePathSelectButton_Click);
            // 
            // SinglePathDialog
            // 
            this.SinglePathDialog.FileName = "SinglePathDialog";
            // 
            // JSONConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConvertTypeTab);
            this.Name = "JSONConverterForm";
            this.Text = "JSON 컨버터";
            this.ConvertTypeTab.ResumeLayout(false);
            this.ConvertTypeTabBatch.ResumeLayout(false);
            this.ConvertTypeTabBatch.PerformLayout();
            this.ConvertTypeTabSingle.ResumeLayout(false);
            this.ConvertTypeTabSingle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConvertTypeTab;
        private System.Windows.Forms.TabPage ConvertTypeTabBatch;
        private System.Windows.Forms.TabPage ConvertTypeTabSingle;
        private System.Windows.Forms.Button OriginalPathSelectButton;
        private System.Windows.Forms.TextBox OutputPathText;
        private System.Windows.Forms.Button OutputPathSelectButton;
        private System.Windows.Forms.TextBox OriginalPathText;
        private System.Windows.Forms.Button BatchCovertButton;
        private System.Windows.Forms.FolderBrowserDialog OriginalPathDialog;
        private System.Windows.Forms.FolderBrowserDialog OutputPathDialog;
        private System.Windows.Forms.RichTextBox BatchResultText;
        private System.Windows.Forms.RichTextBox SingleResultText;
        private System.Windows.Forms.Button SinglePathSelectButton;
        private System.Windows.Forms.Button SingleCovertButton;
        private System.Windows.Forms.TextBox SinglePathText;
        private System.Windows.Forms.OpenFileDialog SinglePathDialog;
    }
}

