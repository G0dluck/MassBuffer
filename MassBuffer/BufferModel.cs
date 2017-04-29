using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassBuffer
{
    interface IBufferModel
    {
        string[] LoadData();
        void WriteData(string data, int i);
        string[] GetArrData();
        int GetArrCount();
        string SetDataInBuffer(int index);
    }

    class BufferModel : IBufferModel
    {
        private static int COUNT = 5;
        private string[] _data = new string[COUNT];

        string[] IBufferModel.LoadData()
        {
            return new string[] { "123", "321", "456" };
        }

        void IBufferModel.WriteData(string data, int i)
        {
            _data[i] = data;
        }

        string[] IBufferModel.GetArrData()
        {
            return _data;
        }

        int IBufferModel.GetArrCount()
        {
            return COUNT;
        }

        string IBufferModel.SetDataInBuffer(int index)
        {
            return _data[index];
        }
    }
}
