using Data;
using Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class WordsBusiness
    {
        private static WordsContext wordsContext;

        public static Word Get(string wordId)
        {
            using (wordsContext = new WordsContext())
            {
                foreach (var item in wordsContext.Words)
                {
                    if (item.WordId == wordId)
                    {
                        return item;
                    }

                }
                return default(Word);
            }
        }

        public static void Add(Word word)
        {
            using (wordsContext = new WordsContext())
            {
                wordsContext.Words.Add(word);
                wordsContext.SaveChanges();
            }
        }

        public static void Delete(string wordId)
        {
            using (wordsContext = new WordsContext())
            {
                foreach (var item in wordsContext.Words)
                {
                    if (item.WordId == wordId)
                    {
                        wordsContext.Words.Remove(item);
                        wordsContext.SaveChanges();
                    }

                }
            }
        }
    }
}
