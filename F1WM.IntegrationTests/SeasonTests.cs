﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1WM.ApiModel;
using F1WM.Controllers;
using Newtonsoft.Json;
using Xunit;
namespace F1WM.IntegrationTests
{
    public class SeasonTests : IntegrationTestBase
    {
        [Fact]
        public async Task GetSeasonRulesTest()
        {
            var nowAtRequestTime = DateTime.Now;
            var response = await client.GetAsync($"{baseAddress}/Season/rules?year=2016");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var seasonRules = JsonConvert.DeserializeObject<SeasonRules>(responseContent);
            Assert.False(string.IsNullOrWhiteSpace(seasonRules.CarWeight));
            Assert.False(string.IsNullOrWhiteSpace(seasonRules.EngineRules));
            Assert.False(string.IsNullOrWhiteSpace(seasonRules.PointsSystem));
            Assert.False(string.IsNullOrWhiteSpace(seasonRules.QualRules));
        }
    }
}