using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MzM.SearchWordArticles.Web.Models.Article;
using MzM.SearchWordArticles.Web.Models.SearchWord;

namespace MzM.SearchWordArticles.Web.Api
{
	public class ArticleController : ApiController
	{
		public HttpResponseMessage Post(ArticleModel articleModel)
		{
			MongoProvider.GetCollection<ArticleModel>().Save(articleModel);
			SearchWordModel searchWord = MongoProvider.GetCollection<SearchWordModel>().FindOneById(BsonValue.Create(articleModel.SearchWordIds.First().ToLower()));
			searchWord.ArticleId = articleModel.Id;
			MongoProvider.GetCollection<SearchWordModel>().Save(searchWord);
			var response = Request.CreateResponse(HttpStatusCode.Created, articleModel);
			return response;
		}
	}
}
