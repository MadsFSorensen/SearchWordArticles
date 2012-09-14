using System.Collections.Generic;
using System.Linq;

namespace MzM.SearchWordArticles.Web.Models.SearchWord
{
	public class SearchWordListModel
	{
		public SearchWordListModel(IEnumerable<SearchWordModel> searchWords)
		{
			SearchWords = searchWords.ToList();
		}

		public List<SearchWordModel> SearchWords { get; private set; }

	}
}