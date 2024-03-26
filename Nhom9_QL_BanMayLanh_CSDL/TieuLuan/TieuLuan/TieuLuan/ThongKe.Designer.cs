namespace TieuLuan
{
    partial class ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart_soLuongSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_start = new System.Windows.Forms.ComboBox();
            this.cbo_finish = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_thanhTien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_lamMoi = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.roundButton1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_soLuongSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_thanhTien)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_soLuongSP
            // 
            this.chart_soLuongSP.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart_soLuongSP.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.chart_soLuongSP, 3);
            this.chart_soLuongSP.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_soLuongSP.Legends.Add(legend2);
            this.chart_soLuongSP.Location = new System.Drawing.Point(4, 101);
            this.chart_soLuongSP.Margin = new System.Windows.Forms.Padding(4);
            this.chart_soLuongSP.Name = "chart_soLuongSP";
            this.chart_soLuongSP.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.tableLayoutPanel1.SetRowSpan(this.chart_soLuongSP, 4);
            series2.BackImageTransparentColor = System.Drawing.Color.White;
            series2.BackSecondaryColor = System.Drawing.SystemColors.Control;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "EmptyPointValue=Zero";
            series2.EmptyPointStyle.IsValueShownAsLabel = true;
            series2.EmptyPointStyle.IsVisibleInLegend = false;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.IsVisibleInLegend = false;
            series2.IsXValueIndexed = true;
            series2.LabelAngle = 5;
            series2.Legend = "Legend1";
            series2.Name = "SoLuong";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ShadowColor = System.Drawing.Color.WhiteSmoke;
            series2.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.BlanchedAlmond;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chart_soLuongSP.Series.Add(series2);
            this.chart_soLuongSP.Size = new System.Drawing.Size(414, 256);
            this.chart_soLuongSP.TabIndex = 0;
            this.chart_soLuongSP.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            title2.Name = "Title1";
            title2.Text = "Số lượng sản phẩm còn lại";
            this.chart_soLuongSP.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(178, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 97);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thống kê sản phẩm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(4, 361);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 66);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thời gian cụ thể";
            // 
            // cbo_start
            // 
            this.cbo_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_start.FormattingEnabled = true;
            this.cbo_start.Location = new System.Drawing.Point(4, 431);
            this.cbo_start.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_start.Name = "cbo_start";
            this.cbo_start.Size = new System.Drawing.Size(166, 24);
            this.cbo_start.TabIndex = 5;
            this.cbo_start.SelectedIndexChanged += new System.EventHandler(this.cbo_start_SelectedIndexChanged);
            // 
            // cbo_finish
            // 
            this.cbo_finish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_finish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_finish.FormattingEnabled = true;
            this.cbo_finish.Location = new System.Drawing.Point(252, 431);
            this.cbo_finish.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_finish.Name = "cbo_finish";
            this.cbo_finish.Size = new System.Drawing.Size(166, 24);
            this.cbo_finish.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(178, 427);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 67);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đến";
            // 
            // chart_thanhTien
            // 
            this.chart_thanhTien.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart_thanhTien.ChartAreas.Add(chartArea2);
            this.tableLayoutPanel1.SetColumnSpan(this.chart_thanhTien, 3);
            this.chart_thanhTien.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_thanhTien.Legends.Add(legend1);
            this.chart_thanhTien.Location = new System.Drawing.Point(426, 101);
            this.chart_thanhTien.Margin = new System.Windows.Forms.Padding(4);
            this.chart_thanhTien.Name = "chart_thanhTien";
            this.chart_thanhTien.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.tableLayoutPanel1.SetRowSpan(this.chart_thanhTien, 6);
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "tien";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart_thanhTien.Series.Add(series1);
            this.chart_thanhTien.Size = new System.Drawing.Size(687, 389);
            this.chart_thanhTien.TabIndex = 3;
            this.chart_thanhTien.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            title1.Name = "Title1";
            title1.Text = "Số tiền bán được của từng sản phẩm (Tiền lời)";
            this.chart_thanhTien.Titles.Add(title1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.61041F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.693741F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.61041F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.6104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.2208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.25424F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart_thanhTien, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbo_finish, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbo_start, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btn_lamMoi, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.chart_soLuongSP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_previous, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.roundButton1, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.78609F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.36898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.36898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.36898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.36898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.36898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.36898F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 494);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // btn_lamMoi
            // 
            this.btn_lamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_lamMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_lamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_lamMoi.Location = new System.Drawing.Point(600, 4);
            this.btn_lamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btn_lamMoi.Name = "btn_lamMoi";
            this.btn_lamMoi.Size = new System.Drawing.Size(340, 89);
            this.btn_lamMoi.TabIndex = 1;
            this.btn_lamMoi.Text = "Làm mới";
            this.btn_lamMoi.UseVisualStyleBackColor = true;
            this.btn_lamMoi.Click += new System.EventHandler(this.btn_lamMoi_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_previous.Image = global::TieuLuan.Properties.Resources.Go_back_icon;
            this.btn_previous.Location = new System.Drawing.Point(4, 4);
            this.btn_previous.Margin = new System.Windows.Forms.Padding(4);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(166, 89);
            this.btn_previous.TabIndex = 34;
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // roundButton1
            // 
            this.roundButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundButton1.Image = global::TieuLuan.Properties.Resources.Go_next_icon;
            this.roundButton1.Location = new System.Drawing.Point(948, 4);
            this.roundButton1.Margin = new System.Windows.Forms.Padding(4);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(165, 89);
            this.roundButton1.TabIndex = 35;
            this.roundButton1.UseVisualStyleBackColor = true;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TieuLuan.Properties.Resources.tải_xuống;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1117, 494);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_soLuongSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_thanhTien)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_soLuongSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_start;
        private System.Windows.Forms.ComboBox cbo_finish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_thanhTien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_lamMoi;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Button roundButton1;
    }
}