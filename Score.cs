//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Uss_mäng
//{
//    class Score
//    {
//        private int score;
//        private List<int> scoreList;

//        public ScoreMng()
//        {
//            score = 0;
//            scoreList = new List<int>();
//            LoadS();
//        }

//        private void LoadS()
//        {
//            using (StreamReader reader = new StreamReader("scores.txt"))
//            {
//                string line;
//                while ((line = reader.ReadLine()) != null)
//                {
//                    if (int.TryParse(line, out int score))
//                    {
//                        scoreList.Add(score);
//                    }
//                }
//            }
//        }
//        public void AddS(int p)
//        {
//            score += p;
//        }

//        public void SaveS()
//        {
//            scoreList.Add(score);
//            scoreList.Sort();
//            scoreList.Reverse();
//            using (StreamWriter writer = new StreamWriter("scores.txt"))
//            {
//                foreach (int score in scoreList)
//                {
//                    writer.WriteLine(score);
//                }
//            }
//        }


//    }
//}

