using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_1
{
    public abstract class Base
    {
        protected bool SetValue<T>(ref T target, T value)
        {
            if (object.Equals(target, value))
                return false;

            target = value;
            return true;
        }
    }
}
