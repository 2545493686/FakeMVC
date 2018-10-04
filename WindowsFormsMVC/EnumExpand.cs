using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsMVC
{
    static class EnumExpand
    {
        public static string GetText(this Enum @enum)
        {
            FieldInfo fieldInfo = @enum.GetType().GetField(@enum.ToString());
            DescriptionAttribute description = 
                (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            if (description == null)
            {
                throw new Exception(@enum.GetType().ToString() +
                "." + @enum.ToString() +
                " 没有设置Description特性");
            }
            return description == null ? "" : description.Description;
        }
    }
}
