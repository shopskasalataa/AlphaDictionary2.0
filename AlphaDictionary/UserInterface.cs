using Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class WordGetter
    {

        public static Word GetWordFromDb(string wordId)
        {
            return WordsBusiness.Get(wordId);
        }

        public static void GetWordByEntries(string wordId, string language)
        {
            APIQueries.GetEntries(language, wordId);
        }

        public static void GetWordByLemmasInflections(string wordId, string language)
        {
            APIQueries.GetLemmasInflections(language, wordId);
        }

        public static void GetWordSynonymsAntonyms(string wordId, string language)
        {
            APIQueries.GetSynonymsAntonyms(language, wordId);
        }

        public static void ExecuteRequests()
        {
            try
            {
                APIQueries.MakeRequest();
                string json = APIQueries.GetResponse();
                Word word = UserInterface.ConvertJsonToObject(json);
                WordsBusiness.Add(word);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public static class UserInterface
    {
        public static StringBuilder stringBuilder = new StringBuilder();

        public static string GetWord(string wordId, string lang)
        {
            
            Word word = WordGetter.GetWordFromDb(wordId);
            if (word != default(Word))
            {
                //send to the controller to be displayed
                return Displayer<object>(word.Results);
            }
            else
            {
                string json = APIQueries.GetEntries(lang, wordId);
                word = ConvertJsonToObject(json);
                WordsBusiness.Add(word);
                // send to the controller to be displayed
                return Displayer<IJoinCLasses>(word.Results);
            }
        }

        public static Word ConvertJsonToObject(string json)
        {
            var WordFromJson = JsonConvert.DeserializeObject<Word>(json);
            WordFromJson.WordId = WordFromJson.Results[0].Id;
            return WordFromJson;
        }

        private static string Displayer<T>(object list)
        {
            foreach (var item in (List<T>)list)
            {
                if (item is string)
                {
                    stringBuilder.Append(item.ToString());
                    stringBuilder.AppendLine();

                }
                else
                {
                    stringBuilder.Append(item.ToString());
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine();
                    Displayer<T>(item);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
