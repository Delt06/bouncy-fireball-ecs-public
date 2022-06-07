using UnityEngine;

namespace Features._Shared.Services
{
    public class UnityLogger : ILogger
    {
        public void Log(object obj)
        {
            Debug.Log(obj);
        }
    }
}