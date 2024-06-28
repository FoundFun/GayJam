using UnityEngine;

namespace GlobalComponents
{
    public static class Score
    {
        private const string BestScoreKey = "BestScore";
        private const string CurrentScoreKey = "CurrentScore";
        private const string BenchPressScoreKey = "BenchPressScore";
        private const string PressScoreKey = "PressScore";
        private const string PullUpsScoreKey = "PullUpsScore";
        private const string RunScoreKey = "RunScore";

        public static int BestScore
        {
            get => PlayerPrefs.GetInt(BestScoreKey);
            set
            {
                if (CurrentScore > BestScore)
                {
                    PlayerPrefs.SetInt(BestScoreKey, value);
                }
            }
        }

        public static int CurrentScore
        {
            get => PlayerPrefs.GetInt(CurrentScoreKey);
            set => PlayerPrefs.SetInt(CurrentScoreKey, value);
        }

        public static int BenchPressScore
        {
            get => PlayerPrefs.GetInt(BenchPressScoreKey);
            set => PlayerPrefs.SetInt(BenchPressScoreKey, value);
        }
        
        public static int PressScore
        {
            get => PlayerPrefs.GetInt(PressScoreKey);
            set => PlayerPrefs.SetInt(PressScoreKey, value);
        }
        
        public static int PullUpsScore
        {
            get => PlayerPrefs.GetInt(PullUpsScoreKey);
            set => PlayerPrefs.SetInt(PullUpsScoreKey, value);
        }
        
        public static int RunScore
        {
            get => PlayerPrefs.GetInt(RunScoreKey);
            set => PlayerPrefs.SetInt(RunScoreKey, value);
        }

        public static void GameOver()
        {
            PlayerPrefs.DeleteKey(BenchPressScoreKey);
            PlayerPrefs.DeleteKey(PressScoreKey);
            PlayerPrefs.DeleteKey(PullUpsScoreKey);
            PlayerPrefs.DeleteKey(RunScoreKey);
            PlayerPrefs.DeleteKey(CurrentScoreKey);
        }
    }
}