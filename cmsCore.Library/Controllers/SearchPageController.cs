﻿using cmsCore.Library.Models;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using cmsCore.Library.Models.ViewModels;
using cmsCore.Library.Services;
using System.Collections.Generic;

namespace cmsCore.Library.Controllers
{
    public class SearchPageController : RenderMvcController
    {
        private readonly ISearchService _searchService;
        private readonly IDataTypeValueService _dataTypeValueService;
        public string[] DocTypeAliases { get; set; }

        public SearchPageController(ISearchService searchService, IDataTypeValueService dataTypeValueService)
        {
            _searchService = searchService;
            _dataTypeValueService = dataTypeValueService;
            DocTypeAliases = new[] { "blogpost", "contentPage" };
        }

        public ActionResult Index(ContentModel model, string query, string page, string category)
        {
            var searchPageModel = new SearchContentModel(model.Content);

            IEnumerable<SelectListItem> categories =
                _dataTypeValueService.GetItemsFromValueListDataType("[MULTICHECKBOXLIST] Search Category List", null);

            var searchViewModel = new SearchViewModel()
            {
                Query = query,
                Category = category,
                Page = page,
                Categories = categories
            };

            if (!int.TryParse(page, out var pageNumber))
            {
                pageNumber = 1;
            }

            var searchResults = _searchService.GetPageOfContentSearchResults(query, category,
                pageNumber, out var totalItemCount, DocTypeAliases);

            searchPageModel.SearchViewModel = searchViewModel;
            searchPageModel.SearchResults = searchResults;

            return CurrentTemplate(searchPageModel);
        }
    }
}