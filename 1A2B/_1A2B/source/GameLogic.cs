using System;

namespace _1A2B.source
{
    public class GameLogic
    {
        public static bool[] aTargetNumber = new bool[10];
        private static int msnTargetUnitsDigit, msnTargetTensDigit, msnTargetHundredsDigit, msnTargetThousandsDigit;//Target number
        private static int msnSubmitUnitsDigit, msnSubmitTensDigit, msnSubmitHundredsDigit, msnSubmitThousandsDigit;//Submitted number

        public struct Response//the response of submit 
        {
            public int n, nA, nB;//number of A&B
        };

        /// 用来储存用户的历史提交记录
        public Response[] stats = new Response[10];


        private Response ans;

        /** 本方法用来判断这个提交是否合法
         * 
         * 根据1A2B的游戏规则，用户提交的四位数必须互不相等，并且不能有前导零
         *
         * @param a 需要判断你的数字
         * 
         * @return (true 合法 , false 不合法)
         */
        public bool IsValid(int a)
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


        /** 本方法用于进行游戏初始化
         * 
         * 在游戏开始时本方法会被调用
         */
        public void Start()
        {
            //所有变量的初始化在这里都要丢一份

            int a = 0;
            Random rand = new Random();
            while (!IsValid(a)) { a = rand.Next(10000); };

            msnTargetUnitsDigit = a % 10; a /= 10;
            msnTargetTensDigit = a % 10; a /= 10;
            msnTargetHundredsDigit = a % 10; a /= 10;
            msnTargetThousandsDigit = a % 10;

            aTargetNumber[msnTargetUnitsDigit] = true;
            aTargetNumber[msnSubmitTensDigit] = true;
            aTargetNumber[msnTargetHundredsDigit] = true;
            aTargetNumber[msnTargetThousandsDigit] = true;
        }


        /** 本方法用于获取游戏当前状态
         * 
         * @return (0 游戏未开始, 1 正在游戏, 2 游戏结束)
         * 
         */ 
        public int GetGameStatus()
        {
            throw new Exception("待补充");
            return 0;
        }


        /** 提交信息判定
         * 
         * @param a 待判定数值
         */
        private void Judge(int a)
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


        /** 本方法用于提交用户输入的四位数
         * 
         * @param a 用户提交的四位数
         * 
         * @return (0 正常处理, -1 用户输入不合法)
         */ 
        public int submit(int a)
        {
            //用户提交答案尝试的时候这个方法会被调用
            //返回值啥的我没有限定，反正你最后告诉我你返回值是啥意思就好

            if (IsValid(a))
            {
                Judge(a);
                return 0;
            }
            else
                return -1;//-1 -> abnormal exit(by illegal input)
        }
    }
}
