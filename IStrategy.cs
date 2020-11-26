using System;
using System.Collections.Generic;
using System.Text;

namespace second_lab_oop
{
    public interface IStrategy
    {
        internal List<Beer> Commit();
    }
}
