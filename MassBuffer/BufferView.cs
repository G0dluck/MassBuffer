using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassBuffer
{
    interface IBufferView
    {
        void SetData(string[] data);
        void ViewData(string data, int i);
        void SetDataInBuffer(string data);
    }

    public partial class BufferView : Form, IBufferView
    {
        private BufferPresenter _presenter;
        private Timer _timer;

        public BufferView()
        {
            InitializeComponent();

            _presenter = new BufferPresenter(this, new BufferModel());
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                _presenter.WriteData(Clipboard.GetText());
            }
        }

        void IBufferView.ViewData(string data, int i)
        {
            if (listBox1.Items.Count == i)
            {
                listBox1.Items.Add(data);
            }
            else
            {
                listBox1.Items[i] = data;
            }
        }

        void IBufferView.SetData(string[] data)
        {
            listBox1.Items.AddRange(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.SetDataInBuffer(listBox1.SelectedIndex);
        }

        void IBufferView.SetDataInBuffer(string data)
        {
            Clipboard.SetText(data);
        }
    }
}
