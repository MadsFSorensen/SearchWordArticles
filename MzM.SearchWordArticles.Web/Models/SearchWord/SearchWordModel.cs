using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MzM.SearchWordArticles.Web.Models.SearchWord
{
	public class SearchWordModel : IMongoDBModel
	{
		public string Word { get; set; }
		public int Volume { get; set; }
		public string Id { get; private set; }
	    [BsonIgnore]
        public string Url { get; set; }
	    public string ArticleId { get; set; }

		public SearchWordModel(string word, int volume)
		{
			Id = Guid.NewGuid().ToString();
			Word = word;
			Volume = volume;
		}
	}
}