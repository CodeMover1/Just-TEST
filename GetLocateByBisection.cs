using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn20180109
{
    class GetLocateByBisection
    {
        public string Locate(int[]XX,int N, int X)
        {
            int tem_n;
            int j1, ju, jm;
            j1 = 0;
            ju = N + 1;
            rebound:
            if (ju - j1 > 1)
            {
                jm = (ju + j1)/2;
                if (XX[N] > XX[1] == X > XX[jm])
                    j1 = jm;
                else
                {
                    ju = jm;
                }
                goto rebound;
            }
            tem_n = j1;
            if (X - XX[tem_n] > (XX[tem_n + 1] - N))
                tem_n = j1 + 1;
            return "a[" + tem_n.ToString() + "]" + XX[tem_n].ToString();
        }
    }
}
