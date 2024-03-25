namespace 自制简易MODBUS串口助手
{
    partial class MySerialPortHelper
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.serialPortsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRatesComboBox = new System.Windows.Forms.ComboBox();
            this.paritiesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.readAndWriteModelComboBox = new System.Windows.Forms.ComboBox();
            this.lable6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.requestTextBox = new System.Windows.Forms.TextBox();
            this.slaveAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.startAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPortsComboBox
            // 
            this.serialPortsComboBox.FormattingEnabled = true;
            this.serialPortsComboBox.Location = new System.Drawing.Point(24, 108);
            this.serialPortsComboBox.Name = "serialPortsComboBox";
            this.serialPortsComboBox.Size = new System.Drawing.Size(121, 23);
            this.serialPortsComboBox.TabIndex = 0;
            this.serialPortsComboBox.SelectedIndexChanged += new System.EventHandler(this.serialPortsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.12605F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "可选串口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.12605F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(33, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "可选波特率";
            // 
            // baudRatesComboBox
            // 
            this.baudRatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRatesComboBox.FormattingEnabled = true;
            this.baudRatesComboBox.Location = new System.Drawing.Point(24, 169);
            this.baudRatesComboBox.Name = "baudRatesComboBox";
            this.baudRatesComboBox.Size = new System.Drawing.Size(121, 23);
            this.baudRatesComboBox.TabIndex = 3;
            this.baudRatesComboBox.SelectedIndexChanged += new System.EventHandler(this.baudRatesComboBox_SelectedIndexChanged);
            // 
            // paritiesComboBox
            // 
            this.paritiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paritiesComboBox.FormattingEnabled = true;
            this.paritiesComboBox.Location = new System.Drawing.Point(24, 234);
            this.paritiesComboBox.Name = "paritiesComboBox";
            this.paritiesComboBox.Size = new System.Drawing.Size(121, 23);
            this.paritiesComboBox.TabIndex = 4;
            this.paritiesComboBox.SelectedIndexChanged += new System.EventHandler(this.paritiesComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.12605F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(33, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "校验方式";
            // 
            // dataBitsComboBox
            // 
            this.dataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBitsComboBox.FormattingEnabled = true;
            this.dataBitsComboBox.Location = new System.Drawing.Point(24, 303);
            this.dataBitsComboBox.Name = "dataBitsComboBox";
            this.dataBitsComboBox.Size = new System.Drawing.Size(121, 23);
            this.dataBitsComboBox.TabIndex = 6;
            this.dataBitsComboBox.SelectedIndexChanged += new System.EventHandler(this.dataBitsComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.12605F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(33, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据位";
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitsComboBox.FormattingEnabled = true;
            this.stopBitsComboBox.Location = new System.Drawing.Point(24, 366);
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(121, 23);
            this.stopBitsComboBox.TabIndex = 8;
            this.stopBitsComboBox.SelectedIndexChanged += new System.EventHandler(this.stopBitsComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15.12605F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(33, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "停止位";
            // 
            // readAndWriteModelComboBox
            // 
            this.readAndWriteModelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.readAndWriteModelComboBox.FormattingEnabled = true;
            this.readAndWriteModelComboBox.Location = new System.Drawing.Point(251, 20);
            this.readAndWriteModelComboBox.Name = "readAndWriteModelComboBox";
            this.readAndWriteModelComboBox.Size = new System.Drawing.Size(196, 23);
            this.readAndWriteModelComboBox.TabIndex = 10;
            this.readAndWriteModelComboBox.SelectedIndexChanged += new System.EventHandler(this.readAndWriteModelComboBox_SelectedIndexChanged);
            // 
            // lable6
            // 
            this.lable6.AutoSize = true;
            this.lable6.Font = new System.Drawing.Font("宋体", 15.73109F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable6.Location = new System.Drawing.Point(129, 20);
            this.lable6.Name = "lable6";
            this.lable6.Size = new System.Drawing.Size(116, 26);
            this.lable6.TabIndex = 11;
            this.lable6.Text = "读写模式";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.connectBtn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.stopBitsComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataBitsComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.paritiesComboBox);
            this.panel1.Controls.Add(this.baudRatesComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.serialPortsComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 561);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15.12605F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(33, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 25);
            this.label11.TabIndex = 11;
            this.label11.Text = "连接状态";
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.White;
            this.connectBtn.Location = new System.Drawing.Point(24, 453);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(121, 35);
            this.connectBtn.TabIndex = 10;
            this.connectBtn.Text = "未连接";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // requestTextBox
            // 
            this.requestTextBox.Location = new System.Drawing.Point(34, 237);
            this.requestTextBox.Multiline = true;
            this.requestTextBox.Name = "requestTextBox";
            this.requestTextBox.ReadOnly = true;
            this.requestTextBox.Size = new System.Drawing.Size(724, 148);
            this.requestTextBox.TabIndex = 13;
            this.requestTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.requestTextBox_KeyPress);
            this.requestTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.readOrWriteTextBox_KeyUp);
            // 
            // slaveAddress
            // 
            this.slaveAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slaveAddress.Location = new System.Drawing.Point(3, 3);
            this.slaveAddress.Name = "slaveAddress";
            this.slaveAddress.Size = new System.Drawing.Size(239, 25);
            this.slaveAddress.TabIndex = 14;
            this.slaveAddress.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(77, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "站号";
            // 
            // startAddress
            // 
            this.startAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startAddress.Location = new System.Drawing.Point(248, 3);
            this.startAddress.Name = "startAddress";
            this.startAddress.Size = new System.Drawing.Size(239, 25);
            this.startAddress.TabIndex = 16;
            this.startAddress.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(311, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "起始地址";
            // 
            // dataLength
            // 
            this.dataLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLength.Location = new System.Drawing.Point(493, 3);
            this.dataLength.Name = "dataLength";
            this.dataLength.Size = new System.Drawing.Size(222, 25);
            this.dataLength.TabIndex = 18;
            this.dataLength.Text = "8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(520, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 24);
            this.label8.TabIndex = 19;
            this.label8.Text = "数据长度";
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.IndianRed;
            this.startBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startBtn.Font = new System.Drawing.Font("宋体", 21.78151F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startBtn.Location = new System.Drawing.Point(0, 145);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(724, 63);
            this.startBtn.TabIndex = 20;
            this.startBtn.Text = "开始";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "请求窗口";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // responseTextBox
            // 
            this.responseTextBox.Location = new System.Drawing.Point(34, 391);
            this.responseTextBox.Multiline = true;
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.ReadOnly = true;
            this.responseTextBox.Size = new System.Drawing.Size(724, 154);
            this.responseTextBox.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 394);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "响应窗口";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.responseTextBox);
            this.panel2.Controls.Add(this.requestTextBox);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(210, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 561);
            this.panel2.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.startBtn);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(34, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 208);
            this.panel3.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 228F));
            this.tableLayoutPanel1.Controls.Add(this.slaveAddress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataLength, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.startAddress, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 107);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.27103F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(718, 32);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lable6);
            this.panel4.Controls.Add(this.readAndWriteModelComboBox);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(724, 100);
            this.panel4.TabIndex = 22;
            // 
            // MySerialPortHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 579);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MySerialPortHelper";
            this.Text = "简易串口工具   by:SeaChungWayne";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MySerialPortHelper_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox serialPortsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baudRatesComboBox;
        private System.Windows.Forms.ComboBox paritiesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dataBitsComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stopBitsComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox readAndWriteModelComboBox;
        private System.Windows.Forms.Label lable6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox requestTextBox;
        private System.Windows.Forms.TextBox slaveAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox startAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dataLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox responseTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
    }
}

