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
            int len = serialPort.BytesToRead;//��ȡ���Զ�ȡ���ֽ���
            byte[] buff = new byte[len];//����������������
            serialPort.Read(buff, 0, len);//�����ݶ�ȡ��buff����           
            linebuff.AddRange(buff);
            //�����׺Ϊ\r\n Ϊ����
            if (buff[buff.Length - 1] == 0x0A)
            {
                msg_str = BitConverter.ToString(linebuff.ToArray()) + "|" + Encoding.Default.GetString(linebuff.ToArray());
                Invoke(() => {
                    rich_text_receive.AppendText("����:" + msg_str);
                    int begin_index = rich_text_receive.GetFirstCharIndexFromLine(rich_text_receive.Lines.Length - 1);
                    rich_text_receive.Select(begin_index, msg_str.Length);
                    rich_text_receive.SelectionColor = Color.Lime;
                    linebuff.Clear();
                });               
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            String str_send = txt_send.Text;//��ȡ�����ı������������
            try
            {
                if (str_send.Length > 0)
                {
                    rich_text_receive.AppendText("����:" + str_send);
                    int begin_index = rich_text_receive.GetFirstCharIndexFromLine(rich_text_receive.Lines.Length - 1);
                    rich_text_receive.Select(begin_index, str_send.Length + 3);
                    rich_text_receive.SelectionColor = Color.Blue;
                    rich_text_receive.AppendText("\r\n");

                    //serialPort.Write(str_send);//���ڷ�������
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
        /// ����Ĭ��
        /// </summary>
        private void settingDefualt()
        {
            com_hz.Items.AddRange("9600|115200".Split('|'));
            com_validate.Items.AddRange("��У��|��У��|żУ��".Split('|'));
            com_stop.Items.AddRange("��|1|1.5|2".Split('|'));
            com_hz.Text = "115200";/*Ĭ�ϲ�����:115200*/
            com_stop.Text = "1";/*Ĭ��ֹͣλ:1*/
            com_data.Text = "8";/*Ĭ������λ:8*/
            com_validate.Text = "��У��";/*Ĭ����żУ��λ:��*/

            com_port.Text = string.Empty;
            com_port.SelectedIndex = com_port.Items.Count > 0 ? 0 : -1;
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                try
                {//��ֹ�������
                    serialPortName = com_port.Text;
                    if (string.IsNullOrEmpty(serialPortName))
                    {
                        lb_error.Text = "��ѡ��˿ں�!";
                        return;
                    }
                    serialPort.PortName = serialPortName;//��ȡcomboBox1Ҫ�򿪵Ĵ��ں�                    
                    serialPort.BaudRate = int.Parse(com_hz.Text);//��ȡcomboBox2ѡ��Ĳ�����
                    serialPort.DataBits = int.Parse(com_data.Text);//��������λ

                    /*����ֹͣλ*/
                    if (com_stop.Text == "��") { serialPort.StopBits = StopBits.None; }
                    else if (com_stop.Text == "1") { serialPort.StopBits = StopBits.One; }
                    else if (com_stop.Text == "1.5") { serialPort.StopBits = StopBits.OnePointFive; }
                    else if (com_stop.Text == "2") { serialPort.StopBits = StopBits.Two; }

                    /*������żУ��*/
                    if (com_validate.Text == "��У��") { serialPort.Parity = Parity.None; }
                    else if (com_validate.Text == "��У��") { serialPort.Parity = Parity.Odd; }
                    else if (com_validate.Text == "żУ��") { serialPort.Parity = Parity.Even; }

                    serialPort.Open();//�򿪴���

                    btn_open.Text = "�رմ���";//��ť��ʾ�رմ���
                }
                catch (Exception err)
                {
                    MessageBox.Show("��ʧ��" + err.ToString(), "��ʾ!");//�Ի�����ʾ��ʧ��
                }
            }
            else
            {
                try
                {//��ֹ�������
                    serialPort.Close();//�رմ���
                }
                catch (Exception) { }
                btn_open.Text = "�򿪴���";//��ť��ʾ��
            }
        }

        protected override void WndProc(ref Message m)
        {
            //�豸�ı�
            if (m.Msg == 0x0219)
            {
                //usb���ڰγ�
                if (m.WParam.ToInt32() == 0x8004)
                {
                    string[] ports = SerialPort.GetPortNames();//���»�ȡ����
                    com_port.Items.Clear();
                    com_port.Items.AddRange(ports);
                    //����γ����ǵ�ǰ�豸��ر��豸
                    if (!ports.Contains(serialPortName) && serialPort.IsOpen)
                    {
                        try
                        {
                            btn_open.Text = "�򿪴���";
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
                //usb����������
                else if (m.WParam.ToInt32() == 0x8000)
                {
                    string[] ports = SerialPort.GetPortNames();//���»�ȡ����
                    com_port.Items.Clear();
                    com_port.Items.AddRange(ports);
                    if (serialPort.IsOpen)
                    {
                        com_port.Text = serialPortName;//��ʾ�û��򿪵��Ǹ����ں�
                    }
                    else
                    {
                        com_port.SelectedIndex = com_port.Items.Count > 0 ? 0 : -1;//��ʾ��ȡ�ĵ�һ�����ں�
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

                    /*����ֹͣλ*/
                    if (serialPort.StopBits == StopBits.None) { com_stop.Text = "��"; }
                    else if (serialPort.StopBits == StopBits.One) { com_stop.Text = "1"; }
                    else if (serialPort.StopBits == StopBits.OnePointFive) { com_stop.Text = "1.5"; }
                    else if (serialPort.StopBits == StopBits.Two) { com_stop.Text = "2"; }

                    /*������żУ��*/
                    if (port.Parity == Parity.None) { com_validate.Text = "��У��"; }
                    else if (port.Parity == Parity.Odd) { com_validate.Text = "��У��"; }
                    else if (port.Parity == Parity.Even) { com_validate.Text = "żУ��"; }
                }
            }
        }
    }
}