using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CRUFL_Barcode
{
    [ComVisible(true), ClassInterface(ClassInterfaceType.None), Guid("2D43D1CA-67CA-4B9D-AF0F-D7279DF2FA46")]
    public class Interleaved : IBarCode2of5
    {
        /// <summary>
        /// Gera uma string para ser usada com a fonte 'Code 2/5 Interleaved'
        /// </summary>
        /// <param name="codigo"></param>
        /// <see cref="https://www.mail-archive.com/sqlwin@virtualand.net/msg03351.html"/>
        /// <returns></returns>
        public string To2of5(string codigo)
        {
            // Pressupoe-se que existe um numero par de digitos em codigo
            int ii = 1;
            int jj = codigo.Length;
            string sCod = "";

            while (ii < jj)
            {
                // Separando os digitos dois a dois
                string sTmp = Mid(codigo, ii, 2);
                ii = ii + 2;
                int iTmp = Convert.ToInt32(sTmp);

                // A + ABS(A<=49)*48 + ABS(A>=50)*142
                iTmp = iTmp + Math.Abs(Convert.ToInt32(iTmp <= 49)) * 48 + Math.Abs(Convert.ToInt32(iTmp >= 50)) * 142;

                // Pegando o caracter da conta acima.
                sCod = sCod + (char) iTmp;
            }

            // Delimitadores - inicial e final
            if (sCod != "")
                sCod = "(" + sCod + ")";

            return sCod;
        }

        private static string Mid(string str, int pos, int length)
        {
            return str.Substring(pos - 1, length);
        }
    }
}
