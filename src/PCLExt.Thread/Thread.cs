using System;

namespace PCLExt.Thread
{
    /// <summary>
    /// 
    /// </summary>
    public static class Thread
    {
        private static Exception NotImplementedInReferenceAssembly() => 
            new NotImplementedException(@"This functionality is not implemented in the portable version of this assembly.
You should reference the PCLExt.Thread NuGet package from your main application project in order to reference the platform-specific implementation.");
        

        /// <summary>
        /// 
        /// </summary>
        public static int Threads
        {
            get
            {
#if DESKTOP || ANDROID || __IOS__ || MAC
                return System.Diagnostics.Process.GetCurrentProcess().Threads.Count;
#endif

                throw NotImplementedInReferenceAssembly();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static IThread Create(ThreadStart start)
        {
#if DESKTOP || ANDROID || __IOS__ || MAC
            return new DesktopThread(start);
#endif

            throw NotImplementedInReferenceAssembly();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public static IThread Create(ParameterizedThreadStart start)
        {
#if DESKTOP || ANDROID || __IOS__ || MAC
            return new DesktopThread(start);
#endif

            throw NotImplementedInReferenceAssembly();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        public static void Sleep(int milliseconds)
        {
#if DESKTOP || ANDROID || __IOS__ || MAC
            System.Threading.Thread.Sleep(milliseconds);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waitCallback"></param>
        public static void QueueUserWorkItem(WaitCallback waitCallback)
        {
#if DESKTOP || ANDROID || __IOS__ || MAC
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(waitCallback));
#endif
        }
    }
}
