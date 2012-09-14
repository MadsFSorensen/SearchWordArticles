using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using MongoDB.Driver;
using MzM.SearchWordArticles.Web.Models.SearchWord;

namespace MzM.SearchWordArticles.Web
{
	public class MongoProvider
	{
		private static readonly NameValueCollection Config = ConfigurationManager.AppSettings;
		private static readonly Dictionary<Type, string> DatabaseNameMap = new Dictionary<Type, string>
			{
				{typeof (SearchWordModel), typeof (SearchWordModel).Name}
			};

		public static MongoCollection<T> GetCollection<T>()
		{
			var type = typeof(T);
			if (!DatabaseNameMap.ContainsKey(type))
				throw new ArgumentException("Type " + type + " not mapped to a database name.");

			MongoDatabase mongoDatabase = GetDatabase();
			var collectionName = typeof(T).Name;

			if (!mongoDatabase.CollectionExists(collectionName))
				throw new Exception(String.Format("Could not find a MongoCollection called {0}", collectionName));

			return mongoDatabase.GetCollection<T>(collectionName);
		}

		private static MongoDatabase GetDatabase()
		{
			MongoDatabase mongoDatabase = MongoServer.Create(Config["MzM.MongoDB.Connection"]).GetDatabase(Config["MzM.MongoDB.Database"]);
			return mongoDatabase;
		}
	}
}