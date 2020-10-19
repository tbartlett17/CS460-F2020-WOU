using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460_HW3
{
    interface IQueueInterface<T>
    {

        T Push(T element);

        T Pop();

        T Peek();       
        bool IsEmpty();


    }
}
