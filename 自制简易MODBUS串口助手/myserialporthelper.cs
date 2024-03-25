using Modbus.Data;
using Modbus.Device;
using Modbus.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace 自制简易MODBUS串口助手
{
    /// <summary>
    /// 助手主体
    /// </summary>
    public partial class MySerialPortHelper : Form
    {
        public MySerialPortHelper()
        {
            InitializeComponent();
        }
        //serialport串口
        private SerialPort serialPort;
        //NMODBUS
        private ModbusMaster modbusMaster;
        /// <summary>
        /// 窗口加载事件处理，获取设备所有串口以及加载各种可选参数。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //实例化串口
            serialPort = new SerialPort();
            //获取设备所有的串口名
            serialPortsComboBox.Items.AddRange(SerialPort.GetPortNames());
            //可选波特率
            baudRatesComboBox.Items.AddRange(new string[] { "9600", "19200" });
            //可选校验位
            paritiesComboBox.Items.AddRange(new string[] { "None", "Odd", "Even", "Mark", "Space" });
            //可选数据位
            dataBitsComboBox.Items.AddRange(new string[] { "5", "6", "7", "8" });
            //可选停止位
            stopBitsComboBox.Items.AddRange(new string[] { "1", "1.5", "2" });
            //可选模式
            readAndWriteModelComboBox.Items.AddRange(new string[] {
                "读取输出线圈",
                "读取离散输入",
                "读取保持型寄存器",
                "读取输入寄存器",
                "写入单个线圈",
                "写入多个线圈",
                "写入单个寄存器",
                "写入多个寄存器"
            });
            //默认值波特率:9600
            baudRatesComboBox.SelectedIndex = 0;
            //默认校验位Odd奇校验
            paritiesComboBox.SelectedIndex = 1;
            //默认数据位 8
            dataBitsComboBox.SelectedIndex = 3;
            //默认停止位 1
            stopBitsComboBox.SelectedIndex = 0;
            //默认模式为读取输出线圈
            readAndWriteModelComboBox.SelectedIndex = 0;


        }
        /// <summary>
        /// 获取校验位
        /// </summary>
        /// <returns></returns>
        private Parity GetParity()
        {
            string selectedItem = paritiesComboBox.SelectedItem.ToString();
            if (selectedItem == "None")
                return Parity.None;
            if (selectedItem == "Odd")
                return Parity.Odd;
            if (selectedItem == "Even")
                return Parity.Even;
            if (selectedItem == "Mark")
                return Parity.Mark;
            if (selectedItem == "Space")
                return Parity.Space;
            return Parity.None;
        }
        /// <summary>
        /// 获取停止位
        /// </summary>
        /// <returns></returns>
        private StopBits GetStopBits()
        {
            int index = stopBitsComboBox.SelectedIndex;
            switch (index)
            {
                case 0:
                    return StopBits.One;
                case 1:
                    return StopBits.OnePointFive;
                case 2:
                    return StopBits.Two;
                default:
                    return StopBits.None;
            }
        }
        /// <summary>
        /// 点击开始，根据选择模式执行对应方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, EventArgs e)
        {
            //执行之前判断是否打开串口
           
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("先连接");
                return;
            }

            //清空响应窗口
            responseTextBox.Text = "";

            try
            {
                //根据所选模式执行相应方法
                switch (readAndWriteModelComboBox.SelectedItem.ToString())
                {
                    case "读取输出线圈":
                        ReadCoils(0x01, (byte)Convert.ToUInt16(slaveAddress.Text), (ushort)Convert.ToUInt16(startAddress.Text),
                            GetCounts());
                        break;
                    case "读取离散输入":
                        ReadCoils(0x02, (byte)Convert.ToUInt16(slaveAddress.Text), (ushort)Convert.ToUInt16(startAddress.Text),
                            GetCounts());
                        break;
                    case "读取保持型寄存器":
                        ReadRegisters(0x03, (byte)Convert.ToUInt16(slaveAddress.Text), (ushort)Convert.ToUInt16(startAddress.Text), GetCounts());
                        break;
                    case "读取输入寄存器":
                        ReadRegisters(0x04, (byte)Convert.ToUInt16(slaveAddress.Text), (ushort)Convert.ToUInt16(startAddress.Text), GetCounts());
                        break;
                    case "写入单个线圈":
                        WriteSingleCoil((byte)Convert.ToUInt16(slaveAddress.Text), (byte)Convert.ToUInt16(startAddress.Text), (bool)GetDataToWrite());
                        break;
                    case "写入单个寄存器":
                        WriteSingleRegister((byte)Convert.ToUInt16(slaveAddress.Text), (byte)Convert.ToUInt16(startAddress.Text), (ushort)GetDataToWrite());
                        break;
                    case "写入多个线圈":
                        WriteMultipleCoil((byte)Convert.ToUInt16(slaveAddress.Text), (byte)Convert.ToUInt16(startAddress.Text), (List<bool>)GetDataToWrite());
                        break;
                    case "写入多个寄存器":
                        WriteMultipleRegisters((byte)Convert.ToUInt16(slaveAddress.Text), (byte)Convert.ToUInt16(startAddress.Text), (List<ushort>)GetDataToWrite());
                        break;
                }

            }
            catch(Exception) {
                
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// 读取模式下，把要读的数据内容打印到响应窗口方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="numberOfPoints"></param>
        private void SetResponseComboBox<T>(ICollection<T> value, ushort numberOfPoints)
        {
            int count = 0;
            foreach (var item in value)
            {
                if (count == numberOfPoints)
                    break;
                responseTextBox.AppendText(item.ToString() + " ");
                count++;
            }
        }
        /// <summary>
        /// 写入模式下，把MODBUS响应报文打印到响应窗口的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="numberOfPoints"></param>
        /// <param name="bytes"></param>
        private void SetResponseComboBox(byte[] ProtocolDataUnit)
        {
            foreach (var item in ProtocolDataUnit)
            {
                responseTextBox.AppendText(item.ToString("X2") + " ");
            }
        }

        /// <summary>
        /// 读取输入输出线圈模式的所用方法。
        /// </summary>
        /// <param name="functionCode"></param>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="numberOfPoints"></param>
        private void ReadCoils(byte functionCode, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            
            try
            {
                //发送请求报文
                ReadCoilsInputsRequest readCoilsReq = new ReadCoilsInputsRequest(functionCode, slaveAddress,
                    startAddress, numberOfPoints);
                //获取响应报文
                var readCoilsRes = modbusMaster.ExecuteCustomMessage<ReadCoilsInputsResponse>(readCoilsReq);

                //打印到响应窗口
                SetResponseComboBox(readCoilsRes.Data, numberOfPoints);
            }
            catch (Exception e)
            {
                MessageBox.Show("请检查各项参数是否正确\r\n" + e.Message);
            }

        }

        /// <summary>
        /// 读取保持型和输入寄存器的模式所用方法
        /// </summary>
        /// <param name="functionCode"></param>
        /// <param name="slaveAddress"></param>
        /// <param name="startAdress"></param>
        /// <param name="numberOfPoints"></param>
        private void ReadRegisters(byte functionCode, byte slaveAddress, ushort startAdress, ushort numberOfPoints)
        {

            try
            {  //构造读取寄存器的请求报文
                ReadHoldingInputRegistersRequest readHoldingInputRegistersReq = new ReadHoldingInputRegistersRequest(functionCode, slaveAddress, startAdress, numberOfPoints);

                //获取响应报文
                var readRegisterRes = modbusMaster.ExecuteCustomMessage<ReadHoldingInputRegistersResponse>(readHoldingInputRegistersReq);

                SetResponseComboBox(readRegisterRes.Data, numberOfPoints);
            }
            catch (Exception e)
            {
                MessageBox.Show("请检查各项参数是否正确\r\n" + e.Message);
            }


        }

        /// <summary>
        /// 写入单个线圈所用方法
        /// </summary>
        private void WriteSingleCoil(byte slaveAddress, byte startAddress, bool dataToWrite)
        {
            try
            {
                //设置请求报文
                WriteSingleCoilRequestResponse writeSingleCoilRequest = new WriteSingleCoilRequestResponse(slaveAddress, startAddress, dataToWrite);
                
                //获取响应报文
                var writeSingleCoilResponse = modbusMaster.ExecuteCustomMessage<WriteSingleCoilRequestResponse>(writeSingleCoilRequest);

                //打印到响应窗口
                SetResponseComboBox(writeSingleCoilResponse.ProtocolDataUnit);
            }
            catch (Exception e)
            {
                MessageBox.Show("请检查各项参数是否正确\r\n" + e.Message);
            }


        }
        /// <summary>
        /// 写入单个寄存器
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        private void WriteSingleRegister(byte slaveAddress, byte startAddress, ushort dataToWrite)
        {
            try
            {
                //设置请求报文
                WriteSingleRegisterRequestResponse writeSingleRegisterRequest = new WriteSingleRegisterRequestResponse(slaveAddress, startAddress, dataToWrite);
                //获取响应报文
                var writeSingleRegisterResponse = modbusMaster.ExecuteCustomMessage<WriteSingleRegisterRequestResponse>(writeSingleRegisterRequest);
                //将响应报文打印到响应窗口
                SetResponseComboBox(writeSingleRegisterResponse.ProtocolDataUnit);
            }
            catch (Exception e)
            {
                MessageBox.Show("请检查各项参数是否正确\r\n" + e.Message);
            }

        }
        /// <summary>
        /// 写多个线圈所用的方法
        /// </summary>
        private void WriteMultipleCoil(byte slaveAddress, ushort startAddress, List<bool> listBoolsDataToWrite)
        {
            try
            {
                //获取要写入的值
                DiscreteCollection dataToWrite = new DiscreteCollection(listBoolsDataToWrite);
                //设置请求报文
                WriteMultipleCoilsRequest writeMultipleCoilsRequest = new WriteMultipleCoilsRequest(slaveAddress, startAddress, dataToWrite);

                //获得响应报文
                var writeMultipleCoilsResponse = modbusMaster.ExecuteCustomMessage<WriteMultipleCoilsResponse>(writeMultipleCoilsRequest);
                //把响应报文打印到响应窗口
                SetResponseComboBox(writeMultipleCoilsResponse.ProtocolDataUnit);
            }
            catch (Exception e)
            {
                MessageBox.Show("请检查各项参数是否正确\r\n" + e.Message);
            }


        }
        /// <summary>
        /// 写入多个寄存器所用方法
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="startAddress"></param>
        /// <param name="listUshortsDataToWrite"></param>
        private void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, List<ushort> listUshortsDataToWrite)
        {
            try
            {
                //将要写入的数据进行包装
                RegisterCollection dataToWrite = new RegisterCollection(listUshortsDataToWrite);
                //设置请求报文
                WriteMultipleRegistersRequest writeMultipleRegistersRequest = new WriteMultipleRegistersRequest(slaveAddress, startAddress, dataToWrite);

                //获取响应报文
                WriteMultipleRegistersResponse writeMultipleRegistersResponse = modbusMaster.ExecuteCustomMessage<WriteMultipleRegistersResponse>(writeMultipleRegistersRequest);

                //将响应报文打印到响应窗口
                SetResponseComboBox(writeMultipleRegistersResponse.ProtocolDataUnit);
            }
            catch (Exception e)
            {
                MessageBox.Show("请检查各项参数是否正确\r\n" + e.Message);
            }


        }

        /// <summary>
        /// 写入模式下，获取要写入的数据
        /// </summary>
        private Object GetDataToWrite()
        {
            try
            {
                //写入单线圈模式
                //只接受0或1
                if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入单个线圈")
                {

                    ushort singleCoilState = Convert.ToUInt16(requestTextBox.Text);
                    if (singleCoilState != 0)
                        return true;
                    else
                        return false;
                }
                //写入单寄存器模式
                if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入单个寄存器")
                {
                    return Convert.ToUInt16(requestTextBox.Text);

                }
                //写入多个线圈模式
                if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入多个线圈")
                {
                    //获取请求窗口中的文本
                    string text = requestTextBox.Text;
                    //先出去首尾空白符，再以空格为分隔符，如果是“空格空格空格”的多个空格连起来，也不会返回空字符串数组元素。
                    string[] stringArrayOfZeroAndOne =
                       GetStringsWithNoBlankCharacter(text);


                    //创建动态bool数组
                    List<bool> boolsOfDataToWrite = new List<bool>();
                    //将字符串数组转换并添加到bool数组
                    foreach (string item in stringArrayOfZeroAndOne)
                    {
                        boolsOfDataToWrite.Add(Convert.ToBoolean(Convert.ToUInt16(item)));
                    }
                    return boolsOfDataToWrite;
                }
                //写入多个寄存器模式
                if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入多个寄存器")
                {
                    //获取请求窗口中的文本
                    string text = requestTextBox.Text;
                    //先出去首尾空白符，再以空格为分隔符，如果是“空格空格空格”的多个空格连起来，也不会返回空字符串数组元素。
                    string[] stringArrayOfDataToWrite =
                       GetStringsWithNoBlankCharacter(text);

                    List<ushort> listUshortsDataToWrite = new List<ushort>();
                    foreach (string item in stringArrayOfDataToWrite)
                    {
                        listUshortsDataToWrite.Add(Convert.ToUInt16(item));
                    }
                    return listUshortsDataToWrite;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("输入数据格式非法，请重新输入\r\n" + e.Message);
            }


            return null;
        }
        /// <summary>
        /// 以空格和制表符分隔字符串数组
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string[] GetStringsWithNoBlankCharacter(string text)
        {
            //先出去首尾空白符，再以空格为分隔符，如果是“空格空格空格”的多个空格连起来，也不会返回空字符串数组元素。
            return text.
                    Trim().
                    Split(new char[] { ' ', (char)9 }, StringSplitOptions.RemoveEmptyEntries);

        }

        /// <summary>
        /// 在写入模式中，获取请求窗口中的数据个数,以空格为分隔符
        /// 或者在读取模式下直接获取在dataLengh的文本框中的数据长度
        /// </summary>
        /// <returns></returns>
        private ushort GetCounts()
        {
            //如果是读取模式，则直接返回dataLengh文本框中的数字
            if (readAndWriteModelComboBox.SelectedIndex <= 3)
            {
                return Convert.ToUInt16(dataLength.Text);
            }

            ///如果是写入模式，则要计算数据长度
            //获取请求窗口中的文本
            string text = requestTextBox.Text;

            //如果是“空格空格空格”的多个空格连起来，也不会返回空字符串数组元素。
            string[] strings = GetStringsWithNoBlankCharacter(text);

            return (ushort)strings.Length;
        }


        /// <summary>
        /// 每次按键都将计算请求窗口中的数据长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readOrWriteTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            dataLength.Text = GetCounts().ToString();
        }

        /// <summary>
        /// 模式下拉框的改动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readAndWriteModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //切换模式自动清空报文窗口
            requestTextBox.Text = "";

            //如果模式是读取输入输出线圈,则请求窗口只读，datalengh可写
            if (readAndWriteModelComboBox.SelectedIndex <= 3)
            {
                dataLength.ReadOnly = false;
                requestTextBox.ReadOnly = true;
            }
            //如果是写入，则请求窗口可写，datalengh只读
            else
            {
                //如果是单写入线圈或者寄存器，则数据长度为1
                if (readAndWriteModelComboBox.SelectedIndex == 4 ||
                   readAndWriteModelComboBox.SelectedIndex == 5)
                    dataLength.Text = 1.ToString();

                requestTextBox.ReadOnly = false;
                dataLength.ReadOnly = true;
            }


        }
        /// <summary>
        /// 根据所选写入模式限制输入数据类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void requestTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果是写入单个线圈，则只能输入一个整数0或1
            if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入单个线圈")
            {
                //只接受0或1或者退格
                if (e.KeyChar == '0' || e.KeyChar == '1' || e.KeyChar == 8)
                    e.Handled = false;
                else
                    e.Handled = true;
                //只能输入一个字符，且最新字符可以更新。 
                if (GetCounts() >= 1)
                {
                    requestTextBox.Text = requestTextBox.Text.Remove(0);
                }

            }
            //如果是写入单个寄存器
            if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入单个寄存器")
            {
                //只接受数字或者退格
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            //如果写入多个线圈，要以空格分开0和1
            if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入多个线圈")
            {
                //只接受0或1或者退格，而且按下后自动添加空格
                if (e.KeyChar == '0' || e.KeyChar == '1')
                {
                    requestTextBox.Text += " ";
                    requestTextBox.Select(requestTextBox.TextLength, 0);
                    e.Handled = false;
                }
                else if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else
                    e.Handled = true;
            }
            //如果写入多个寄存器
            if (readAndWriteModelComboBox.SelectedItem.ToString() == "写入多个寄存器")
            {
                //只接受数字、退格、空格
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8 || e.KeyChar == 32)
                {

                    e.Handled = false;
                }
                else
                    e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        ///  打开或者关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectBtn_Click(object sender, EventArgs e)
        {

            //打开串口或者关闭串口
            try
            {
                if (!serialPort.IsOpen)
                {
                    //设定串口参数
                   
                    //选择串口
                    serialPort.PortName = serialPortsComboBox.SelectedItem.ToString();
                    //选择波特率
                    serialPort.BaudRate = Convert.ToInt32(baudRatesComboBox.SelectedItem);
                    //选择校验
                    serialPort.Parity = GetParity();
                    //选择数据位
                    serialPort.DataBits = Convert.ToInt32(dataBitsComboBox.SelectedItem);
                    //选择停止位
                    serialPort.StopBits = GetStopBits();

                    //实例化ModbusMaster
                    modbusMaster = ModbusSerialMaster.CreateRtu(serialPort);
                    //设置响应报文超时时间
                    modbusMaster.Transport.ReadTimeout = 1000;

                    //打开串口
                    serialPort.Open();
                    MessageBox.Show("成功连接");
                    connectBtn.Text = "已连接";
                }
                else
                {
                    connectBtn.Text = "未连接";
                    serialPort.Close();
                }
                    
            }
            catch (Exception)
            {
                MessageBox.Show("打开连接失败"+e.ToString());
            }
           
        }
        /// <summary>
        /// 切换串口时，自动断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPortsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                connectBtn.Text = "未连接";
                serialPort.Close();
            }
        }

        /// <summary>
        ///  关闭窗口时关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MySerialPortHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }
        /// <summary>
        /// 切换波特率时关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baudRatesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                connectBtn.Text = "未连接";
                serialPort.Close();
            }
        }
        /// <summary>
        /// 切换校验位时关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paritiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                connectBtn.Text = "未连接";
                serialPort.Close();
            }
        }
        /// <summary>
        /// 切换数据位时关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataBitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                connectBtn.Text = "未连接";
                serialPort.Close();
            }
        }
        /// <summary>
        /// 切换停止位时关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopBitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                connectBtn.Text = "未连接";
                serialPort.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
