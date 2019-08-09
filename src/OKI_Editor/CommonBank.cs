using System;
using System.Collections.Generic;

namespace OKI_Editor
{
    public class CommonBank
    {
        public int headersize = 0;
        public int lastsample = 0;
        public int sparespace = 0;

        public Sample[] samples = new Sample[128];
        public CommonBank()
        {
            for (int i = 0; i < 128; i++)
            {
                this.samples[i] = new Sample();
            }

        }

        public int addSample(int start, int length, byte[] RAW)
		{
            int pos = 1;
			bool firstsample=true;
			foreach (Sample sample in samples) {
                if (sample.valid == false)
                {
					//We skip the first sample of all 0's
					if (firstsample == false) {
                    break;
					}
					else {
						firstsample =false;
						continue;
					}
                }
                if ( (sample.start == start) && sample.length == length)
                {
                    if (pos > lastsample)
                    {
                        lastsample = pos;
                    }
                    return sample.id;
                }
                pos++;
				firstsample=false;
            }
            //We haven't found an existing one, make one
            Sample newsample = new Sample();
            newsample.enabled = true;
            newsample.valid = true;
            newsample.start = start;
            newsample.length = length;
            newsample.end = start + length;
            newsample.id = pos;
            newsample.RAW = RAW;
            samples[pos] = newsample;
            if (pos > lastsample)
            {
                lastsample = pos;
            }
            return newsample.id;
		}
	}
}
