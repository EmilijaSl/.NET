using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Demo
{
    public static class ProductHelper
    {
        #region ByColor
        public static IEnumerable<Product> ByColor(
            this IEnumerable<Product> query, string color) //extension method (this) naudojamas specifikuoti kokiam tipui gali buti naudojamas extension method (sio atveju Ienumerable produktu)
        {
            return query.Where(prod => prod.Color == color);
        }
        #endregion
    }
}
