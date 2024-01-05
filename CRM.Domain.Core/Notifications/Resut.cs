using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.Notifications
{ 
    public class Result<T>
    {
        public bool Success { get; private set; }
        public T Data { get; private set; }
        public List<string> Errors { get; private set; }

        private Result()
        {
            Errors = new List<string>();
        }

        public static Result<T> GetSuccess(T data)
        {
            return new Result<T> { Success = true, Data = data };
        }

        public static Result<T> GetFailure(params string[] errors)
        {
            var result = new Result<T> { Success = false };
            result.Errors.AddRange(errors);
            return result;
        }
    } 
}
