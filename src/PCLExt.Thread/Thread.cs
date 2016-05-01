using System;

namespace PCLExt.Thread
{
    /// <summary>
    /// 
    /// </summary>
    public static class Thread
    {
        static Lazy<IThreadFactory> _instance = new Lazy<IThreadFactory>(CreateInstance, System.Threading.LazyThreadSafetyMode.PublicationOnly);

        static IThreadFactory CreateInstance()
        {
#if COMMON
            return new DesktopThreadFactory();
#endif

            return null;
        }

        private static IThreadFactory Instance
        {
            get
            {
                var ret = _instance.Value;
                if (ret == null)
                    throw NotImplementedInReferenceAssembly();
                return ret;
            }
        }

        internal static Exception NotImplementedInReferenceAssembly() => new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the PCLExt.Thread NuGet package from your main application project in order to reference the platform-specific implementation.");



        /// <summary>
        /// 
        /// </summary>
        public static int Threads
        {
            get
            {
#if COMMON
                return System.Diagnostics.Process.GetCurrentProcess().Threads.Count;
#endif

                return 0;
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

            return null;
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

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        public static void Sleep(int milliseconds)
        {
#if COMMON
            System.Threading.Thread.Sleep(milliseconds);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waitCallback"></param>
        public static void QueueUserWorkItem(WaitCallback waitCallback)
        {
#if COMMON
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(waitCallback));
#endif
        }
    }
}
