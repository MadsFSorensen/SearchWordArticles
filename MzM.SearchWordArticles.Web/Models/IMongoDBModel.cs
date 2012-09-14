using MongoDB.Bson.Serialization.Attributes;

namespace MzM.SearchWordArticles.Web.Models
{
	public interface IMongoDBModel
	{
		[BsonId]
		string Id { get; }
	}
}
