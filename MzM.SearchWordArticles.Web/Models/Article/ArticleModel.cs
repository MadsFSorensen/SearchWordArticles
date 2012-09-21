using System;
using System.Collections.Generic;

namespace MzM.SearchWordArticles.Web.Models.Article
{
	public class ArticleModel : IMongoDBModel
	{
		public string Id { get; private set; }
		public string Text { get; set; }
		public List<string> SearchWordIds { get; set; }
		
		public ArticleModel()
		{
			Id = Guid.NewGuid().ToString();
		}
	}
}