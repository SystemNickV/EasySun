using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasySun.Service
{
    public static class SunLogCrudMessages
    {
        public const string GetAll = "Requested {modelType} list at {dateTime}";
        public const string GetById = "Get({id}) at {dateTime}";
        public const string GetByIdNotFound = "Get({id}) NOT FOUND at {dateTime}";
        public const string Insert = "Insert at {dateTime}";
        public const string UpdateById = "Update({id}) at {dateTime}";
        public const string UpdateByIdNotFound = "Update({id}) NOT FOUND at {dateTime}";
        public const string DeleteById = "Detele({id}) at {dateTime}";
        public const string DeleteByIdNotFound = "Detele({id}) NOT FOUND at {dateTime}";
    }
}
