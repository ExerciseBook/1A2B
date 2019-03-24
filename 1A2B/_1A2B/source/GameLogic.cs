namespace _1A2B.source
{
    internal class GameLogic
    {

        private int ans;

        /*
         * 本方法用来判断这个提交是否合法
         * 根据1A2B的游戏规则，用户提交的四位数必须互不相等，并且不能有前导零
         *
         * @param a 需要判断你的数字
         * 
         * @return true 合法 , false 不合法
         */
        public bool isValid(int a) {
            int[] p = new int[10];

            if (a < 1000) { return false; }

            while (a!=0) {
                int b = a % 10;
                p[b]++;
                if (p[b] > 1) {
                    return false;
                }
                a = a / 10;
            }

            return true;
        }


        public void start() {
            //游戏开始的时候这个方法会被调用
            //返回值啥的我没有限定，反正你最后告诉我你返回值是啥意思就好
        }

        /*
        public void finish() {

        }


        public void isfinish() {

        }

        public int judge(int a) {
            return 40;
        }
        */


        public void submit(int a) {
            //用户提交答案尝试的时候这个方法会被调用
            //返回值啥的我没有限定，反正你最后告诉我你返回值是啥意思就好

        }
    }
}
