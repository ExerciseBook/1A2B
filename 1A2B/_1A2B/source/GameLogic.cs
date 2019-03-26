namespace _1A2B.source
{
    public class GameLogic
    {
        public static bool[] aTargetNumber = new bool[10];
        private static int msnTargetUnitsDigit, msnTargetTensDigit, msnTargetHundredsDigit, msnTargetThousandsDigit;//Target number
        private static int msnSubmitUnitsDigit, msnSubmitTensDigit, msnSubmitHundredsDigit, msnSubmitThousandsDigit;//Submitted number

        public struct Response//the response of submit 
        {
            public int nA, nB;//number of A&B
        };

        private Response ans;
        /*
         * 本方法用来判断这个提交是否合法
         * 根据1A2B的游戏规则，用户提交的四位数必须互不相等，并且不能有前导零
         *
         * @param a 需要判断你的数字
         * 
         * @return true 合法 , false 不合法
         */
        public bool isValid(int a)
        {
            int[] p = new int[10];

            if (a < 1000) { return false; }

            while (a != 0)
            {
                int b = a % 10;
                p[b]++;
                if (p[b] > 1)
                {
                    return false;
                }
                a = a / 10;
            }

            return true;
        }


        public bool start(int a)
        {
            //游戏开始的时候这个方法会被调用
            //返回值啥的我没有限定，反正你最后告诉我你返回值是啥意思就好
            msnTargetUnitsDigit = a % 10; a /= 10;
            msnTargetTensDigit = a % 10; a /= 10;
            msnTargetHundredsDigit = a % 10; a /= 10;
            msnTargetThousandsDigit = a % 10;

            aTargetNumber[msnTargetUnitsDigit] = true;
            aTargetNumber[msnSubmitTensDigit] = true;
            aTargetNumber[msnTargetHundredsDigit] = true;
            aTargetNumber[msnTargetThousandsDigit] = true;

            if (isValid(a))
                return true; //true -> can start games normally
            else
                return false; //false -> cannot start games       
        }


        public void finish()
        {
            /*
             *我不知道这里应该写啥，输出表示胜利的message吗
             */
        }


        public bool isfinish()
        {
            if (ans.nA == 4)
                return true;//true -> finished
            else
                return false;//false -> notfinished
        }

        public void judge(int a)
        {
            //diverse the number
            msnSubmitUnitsDigit = a % 10; a /= 10;
            msnSubmitTensDigit = a % 10; a /= 10;
            msnSubmitHundredsDigit = a % 10; a /= 10;
            msnSubmitThousandsDigit = a % 10;

            //calculate the number of B
            if (aTargetNumber[msnSubmitUnitsDigit])
                ans.nB++;
            if (aTargetNumber[msnTargetTensDigit])
                ans.nB++;
            if (aTargetNumber[msnTargetHundredsDigit])
                ans.nB++;
            if (aTargetNumber[msnTargetThousandsDigit])
                ans.nB++;

            //calculate the number of A
            if (msnTargetUnitsDigit == msnSubmitUnitsDigit)
            {
                ans.nB--;
                ans.nA++;
            }
            if (msnTargetTensDigit == msnSubmitTensDigit)
            {
                ans.nB--;
                ans.nA++;
            }
            if (msnTargetHundredsDigit == msnSubmitHundredsDigit)
            {
                ans.nB--;
                ans.nA++;
            }
            if (msnTargetThousandsDigit == msnSubmitThousandsDigit)
            {
                ans.nB--;
                ans.nA++;
            }
        }



        public int submit(int a)
        {
            //用户提交答案尝试的时候这个方法会被调用
            //返回值啥的我没有限定，反正你最后告诉我你返回值是啥意思就好

            if (isValid(a))
            {
                judge(a);
                if (isfinish())
                {
                    finish();
                    return 1;//1 -> win
                }
                else
                    return 0;//0 -> lost
                /*
                 * 
                 * 
                 */
            }
            else
                return -1;//-1 -> abnormal exit(by illegal input)
        }
    }
}
