using AA.AspNetCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AA.Utils
{
    public class EngineContext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new AAEngine());

        }
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }
                return Singleton<IEngine>.Instance;

            }
        }
    }
}
