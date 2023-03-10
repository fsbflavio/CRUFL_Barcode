using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CRUFL_Barcode
{
    [ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("F0F9B1CE-9FE2-4AD9-B639-745128A781EC")]
    public interface IBarCode2of5
    {
        string To2of5(string barCode);
    }
}
