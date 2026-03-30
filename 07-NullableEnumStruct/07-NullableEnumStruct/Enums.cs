using System;
using System.Collections.Generic;
using System.Text;

namespace _07_NullableEnumStruct
{
    enum DrinkType
    {
        Coffee = 0,
        Tea = 1,
        Juice = 2,
        Water = 3
    }

    enum DrinkSize
    {
        Small = 0,
        Medium = 1,
        Large = 2
    }

    enum OrderStatus
    {
        New = 0,
        Preparing = 1,
        Ready = 2,
        Delivered = 3
    }
}
