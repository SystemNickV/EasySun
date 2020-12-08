using Microsoft.Extensions.Logging;

namespace EasySun.Service
{
    public static class SunLogEvents
    {
        public const int GetItems = 1000;
        public const int GetItem = 1001;
        public const int InsertItem = 1002;
        public const int UpdateItem = 1003;
        public const int DeleteItem = 1004;

        public const int TestItem = 3000;

        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;
        public const int DeleteItemNotFound = 4002;
    }
}
