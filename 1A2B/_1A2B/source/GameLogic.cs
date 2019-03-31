using System;

namespace _1A2B.source
{
    public class GameLogic
    {
        public static bool[] aTargetNumber = new bool[10];
        private static int msnTargetUnitsDigit, msnTargetTensDigit, msnTargetHundredsDigit, msnTargetThousandsDigit;//Target number
        private static int msnSubmitUnitsDigit, msnSubmitTensDigit, msnSubmitHundredsDigit, msnSubmitThousandsDigit;//Submitted number

        private int cntEnquire;

        public struct Response//the response of submit 
        {
            public int n, nA, nB;//number of A&B
        };

        /// <summary>
        /// 用来储存用户的历史提交记录
        /// </summary>
        public Response[] stats = new Response[10];


        private Response ans;

        /// <summary>
        /// 上一次请求的结果
        /// </summary>
        public Response LastSubmit { get => ans; }



        /// <summary>
        /// 本方法用来判断这个提交是否合法
        /// 根据1A2B的游戏规则，用户提交的四位数必须互不相等，并且不能有前导零
        /// </summary>
        /// <param name="a">需要判断你的数字</param>
        /// <returns>true 合法 , false 不合法</returns>
        public bool IsValid(int a)
        {
            int[] p = new int[10];

            if (a >= 10000) { return false; }
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

        /// <summary>
        /// 为什么这个输入不合法
        /// </summary>
        /// <param name="a">需要判断你的数字</param>
        /// <returns>0 合法, 1 过小, 2 过大, 3 包含重复数字</returns>
        public int WhyInvalid(int a)
        {
            int[] p = new int[10];

            if (a >= 10000) { return 2; }
            if (a < 1000) { return 1; }

            while (a != 0)
            {
                int b = a % 10;
                p[b]++;
                if (p[b] > 1)
                {
                    return 3;
                }
                a = a / 10;
            }

            return 0;
        }


        /// <summary>
        /// 本方法用于进行游戏初始化
        /// 
        /// 在游戏开始时本方法会被调用
        /// </summary>
        public void Start()
        {
            Response[] stats = new Response[10];
            aTargetNumber = new bool[10];

            cntEnquire = 0;

            ans.n = 0;
            ans.nA = 0;
            ans.nB = 0;

            int a = 0;
            Random rand = new Random();
            while (!IsValid(a)) { a = rand.Next(10000); };

            msnSubmitUnitsDigit = 0;
            msnSubmitTensDigit = 0;
            msnSubmitHundredsDigit = 0;
            msnSubmitThousandsDigit = 0;

            msnTargetUnitsDigit = a % 10; a /= 10;
            msnTargetTensDigit = a % 10; a /= 10;
            msnTargetHundredsDigit = a % 10; a /= 10;
            msnTargetThousandsDigit = a % 10;

            aTargetNumber[msnTargetUnitsDigit] = true;
            aTargetNumber[msnTargetTensDigit] = true;
            aTargetNumber[msnTargetHundredsDigit] = true;
            aTargetNumber[msnTargetThousandsDigit] = true;
        }

        /// <summary>
        /// 本方法用于获取游戏当前状态
        /// </summary>
        /// <returns>0 游戏未开始, 1 正在游戏, 2 游戏胜利, 3 游戏失败</returns>
        public int GetGameStatus()
        {
            if (ans.nA == 4)
                return 2;
            else
            if (cntEnquire == 10)
                return 3;
            if (msnTargetThousandsDigit != 0)
                return 1;
            else 
                return 0;
        }


        /// <summary>
        /// 提交信息判定
        /// </summary>
        /// <param name="a">待判定数字</param>
        private void Judge(int a)
        {
            ans.n = a;
            ans.nA = ans.nB = 0;
            //diverse the number
            msnSubmitUnitsDigit = a % 10; a /= 10;
            msnSubmitTensDigit = a % 10; a /= 10;
            msnSubmitHundredsDigit = a % 10; a /= 10;
            msnSubmitThousandsDigit = a % 10;

            //calculate the number of B
            if (aTargetNumber[msnSubmitUnitsDigit])
                ans.nB++;
            if (aTargetNumber[msnSubmitTensDigit])
                ans.nB++;
            if (aTargetNumber[msnSubmitHundredsDigit])
                ans.nB++;
            if (aTargetNumber[msnSubmitThousandsDigit])
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

        /// <summary>
        /// 获取正确答案
        /// </summary>
        /// <returns>正确答案</returns>
        public int GetAns()
        {
            return msnTargetThousandsDigit * 1000 + msnTargetHundredsDigit * 100 + msnTargetTensDigit * 10 + msnTargetUnitsDigit;
        }

        /// <summary>
        /// 本方法用于提交用户输入的四位数
        /// </summary>
        /// <param name="a">用户输入的四位数</param>
        /// <returns>0 正常处理, -1 处理失败</returns>
        public int submit(int a)
        {
            //用户提交答案尝试的时候这个方法会被调用
            //返回值啥的我没有限定，反正你最后告诉我你返回值是啥意思就好

            //Limit the times of enquire
            if (cntEnquire == 10)
                return -1;

            if (IsValid(a))
            {
                Judge(a);
                stats[cntEnquire++] = ans;//restore the status

                if (ans.nA == 4)
                {
                    Core.displayControl.NoticeBlock.PrintPlain(Core.resourceLoader.GetString("NoticeBlock_Info_Game_End_Win").Replace("%ANSWER%", "" + GetAns()));
                }
                else
                if (cntEnquire == 10)
                {
                    Core.displayControl.NoticeBlock.PrintPlain(Core.resourceLoader.GetString("NoticeBlock_Info_Game_End_Lost").Replace("%ANSWER%", ""+GetAns()));
                }
                else {
                    Core.displayControl.NoticeBlock.Print("NoticeBlock_Info_Ready");
                }

                return 0;
            }
            else
                return -1;//-1 -> abnormal exit(by illegal input)
        }
    }
}
