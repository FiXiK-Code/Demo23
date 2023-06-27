using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojarov_DEMO
{
    /// <summary>
    /// Класс буффера для передачи данных между окнами и функцями
    /// </summary>
    public static class Buffer
    {
        /// <summary>
        /// Контент, содержащийся в таблице вывода
        /// </summary>
        public static List<podzharow_DEMO> prodContent { get; set; } = new List<podzharow_DEMO>();

        public static bool sort { get; set; } = false;
    }
}
