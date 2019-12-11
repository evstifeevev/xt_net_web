using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Task0302
    {
        public static void ConsoleInterface()
        {
            var list = new WordFrequency<float>("Peter Piper picked a peck of pickled peppers. "+
                "A peck of pickled peppers Peter Piper picked. If Peter Piper picked a peck of pickled peppers, "+
                "Where's the peck of pickled peppers Peter Piper picked?");
            for (int i=0;i<list.Count;i++) 
            {
                Console.WriteLine($"Frequency of the word \"{list.Words[i]}\" is {list[i]}");
            }
            
        }
    }
    class WordFrequency<T> : IEnumerable<T>
        where T:IComparable
    {
        float[] wordsFrequencies = new float[0];
        public List<string> Words = null;
        private char[] _separators = { ' ', '.' };
        public int Count { get { return wordsFrequencies.Length; } }
        public WordFrequency(string text) 
           
        {
            List<string> differentWords = new List<string>();
            var temp = text.Split(_separators);
            for(int i=0;i< temp.Length;i++)
            {
                temp[i]=temp[i].ToLower(); 
            }
            List<int> amount = new List<int>();
            for (int i = 0; i < temp.Length; i++)
            {
                int count = wordCount(temp[i], temp);
                if (!differentWords.Contains(temp[i]))
                    differentWords.Add(temp[i]);
            }
            wordsFrequencies = new float[differentWords.Count];
            Words = differentWords;
            for (int i = 0; i < differentWords.Count; i++) 
            {
                wordsFrequencies[i] = Frequency(differentWords[i], differentWords);
            }
            
        }
        private static int wordCount<U>(U word, U[] words)
            where U : IComparable
        {
            int result = 0;
            for (int i = 0; i < words.Length; i++)
                if (word.CompareTo(words[i])==0)
                    result++;
            return result;

        }
        private static float Frequency<U>(U word, List<U> words)
            where U : IComparable
        {
            float result = 0;
            
            for (int i = 0; i < words.Count; i++)
                if (word.CompareTo(words[i]) == 0)
                    result++;
            return  result / words.Count;

        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return wordsFrequencies.GetEnumerator();
        }
        public float this[int index]
        {
            get
            {
                return wordsFrequencies[index];
            }
            set
            {
                wordsFrequencies[index] = value;
            }
        }
    }
   
}
