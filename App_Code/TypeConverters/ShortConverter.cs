using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeConverters
{
    public class ShortConverter : ITypeConverter
    {
        public object Convert(object ValueToConvert)
        {
            if (ValueToConvert == null || ValueToConvert == DBNull.Value)
                return 0;

            return System.Convert.ToInt16(ValueToConvert);
        }
    }
}
