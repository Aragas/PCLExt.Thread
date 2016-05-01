using System;

namespace PCLExt.Thread
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void ThreadStart();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    public delegate void ParameterizedThreadStart(object obj);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
    public delegate void WaitCallback(object state);
    /// <summary>
    /// 
    /// </summary>
    public interface IThread
    {
        /// <summary>
        /// 
        /// </summary>
        String Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Boolean IsBackground { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Boolean IsRunning { get; }

        /// <summary>
        /// 
        /// </summary>
        void Start();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Start(Object obj);

        /// <summary>
        /// 
        /// </summary>
        void Abort();
    }
}