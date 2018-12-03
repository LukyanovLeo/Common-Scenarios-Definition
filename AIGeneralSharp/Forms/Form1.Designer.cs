namespace AIGeneralSharp
{
    partial class MainForm
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
            this.mainLabel = new System.Windows.Forms.Label();
            this.chooseYourHouseLabel = new System.Windows.Forms.Label();
            this.housesListBox = new System.Windows.Forms.ListBox();
            this.getBuildPlanButton = new System.Windows.Forms.Button();
            this.selectedHouseTextBox = new System.Windows.Forms.TextBox();
            this.getCommonPlanButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainLabel.Location = new System.Drawing.Point(146, 31);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(369, 29);
            this.mainLabel.TabIndex = 4;
            this.mainLabel.Text = "ПОСТРОЙКА ДАЧНЫХ ДОМОВ";
            // 
            // chooseYourHouseLabel
            // 
            this.chooseYourHouseLabel.AutoSize = true;
            this.chooseYourHouseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseYourHouseLabel.Location = new System.Drawing.Point(58, 98);
            this.chooseYourHouseLabel.Name = "chooseYourHouseLabel";
            this.chooseYourHouseLabel.Size = new System.Drawing.Size(193, 24);
            this.chooseYourHouseLabel.TabIndex = 5;
            this.chooseYourHouseLabel.Text = "Выберите тип дома:";
            // 
            // housesListBox
            // 
            this.housesListBox.FormattingEnabled = true;
            this.housesListBox.ItemHeight = 16;
            this.housesListBox.Location = new System.Drawing.Point(62, 147);
            this.housesListBox.Name = "housesListBox";
            this.housesListBox.Size = new System.Drawing.Size(528, 196);
            this.housesListBox.TabIndex = 6;
            this.housesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.housesListBox_DoubleClick);
            // 
            // getBuildPlanButton
            // 
            this.getBuildPlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getBuildPlanButton.Location = new System.Drawing.Point(303, 369);
            this.getBuildPlanButton.Name = "getBuildPlanButton";
            this.getBuildPlanButton.Size = new System.Drawing.Size(287, 54);
            this.getBuildPlanButton.TabIndex = 7;
            this.getBuildPlanButton.Text = "Получить план строительства";
            this.getBuildPlanButton.UseVisualStyleBackColor = true;
            this.getBuildPlanButton.Click += new System.EventHandler(this.getBuildPlanButton_Click);
            // 
            // selectedHouseTextBox
            // 
            this.selectedHouseTextBox.Location = new System.Drawing.Point(62, 385);
            this.selectedHouseTextBox.Name = "selectedHouseTextBox";
            this.selectedHouseTextBox.ReadOnly = true;
            this.selectedHouseTextBox.Size = new System.Drawing.Size(189, 22);
            this.selectedHouseTextBox.TabIndex = 8;
            this.selectedHouseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // getCommonPlanButton
            // 
            this.getCommonPlanButton.Location = new System.Drawing.Point(341, 86);
            this.getCommonPlanButton.Name = "getCommonPlanButton";
            this.getCommonPlanButton.Size = new System.Drawing.Size(249, 36);
            this.getCommonPlanButton.TabIndex = 9;
            this.getCommonPlanButton.Text = "Получить общие пункты плана";
            this.getCommonPlanButton.UseVisualStyleBackColor = true;
            this.getCommonPlanButton.Click += new System.EventHandler(this.getCommonPlanButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 450);
            this.Controls.Add(this.getCommonPlanButton);
            this.Controls.Add(this.selectedHouseTextBox);
            this.Controls.Add(this.getBuildPlanButton);
            this.Controls.Add(this.housesListBox);
            this.Controls.Add(this.chooseYourHouseLabel);
            this.Controls.Add(this.mainLabel);
            this.Name = "MainForm";
            this.Text = "AI General 2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Label chooseYourHouseLabel;
        private System.Windows.Forms.ListBox housesListBox;
        private System.Windows.Forms.Button getBuildPlanButton;
        private System.Windows.Forms.TextBox selectedHouseTextBox;
        private System.Windows.Forms.Button getCommonPlanButton;
    }
}

