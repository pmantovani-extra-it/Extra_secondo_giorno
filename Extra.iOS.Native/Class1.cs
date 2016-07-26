using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extra.iOS.Native
{
    public interface ICellBinding<T>
    {
        void BindCell(T item);
    }
}