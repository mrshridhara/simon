using System;
using System.Reflection;

namespace Simon
{
    /// <summary>
    /// Represents the SIMON core assembly.
    /// </summary>
    public static class SimonAssembly
    {
        /// <summary>
        /// The assembly reference.
        /// </summary>
        public static readonly Assembly Reference = typeof(SimonAssembly).Assembly;

        /// <summary>
        /// The assembly version.
        /// </summary>
        public static readonly Version Version = Reference.GetName().Version;
    }
}