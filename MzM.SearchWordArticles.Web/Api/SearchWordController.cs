using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MzM.SearchWordArticles.Web.Models.SearchWord;

namespace MzM.SearchWordArticles.Web.Api
{
	public class SearchWordController : ApiController
	{
		[AllowAnonymous]
		public IEnumerable<SearchWordModel> GetSearchWords()
		{
			var searchWords = MongoProvider.GetCollection<SearchWordModel>().FindAll();
			return searchWords.ToList();
		}

		public HttpResponseMessage PostSearchWords(SearchWordModel searchWordModel)
		{
			MongoProvider.GetCollection<SearchWordModel>().Save(searchWordModel);
			var response = Request.CreateResponse<SearchWordModel>(HttpStatusCode.Created, searchWordModel);
			return response;
		}
	}
}
