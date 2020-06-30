namespace lab_4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cities = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.distance = new System.Windows.Forms.Label();
            this.calculate = new System.Windows.Forms.Button();
            this.secondCity = new System.Windows.Forms.TextBox();
            this.firstCity = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.cityId = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.point = new System.Windows.Forms.TextBox();
            this.points = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityId)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cities);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список городов, в которые были совершены перевозки";
            // 
            // cities
            // 
            this.cities.AutoSize = true;
            this.cities.Location = new System.Drawing.Point(7, 22);
            this.cities.Name = "cities";
            this.cities.Size = new System.Drawing.Size(0, 17);
            this.cities.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.distance);
            this.groupBox2.Controls.Add(this.calculate);
            this.groupBox2.Controls.Add(this.secondCity);
            this.groupBox2.Controls.Add(this.firstCity);
            this.groupBox2.Location = new System.Drawing.Point(485, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расстояние между перевозками";
            // 
            // distance
            // 
            this.distance.AutoSize = true;
            this.distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distance.ForeColor = System.Drawing.Color.Red;
            this.distance.Location = new System.Drawing.Point(6, 105);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(0, 20);
            this.distance.TabIndex = 3;
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(7, 50);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(290, 29);
            this.calculate.TabIndex = 2;
            this.calculate.Text = "Вычислить";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // secondCity
            // 
            this.secondCity.Location = new System.Drawing.Point(153, 22);
            this.secondCity.Name = "secondCity";
            this.secondCity.Size = new System.Drawing.Size(144, 22);
            this.secondCity.TabIndex = 1;
            // 
            // firstCity
            // 
            this.firstCity.Location = new System.Drawing.Point(7, 22);
            this.firstCity.Name = "firstCity";
            this.firstCity.Size = new System.Drawing.Size(144, 22);
            this.firstCity.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.points);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.result);
            this.groupBox3.Controls.Add(this.cityId);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.add);
            this.groupBox3.Controls.Add(this.point);
            this.groupBox3.Location = new System.Drawing.Point(485, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(303, 263);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Добавить точку";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.union_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(7, 107);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 17);
            this.result.TabIndex = 6;
            // 
            // cityId
            // 
            this.cityId.Location = new System.Drawing.Point(153, 43);
            this.cityId.Name = "cityId";
            this.cityId.Size = new System.Drawing.Size(144, 22);
            this.cityId.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID заказа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Координаты точки";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(7, 71);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(290, 29);
            this.add.TabIndex = 1;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // point
            // 
            this.point.Location = new System.Drawing.Point(7, 43);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(144, 22);
            this.point.TabIndex = 0;
            // 
            // points
            // 
            this.points.AutoSize = true;
            this.points.Location = new System.Drawing.Point(7, 107);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(0, 17);
            this.points.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cityId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label cities;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.TextBox secondCity;
        private System.Windows.Forms.TextBox firstCity;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox point;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.NumericUpDown cityId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label points;
    }
}

