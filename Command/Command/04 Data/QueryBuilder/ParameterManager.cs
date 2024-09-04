using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class ParameterManager
    {
        private Dictionary<string, object> parameters = new Dictionary<string, object>();
        private int parameterIndex = 0;

        // 파라미터 추가 및 플레이스홀더 반환
        public string AddParameter(object value)
        {
            var paramPlaceholder = $"@param{parameterIndex++}";
            parameters[paramPlaceholder] = value;
            return paramPlaceholder;
        }

        // 파라미터 딕셔너리 반환
        public Dictionary<string, object> GetParameters()
        {
            return parameters;
        }

        // 파라미터 초기화
        public void Clear()
        {
            parameters.Clear();
            parameterIndex = 0;
        }
    }
}
