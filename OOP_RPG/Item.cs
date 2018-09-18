using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    interface ITem
    {
        int OriginalValue { get; set; }
        int ResellValue { get; set; }
        int ItemNumber { get; set; }
    }
}
