using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MineSweeper
{
    class Database
    {
        
        private List<TimeSpan> highscoreList = new List<TimeSpan>();

        private string Highscores = "DataBase.txt";
        private string Helpwhatdo = "helpwhatdo.txt";
        private StreamWriter OutputStream;
        private StreamReader InputStream;
        private TimeSpan highscore;
        int size = 0;


        public int InputHandler()
        {
            string FullPath = Highscores;
            if (File.Exists(FullPath))
            {
                InputStream = new StreamReader(FullPath);

                size =  int.Parse(InputStream.ReadLine());
                
                for (int DataIndex = 0; DataIndex < size; ++DataIndex)
                {
                    highscore = new TimeSpan(0, int.Parse(InputStream.ReadLine()), int.Parse(InputStream.ReadLine()));
                    highscoreList.Add(highscore);
                }
                InputStream.Close();
                return 1;
            }
            return 0;
        }
        
        public void OutputHandler(List<TimeSpan> outputnames,TimeSpan newscore)
        {

            string FullPath = Highscores;
            OutputStream = new StreamWriter(FullPath);
            OutputStream.WriteLine(outputnames.Count);
            for(int DataIndex = 0; DataIndex < 10; ++DataIndex)
            {
                if (newscore > outputnames[DataIndex])
                {
                    OutputStream.WriteLine(newscore.Minutes);
                    OutputStream.WriteLine(newscore.Seconds);
                }
                else
                    OutputStream.WriteLine(highscoreList[DataIndex].Minutes);
                    OutputStream.WriteLine(highscoreList[DataIndex].Seconds);
            }
            OutputStream.Close();
        }
        
        public List<TimeSpan> GetHighscores()
        {
            return highscoreList;
        }

    }
}

