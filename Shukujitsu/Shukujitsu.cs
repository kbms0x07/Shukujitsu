using System;

namespace Shukujitsu
{
    public static class Shukujitsu
    {
        /// <summary>
        /// その日が国民の祝日かどうか判定します。
        /// </summary>
        /// <param name="date"></param>
        /// <returns>true: 祝日, false: 非祝日</returns>
        public static bool IsShukujitsu(this DateTime date)
        {
            return Dates.dict.ContainsKey(date);
        }
    }
}
