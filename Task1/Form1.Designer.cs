namespace Task1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPlusOne = new System.Windows.Forms.Button();
            this.buttonMultiplyByTwo = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelCondition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPlusOne
            // 
            this.buttonPlusOne.Location = new System.Drawing.Point(218, 108);
            this.buttonPlusOne.Name = "buttonPlusOne";
            this.buttonPlusOne.Size = new System.Drawing.Size(75, 23);
            this.buttonPlusOne.TabIndex = 0;
            this.buttonPlusOne.Text = "+1";
            this.buttonPlusOne.UseVisualStyleBackColor = true;
            this.buttonPlusOne.Click += new System.EventHandler(this.buttonPlusOne_Click);
            // 
            // buttonMultiplyByTwo
            // 
            this.buttonMultiplyByTwo.Location = new System.Drawing.Point(218, 207);
            this.buttonMultiplyByTwo.Name = "buttonMultiplyByTwo";
            this.buttonMultiplyByTwo.Size = new System.Drawing.Size(75, 23);
            this.buttonMultiplyByTwo.TabIndex = 1;
            this.buttonMultiplyByTwo.Text = "x2";
            this.buttonMultiplyByTwo.UseVisualStyleBackColor = true;
            this.buttonMultiplyByTwo.Click += new System.EventHandler(this.buttonMultiplyByTwo_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(218, 300);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Сбросить";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(72, 165);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(13, 13);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "0";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(72, 217);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(13, 13);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "0";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(218, 359);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(75, 359);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "Играть";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelCondition
            // 
            this.labelCondition.AutoSize = true;
            this.labelCondition.Location = new System.Drawing.Point(50, 76);
            this.labelCondition.Name = "labelCondition";
            this.labelCondition.Size = new System.Drawing.Size(0, 13);
            this.labelCondition.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 450);
            this.Controls.Add(this.labelCondition);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonMultiplyByTwo);
            this.Controls.Add(this.buttonPlusOne);
            this.Name = "Form1";
            this.Text = "Удвоитель";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlusOne;
        private System.Windows.Forms.Button buttonMultiplyByTwo;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelCondition;
    }
}

