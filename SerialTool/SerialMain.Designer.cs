namespace SerialTool
{
    partial class SerialMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            split_top = new SplitContainer();
            rich_text_receive = new RichTextBox();
            group_setting = new GroupBox();
            lb_error = new Label();
            btn_clean = new Button();
            btn_open = new Button();
            com_validate = new ComboBox();
            com_data = new ComboBox();
            com_stop = new ComboBox();
            com_hz = new ComboBox();
            com_port = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel_bottom = new Panel();
            group_send = new GroupBox();
            btn_send = new Button();
            txt_send = new TextBox();
            ((System.ComponentModel.ISupportInitialize)split_top).BeginInit();
            split_top.Panel1.SuspendLayout();
            split_top.Panel2.SuspendLayout();
            split_top.SuspendLayout();
            group_setting.SuspendLayout();
            panel_bottom.SuspendLayout();
            group_send.SuspendLayout();
            SuspendLayout();
            // 
            // split_top
            // 
            split_top.Dock = DockStyle.Top;
            split_top.Location = new Point(0, 0);
            split_top.Name = "split_top";
            // 
            // split_top.Panel1
            // 
            split_top.Panel1.Controls.Add(rich_text_receive);
            split_top.Panel1.Padding = new Padding(5);
            // 
            // split_top.Panel2
            // 
            split_top.Panel2.Controls.Add(group_setting);
            split_top.Panel2.Padding = new Padding(5);
            split_top.Size = new Size(750, 319);
            split_top.SplitterDistance = 505;
            split_top.TabIndex = 1;
            // 
            // rich_text_receive
            // 
            rich_text_receive.BackColor = Color.FromArgb(64, 64, 64);
            rich_text_receive.DetectUrls = false;
            rich_text_receive.Dock = DockStyle.Fill;
            rich_text_receive.ForeColor = Color.Lime;
            rich_text_receive.Location = new Point(5, 5);
            rich_text_receive.Margin = new Padding(5);
            rich_text_receive.Name = "rich_text_receive";
            rich_text_receive.ReadOnly = true;
            rich_text_receive.Size = new Size(495, 309);
            rich_text_receive.TabIndex = 0;
            rich_text_receive.Text = "";
            // 
            // group_setting
            // 
            group_setting.Controls.Add(lb_error);
            group_setting.Controls.Add(btn_clean);
            group_setting.Controls.Add(btn_open);
            group_setting.Controls.Add(com_validate);
            group_setting.Controls.Add(com_data);
            group_setting.Controls.Add(com_stop);
            group_setting.Controls.Add(com_hz);
            group_setting.Controls.Add(com_port);
            group_setting.Controls.Add(label6);
            group_setting.Controls.Add(label5);
            group_setting.Controls.Add(label4);
            group_setting.Controls.Add(label3);
            group_setting.Controls.Add(label2);
            group_setting.Controls.Add(label1);
            group_setting.Dock = DockStyle.Fill;
            group_setting.Location = new Point(5, 5);
            group_setting.Name = "group_setting";
            group_setting.Size = new Size(231, 309);
            group_setting.TabIndex = 0;
            group_setting.TabStop = false;
            group_setting.Text = "串口设置";
            // 
            // lb_error
            // 
            lb_error.AutoSize = true;
            lb_error.ForeColor = Color.Red;
            lb_error.Location = new Point(14, 279);
            lb_error.Name = "lb_error";
            lb_error.Size = new Size(0, 17);
            lb_error.TabIndex = 3;
            // 
            // btn_clean
            // 
            btn_clean.Location = new Point(95, 257);
            btn_clean.Name = "btn_clean";
            btn_clean.Size = new Size(75, 23);
            btn_clean.TabIndex = 1;
            btn_clean.Text = "清除接收";
            btn_clean.UseVisualStyleBackColor = true;
            btn_clean.Click += btn_clean_Click;
            // 
            // btn_open
            // 
            btn_open.Location = new Point(95, 224);
            btn_open.Name = "btn_open";
            btn_open.Size = new Size(75, 23);
            btn_open.TabIndex = 2;
            btn_open.Text = "打开串口";
            btn_open.UseVisualStyleBackColor = true;
            btn_open.Click += btn_open_Click;
            // 
            // com_validate
            // 
            com_validate.FormattingEnabled = true;
            com_validate.Location = new Point(95, 175);
            com_validate.Name = "com_validate";
            com_validate.Size = new Size(121, 25);
            com_validate.TabIndex = 1;
            // 
            // com_data
            // 
            com_data.FormattingEnabled = true;
            com_data.Location = new Point(95, 140);
            com_data.Name = "com_data";
            com_data.Size = new Size(121, 25);
            com_data.TabIndex = 1;
            // 
            // com_stop
            // 
            com_stop.FormattingEnabled = true;
            com_stop.Location = new Point(95, 105);
            com_stop.Name = "com_stop";
            com_stop.Size = new Size(121, 25);
            com_stop.TabIndex = 1;
            // 
            // com_hz
            // 
            com_hz.FormattingEnabled = true;
            com_hz.Location = new Point(95, 70);
            com_hz.Name = "com_hz";
            com_hz.Size = new Size(121, 25);
            com_hz.TabIndex = 1;
            // 
            // com_port
            // 
            com_port.FormattingEnabled = true;
            com_port.Location = new Point(95, 35);
            com_port.Name = "com_port";
            com_port.Size = new Size(121, 25);
            com_port.TabIndex = 1;
            com_port.TextChanged += com_port_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 227);
            label6.Name = "label6";
            label6.Size = new Size(35, 17);
            label6.TabIndex = 0;
            label6.Text = "操作:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 182);
            label5.Name = "label5";
            label5.Size = new Size(47, 17);
            label5.TabIndex = 0;
            label5.Text = "效验位:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 146);
            label4.Name = "label4";
            label4.Size = new Size(47, 17);
            label4.TabIndex = 0;
            label4.Text = "数据位:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 110);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.TabIndex = 0;
            label3.Text = "停止位:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 76);
            label2.Name = "label2";
            label2.Size = new Size(47, 17);
            label2.TabIndex = 0;
            label2.Text = "波特率:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 34);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 0;
            label1.Text = "端口号:";
            // 
            // panel_bottom
            // 
            panel_bottom.Controls.Add(group_send);
            panel_bottom.Dock = DockStyle.Bottom;
            panel_bottom.Location = new Point(0, 318);
            panel_bottom.Margin = new Padding(0);
            panel_bottom.Name = "panel_bottom";
            panel_bottom.Padding = new Padding(5);
            panel_bottom.Size = new Size(750, 109);
            panel_bottom.TabIndex = 2;
            // 
            // group_send
            // 
            group_send.Controls.Add(btn_send);
            group_send.Controls.Add(txt_send);
            group_send.Dock = DockStyle.Bottom;
            group_send.Location = new Point(5, 4);
            group_send.Margin = new Padding(0);
            group_send.Name = "group_send";
            group_send.Padding = new Padding(5);
            group_send.Size = new Size(740, 100);
            group_send.TabIndex = 0;
            group_send.TabStop = false;
            group_send.Text = "数据发送";
            // 
            // btn_send
            // 
            btn_send.Location = new Point(637, 44);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(75, 23);
            btn_send.TabIndex = 1;
            btn_send.Text = "发送";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // txt_send
            // 
            txt_send.Dock = DockStyle.Left;
            txt_send.Location = new Point(5, 21);
            txt_send.Multiline = true;
            txt_send.Name = "txt_send";
            txt_send.Size = new Size(616, 74);
            txt_send.TabIndex = 0;
            // 
            // SerialMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 427);
            Controls.Add(panel_bottom);
            Controls.Add(split_top);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SerialMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "串口工具";
            Load += SerialMain_Load;
            split_top.Panel1.ResumeLayout(false);
            split_top.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)split_top).EndInit();
            split_top.ResumeLayout(false);
            group_setting.ResumeLayout(false);
            group_setting.PerformLayout();
            panel_bottom.ResumeLayout(false);
            group_send.ResumeLayout(false);
            group_send.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer split_top;
        private RichTextBox rich_text_receive;
        private GroupBox group_setting;
        private Button btn_open;
        private ComboBox com_validate;
        private ComboBox com_data;
        private ComboBox com_stop;
        private ComboBox com_hz;
        private ComboBox com_port;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_clean;
        private Panel panel_bottom;
        private GroupBox group_send;
        private Button btn_send;
        private TextBox txt_send;
        private Label lb_error;
    }
}