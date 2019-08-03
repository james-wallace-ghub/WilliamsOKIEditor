using System;
using System.Collections.Generic;

namespace OKI_Editor
{
    public class CommonBank
    {
        public int headersize = 0;
        public int lastsample = 0;
        public int sparespace = 0;
        public List<CommonSample> samples = new List<CommonSample>();
        public CommonBank()
        {
			
		}
		
		public int addSample(int start, int length, byte[] RAW)
		{
			foreach (CommonSample sample in samples) {
                if ( (sample.origstart == start) && sample.length == length)
                {
                    return sample.id;
                }
            }
            //We haven't found an existing one, make one
            CommonSample newsample = new CommonSample();
            newsample.origstart = start;
            newsample.length = length;
            newsample.id = samples.Count;
            newsample.RAW = RAW;
            samples.Add(newsample);
            return newsample.id;
		}
	}
}