namespace PCLExt.Thread
{
    /// <summary>
    /// 
    /// </summary>
    public static class Thread
    {
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
#if DESKTOP || ANDROID || __IOS__
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
#if DESKTOP || ANDROID || __IOS__
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
