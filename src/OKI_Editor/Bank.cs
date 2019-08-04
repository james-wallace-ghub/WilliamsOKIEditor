using System;

namespace OKI_Editor
{
    public class Bank
    {
        private int bankval;
        public int headersize = 0;
        public int lastsample = 0;
        public int sparespace = 0;
        public Sample[] samples = new Sample[127];

        public Bank()
        {

        }
        public Bank(int bank, byte[] WPCROM, int address, CommonBank cb)
        {
            for (int i=0; i < 127; i++)
            {
                this.samples[i] = new Sample();
            }
            this.bankval = bank;
            int position = address + 0x08;
            for (int cnt2 = 0; cnt2 < 127; cnt2++)
            {
                Sample sample = new Sample();
                sample.offset = 0;
                sample.valid = true;
                sample.enabled = true;
                headersize += 0x08;
                sample.id = cnt2;
                lastsample = cnt2;
                int start = 0;
                start = ((WPCROM[position] & 0x3) << 16);
                position++;
                start += (WPCROM[position] << 8);
                position++;
                start += WPCROM[position];
                position++;
                sample.start = start;

                int end = 0;
                end = ((WPCROM[position] & 0x3) << 16);
                position++;
                end += (WPCROM[position] << 8);
                position++;
                end += WPCROM[position];

                sample.end = end;
                sample.length = end - start;
                if (start >= 0x20000)
                {
                    int commonstart = (start - 0x20000 + 0x60000);
                    sample.common = true;
                    if (sample.length > 0)
                    {
                        byte[] RAW = new byte[sample.length];
                        Array.Copy(WPCROM, commonstart, RAW, 0, sample.length);
						sample.commonid = cb.addSample(commonstart, sample.length, RAW);
                    }
                }
                else
                {
                    sample.common = false;
                    if (sample.length >0)
                    {
                        byte [] RAW = new byte[sample.length];
                        Array.Copy(WPCROM, address + start, RAW, 0, sample.length);
                        sample.RAW = (byte[]) RAW.Clone();
                    }
                }

                this.samples[cnt2] = sample;

                bool endofbank = false;
                for (int chk = 0; chk < 2; chk++)
                {
                    position++;
                    if (WPCROM[position] != 0)
                    {
                        this.samples[cnt2] = new Sample();
                        endofbank = true;
                    }
                }
                if (endofbank)
                {
                    break;
                }
                position++;
            }
        }

        public static implicit operator Bank(CommonBank v)
        {
            Bank retval = new Bank();
            retval.samples = v.samples;
            return retval;
        }
    }
}