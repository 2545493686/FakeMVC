using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace WindowsFormsMVC
{
    enum LengthType
    {
        [Description("WindowsFormsMVC.LengthStart_Ctrl")]
        start = 0,
        [Description("WindowsFormsMVC.LengthEnd_Ctrl")]
        end = 1,
        [Description("WindowsFormsMVC.LengthLength_Ctrl")]
        length = 2
    }

    class LengthModel_Factory
    {
        readonly static string AssemblyName = "WindowsFormsMVC";

        public static LengthModel_Ctrl CreateCtrl(LengthType type)
        {
            if (type.GetText() == "") return null;

            return (LengthModel_Ctrl)
                Assembly.Load(AssemblyName).CreateInstance(type.GetText());
        }
    }

    abstract class LengthModel_Ctrl
    {
        abstract public void SetData(int value);
    }

    class LengthStart_Ctrl : LengthModel_Ctrl
    {
        public override void SetData(int value)
        {
            LengthModel.GetModel(LengthType.start).Value = value;
            LengthLength_Ctrl.RefreshData();
        }
    }

    class LengthEnd_Ctrl : LengthModel_Ctrl
    {
        public override void SetData(int value)
        {
            LengthModel.GetModel(LengthType.end).Value = value;
            LengthLength_Ctrl.RefreshData();
        }
    }

    class LengthLength_Ctrl : LengthModel_Ctrl
    {
        public static void RefreshData()
        {
            LengthModel.GetModel(LengthType.length).Value 
                = LengthModel.GetModel(LengthType.end).Value 
                - LengthModel.GetModel(LengthType.start).Value;
        }

        public override void SetData(int value)
        {
            LengthModel.GetModel(LengthType.length).Value = value;
            LengthModel.GetModel(LengthType.end).Value
                = LengthModel.GetModel(LengthType.start).Value
                + LengthModel.GetModel(LengthType.length).Value;
        }
    }
}
