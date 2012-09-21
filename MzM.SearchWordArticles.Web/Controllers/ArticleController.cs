using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MzM.SearchWordArticles.Web.Models.Article;

namespace MzM.SearchWordArticles.Web.Controllers
{
	public class ArticleController : Controller
	{
		public ActionResult Create(string id)
		{
			CreateViewModel viewModel = new CreateViewModel();
			viewModel.Words = new List<string> { id.ToLower() };
			return View(viewModel);
		}

		public ActionResult Edit(string id)
		{
			var article = MongoProvider.GetCollection<ArticleModel>().FindOneById(BsonValue.Create(id));
			return View(article);
		}
	}
}
