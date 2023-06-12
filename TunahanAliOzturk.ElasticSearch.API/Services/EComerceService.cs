﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;
using System.Net;
using TunahanAliOzturk.ElasticSearch.API.DTOs;
using TunahanAliOzturk.ElasticSearch.API.Models.SampleDataModels;
using TunahanAliOzturk.ElasticSearch.API.Repositories;

namespace TunahanAliOzturk.ElasticSearch.API.Services
{
    public class EComerceService
    {
        private readonly ECommerceRepossitory _repository;

        public EComerceService(ECommerceRepossitory repository)
        {
            _repository = repository;
        }

        public async Task<ImmutableList<ECommerce>> TermLevelQueryAsync(string customerFirstName)
        {
            return await _repository.TermLevelQueryAsync(customerFirstName);
        }
        public async Task<ImmutableList<ECommerce>> PrefixLevelQueryAsync(string customerFirstName)
        {
            return await _repository.PrefixLevelQueryAsync(customerFirstName);
        }
        public async Task<ImmutableList<ECommerce>> RangeLevelQueryAsync(double minPrice, double maxPrice)
        {
            return await _repository.RangeLevelQueryAsync(minPrice, maxPrice);
        }
        public async Task<ImmutableList<ECommerce>> RangeLevelQueryForDateAsync(DateTime minDate, DateTime maxDate)
        {
            return await _repository.RangeLevelQueryForDateAsync(minDate, maxDate);
        }
        public async Task<ImmutableList<ECommerce>> MatchAllLevelQueryAsync()
        {
            return await _repository.MatchAllLevelQueryAsync();
        }
        public async Task<ImmutableList<ECommerce>> Pagination(int page, int pageSize)
        {
            return await _repository.Pagination(page, pageSize);
        }
        public async Task<ImmutableList<ECommerce>> WilcardLevelQuery(string customerFullName)
        {
            return await _repository.WilcardLevelQuery(customerFullName);

        }
        public async Task<ImmutableList<ECommerce>> FuzzyLevelQuery(string customerFirstName)
        {
            return await _repository.FuzzyLevelQuery(customerFirstName);

        }
        public async Task<ImmutableList<ECommerce>> MatchFullTextQuery(string categoryName)
        {
            return await _repository.MatchFullTextQuery(categoryName);
        }



    }
}
