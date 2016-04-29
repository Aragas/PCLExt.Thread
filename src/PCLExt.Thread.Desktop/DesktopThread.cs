namespace PCLExt.Thread
{
    /// <summary>
    /// 
    /// </summary>
    public class DesktopThread : IThread
    {
        private readonly System.Threading.Thread _thread;

        /// <summary>
        /// 
        /// </summary>
        public string Name { get { return _thread.Name; } set { _thread.Name = value; } }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBackground { get { return _thread.IsBackground; } set { _thread.IsBackground = value; } }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRunning => _thread.ThreadState != System.Threading.ThreadState.Stopped;

        internal DesktopThread(ThreadStart action) { _thread = new System.Threading.Thread(new System.Threading.ThreadStart(action)); }
        internal DesktopThread(ParameterizedThreadStart action) { _thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(action)); }

        /// <summary>
        /// 
        /// </summary>
        public void Start() { _thread.Start(); }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Start(object obj) { _thread.Start(obj); }

        /// <summary>
        /// 
        /// </summary>
        public void Abort() { _thread.Abort(); }
    }
}
