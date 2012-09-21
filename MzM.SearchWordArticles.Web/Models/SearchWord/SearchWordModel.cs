using System;

namespace MzM.SearchWordArticles.Web.Models.SearchWord
{
	public class SearchWordModel : IMongoDBModel
	{
		public string Id { get; private set; }
		public string ArticleId { get; set; }
		public string Word { get; private set; }
		public int Volume { get; private set; }

		public SearchWordModel(string word, int volume)
		{
			Id = word.ToLower();
			Word = word;
			Volume = volume;
		}
	}
}