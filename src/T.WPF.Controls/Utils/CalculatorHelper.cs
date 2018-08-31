using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Controls.Utils
{
    public static class CalculatorHelper
    {
        private static readonly DataTable calTool = new DataTable();

        /// <summary>
        /// calculate string expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string Compute(string expression)
        {
            return calTool.Compute(expression, "false").ToString();
        }
    }
}
