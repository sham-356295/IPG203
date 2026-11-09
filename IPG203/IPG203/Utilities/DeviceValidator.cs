using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203.Utilities
{
    public static class DeviceValidator
    {
        // التحقق من الرقم التسلسلي
        public static bool IsValidSerial(string serial)
        {
            return !string.IsNullOrWhiteSpace(serial);
        }

        // التحقق من اسم الجهاز
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
