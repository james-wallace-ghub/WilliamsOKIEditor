using System.Collections.Generic;

namespace OKI_Editor
{
    public class CommonSample
    {
        internal bool enabled = false;
        internal int origstart;
        internal int length;
        internal int id;
        internal int start;
        internal int end;
        internal int offset;
        internal List<int> depends = new List<int>();
        internal byte[] RAW;
    }
}