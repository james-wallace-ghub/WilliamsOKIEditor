using System;
using System.Collections.Generic;

namespace OKI_Editor
{
    public class Sample
    {
        internal bool valid = false;
        internal bool enabled = false;
        internal int id;
        internal int start;
        internal int end;
        internal int offset;
        internal List<int> parents = new List<int>();
        internal List<int> depends = new List<int>();
        internal int length;
        internal bool common;
        internal int commonid;
        internal byte[] RAW;

        public static implicit operator Sample(CommonSample v)
        {
            Sample retval = new Sample();
            retval.valid = v.valid;
            retval.enabled = v.enabled;
            retval.id = v.id;
            retval.start = v.start;
            retval.offset = v.offset;
            retval.depends = v.depends;
            retval.length = v.length;
            retval.RAW = v.RAW;
            return retval;
    }
}


}