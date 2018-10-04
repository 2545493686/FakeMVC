using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVC
{
    class LengthModel
    {
        static List<LengthModel> lengths = new List<LengthModel>();

        public int Value { get; set; } = 0;

        public static LengthModel GetModel(LengthType type)
        {
            if (lengths.Count == 0) Create();
            return lengths[(int)type];
        }

        static void Create()
        {
            for (int i = 0; i < Enum.GetValues(typeof(LengthType)).Length; i++)
            {
                lengths.Add(new LengthModel());
            }
        }
    }
}
