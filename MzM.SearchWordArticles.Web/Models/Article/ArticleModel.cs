using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MzM.SearchWordArticles.Web.Models.Article
{
    public class ArticleModel : IMongoDBModel
    {
        public string Id { get; private set; }

        public ArticleModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}