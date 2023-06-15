using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ACM.Coupon.Operations
{
    public static class OperationNames
    {
        public static List<string> operationTypes { get; private set; }
        static OperationNames()
        {
            operationTypes = new List<string>()
            {
                "none",
                "discount-percent",
                "discount-flat",
                "price-change"
            };
        }
    }
}
