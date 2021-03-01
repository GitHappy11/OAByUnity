
using System.Collections.Generic;

namespace Common.Tools
{
    public class DictTool
    {
        //得到字典内的值
        public static T2 GetValue<T1,T2>(Dictionary<T1,T2> dict,T1 key)
        {
            T2 value;
            bool isSuccess = dict.TryGetValue(key, out value);
            if (isSuccess)
            {
                return value;
            }
            else
            {
                return default(T2);
            }

        }

    }
}
