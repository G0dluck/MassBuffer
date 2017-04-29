using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassBuffer
{
    class BufferPresenter
    {
        private readonly IBufferView _view;
        private readonly IBufferModel _model;
        private int _point;

        public BufferPresenter(IBufferView view, IBufferModel model)
        {
            _view = view;
            _model = model;
        }

        public void SetDataInBuffer(int index)
        {
            var data = _model.SetDataInBuffer(index);
            _view.SetDataInBuffer(data);
        }

        public void WriteData(string data)
        {
            if (CheckExistData(data))
            {
                return;
            }
            _model.WriteData(data, _point);
            _view.ViewData(data, _point);
            _point++;
            if (_point >= _model.GetArrCount())
            {
                _point = 0;
            }
            
        }

        bool CheckExistData(string data)
        {
            var arr = _model.GetArrData();
            if (arr.Contains(data))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
