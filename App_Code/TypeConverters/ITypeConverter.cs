using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeConverters
{
    public interface ITypeConverter
    {
        object Convert(object ValueToConvert);
    }
}
