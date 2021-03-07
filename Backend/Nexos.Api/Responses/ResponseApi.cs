using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.Api.Responses
{
    public class ResponseApi<T>
    {
        public ResponseApi(T _data)
        {
            data = _data;
        }
        public T data { get; set; }

    }
}
