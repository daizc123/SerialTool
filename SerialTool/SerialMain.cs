using System.IO.Ports;
using System.Text;

namespace SerialTool
{
    public partial class SerialMain : Form
    {
        SerialPort serialPort;
        string serialPortName = string.Empty;
        string msg_str = string.Empty;
        List<byte> linebuff = new List<byte>();
        public SerialMain()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int len = serialPort.BytesToRead;//获取可以读取的字节数
            byte[] buff = new byte[len];//创建缓存数据数组
            serialPort.Read(buff, 0, len);//把数据读取到buff数组           
            linebuff.AddRange(buff);
            //如果后缀为\r\n 为结束
            if (buff[buff.Length - 1] == 0x0A)
            {
                msg_str = BitConverter.ToString(linebuff.ToArray()) + "|" + Encoding.Default.GetString(linebuff.ToArray());
                Invoke(() => {
                    rich_text_receive.AppendText("接收:" + msg_str);
                    int begin_index = rich_text_receive.GetFirstCharIndexFromLine(rich_text_receive.Lines.Length - 1);
                    rich_text_receive.Select(begin_index, msg_str.Length);
                    rich_text_receive.SelectionColor = Color.Lime;
                    linebuff.Clear();
                });               
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            String str_send = txt_send.Text;//获取发送文本框里面的数据
            try
            {
                if (str_send.Length > 0)
                {
                    rich_text_receive.AppendText("发送:" + str_send);
                    int begin_index = rich_text_receive.GetFirstCharIndexFromLine(rich_text_receive.Lines.Length - 1);
                    rich_text_receive.Select(begin_index, str_send.Length + 3);
                    rich_text_receive.SelectionColor = Color.Blue;
                    rich_text_receive.AppendText("\r\n");

                    //serialPort.Write(str_send);//串口发送数据
                }
            }
            catch (Exception) { }
        }

        private void SerialMain_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            com_port.Items.AddRange(ports);
            settingDefualt();
        }

        /// <summary>
        /// 设置默认
        /// </summary>
        private void settingDefualt()
        {
            com_hz.Items.AddRange("9600|115200".Split('|'));
            com_validate.Items.AddRange("无校验|奇校验|偶校验".Split('|'));
            com_stop.Items.AddRange("无|1|1.5|2".Split('|'));
            com_hz.Text = "115200";/*默认波特率:115200*/
            com_stop.Text = "1";/*默认停止位:1*/
            com_data.Text = "8";/*默认数据位:8*/
            com_validate.Text = "无校验";/*默认奇偶校验位:无*/

            com_port.Text = string.Empty;
            com_port.SelectedIndex = com_port.Items.Count > 0 ? 0 : -1;
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                try
                {//防止意外错误
                    serialPortName = com_port.Text;
                    if (string.IsNullOrEmpty(serialPortName))
                    {
                        lb_error.Text = "请选择端口号!";
                        return;
                    }
                    serialPort.PortName = serialPortName;//获取comboBox1要打开的串口号                    
                    serialPort.BaudRate = int.Parse(com_hz.Text);//获取comboBox2选择的波特率
                    serialPort.DataBits = int.Parse(com_data.Text);//设置数据位

                    /*设置停止位*/
                    if (com_stop.Text == "无") { serialPort.StopBits = StopBits.None; }
                    else if (com_stop.Text == "1") { serialPort.StopBits = StopBits.One; }
                    else if (com_stop.Text == "1.5") { serialPort.StopBits = StopBits.OnePointFive; }
                    else if (com_stop.Text == "2") { serialPort.StopBits = StopBits.Two; }

                    /*设置奇偶校验*/
                    if (com_validate.Text == "无校验") { serialPort.Parity = Parity.None; }
                    else if (com_validate.Text == "奇校验") { serialPort.Parity = Parity.Odd; }
                    else if (com_validate.Text == "偶校验") { serialPort.Parity = Parity.Even; }

                    serialPort.Open();//打开串口

                    btn_open.Text = "关闭串口";//按钮显示关闭串口
                }
                catch (Exception err)
                {
                    MessageBox.Show("打开失败" + err.ToString(), "提示!");//对话框显示打开失败
                }
            }
            else
            {
                try
                {//防止意外错误
                    serialPort.Close();//关闭串口
                }
                catch (Exception) { }
                btn_open.Text = "打开串口";//按钮显示打开
            }
        }

        protected override void WndProc(ref Message m)
        {
            //设备改变
            if (m.Msg == 0x0219)
            {
                //usb串口拔出
                if (m.WParam.ToInt32() == 0x8004)
                {
                    string[] ports = SerialPort.GetPortNames();//重新获取串口
                    com_port.Items.Clear();
                    com_port.Items.AddRange(ports);
                    //如果拔出的是当前设备则关闭设备
                    if (!ports.Contains(serialPortName) && serialPort.IsOpen)
                    {
                        try
                        {
                            btn_open.Text = "打开串口";
                            com_port.SelectedIndex = com_port.Items.Count > 0 ? 0 : -1;
                            serialPort.Dispose();
                        }
                        catch
                        {

                        }
                    }
                    else if (ports.Contains(serialPortName))
                    {
                        com_port.Text = serialPortName;
                    }
                }
                //usb串口连接上
                else if (m.WParam.ToInt32() == 0x8000)
                {
                    string[] ports = SerialPort.GetPortNames();//重新获取串口
                    com_port.Items.Clear();
                    com_port.Items.AddRange(ports);
                    if (serialPort.IsOpen)
                    {
                        com_port.Text = serialPortName;//显示用户打开的那个串口号
                    }
                    else
                    {
                        com_port.SelectedIndex = com_port.Items.Count > 0 ? 0 : -1;//显示获取的第一个串口号
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            rich_text_receive.Clear();
            rich_text_receive.Text = string.Empty;
        }

        private void com_port_TextChanged(object sender, EventArgs e)
        {
            string com_txt = com_port.Text;
            if (!string.IsNullOrEmpty(com_txt))
            {
                var ports = SerialPort.GetPortNames();
                if (ports.Contains(com_txt))
                {
                    var port = new SerialPort(com_txt);
                    com_hz.Text = port.BaudRate.ToString();
                    com_stop.Text = port.StopBits.ToString();
                    com_data.Text = port.DataBits.ToString();

                    /*设置停止位*/
                    if (serialPort.StopBits == StopBits.None) { com_stop.Text = "无"; }
                    else if (serialPort.StopBits == StopBits.One) { com_stop.Text = "1"; }
                    else if (serialPort.StopBits == StopBits.OnePointFive) { com_stop.Text = "1.5"; }
                    else if (serialPort.StopBits == StopBits.Two) { com_stop.Text = "2"; }

                    /*设置奇偶校验*/
                    if (port.Parity == Parity.None) { com_validate.Text = "无校验"; }
                    else if (port.Parity == Parity.Odd) { com_validate.Text = "奇校验"; }
                    else if (port.Parity == Parity.Even) { com_validate.Text = "偶校验"; }
                }
            }
        }
    }
}