using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Word
    {
        public string WordId { get; set; }
        public List<Results> Results { get; set; }
    }

    public class Results : IJoinCLasses
    {
        [Key]
        public int ResultsId { get; set; }
        public string Id { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Word { get; set; }
        public List<LexicalEntries> LexicalEntries { get; set; }
    }

    public class LexicalEntries : IJoinCLasses
    {
        [Key]
        public int Id { get; set; }
        public string Language { get; set; }
        public string LexicalCategory { get; set; }
        public string Text { get; set; }
        public List<Entries> Entries { get; set; }
        public List<GrammaticalFeatures> GrammaticalFeatures { get; set; }
        public List<InflectionOf> InflectionOf { get; set; }
    }

    public class InflectionOf : IJoinCLasses
    {
        [Key]
        public int InflectionOfId { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class Entries : IJoinCLasses
    {
        [Key]
        public int Id { get; set; }
        public List<GrammaticalFeatures> GrammaticalFeatures { get; set; }
        public List<Senses> Senses { get; set; }
    }

    public class GrammaticalFeatures : IJoinCLasses
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Senses : IJoinCLasses
    {
        [Key]
        public int SensesId { get; set; }
        public string Id { get; set; }
        public string Registers { get; set; }
        public List<Antonyms> Antonyms { get; set; }
        public List<Examlples> Examples { get; set; }
        public List<Synonyms> Synonyms { get; set; }
        
    }

    public class Antonyms : IJoinCLasses
    {
        [Key]
        public int AntonymsId { get; set; }
        public string Id { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }

    public class Examlples : IJoinCLasses
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class Synonyms : Antonyms
    {

    }

    interface IJoinCLasses
    {

    }
}
