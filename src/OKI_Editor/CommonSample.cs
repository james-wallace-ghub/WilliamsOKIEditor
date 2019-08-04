using System.Collections.Generic;

namespace OKI_Editor
{
    public class CommonSample
    {
        internal bool valid = false;
        internal bool enabled = false;
        internal int start;
        internal int length;
        internal int id;
        internal int offset=0;
        internal List<int> depends = new List<int>();
        internal byte[] RAW;
    }
}