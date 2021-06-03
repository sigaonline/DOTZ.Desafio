using DOTZ.Desafio.Model.Dto;
using DOTZ.Desafio.Model.Request;
using DOTZ.Desafio.Model.Result;
using DOTZ.Desafio.MStest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DOTZ.Desafio.MStest.Tests
{
    [TestClass]
    public class ProductController_CreateTests
    {
        private ApiFixture fixture;
        private const string url = "api/product";
        private const string urlToken = "api/login";

        private string token;
        [TestInitialize]
        public async Task Setup()
        {
            if (fixture == null)
            {
                fixture = new ApiFixture();
                token = await Token();
                fixture.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        [TestMethod]
        public async Task Success_GetUserById()
        {
            var resp = await fixture.client.GetAsync(url + "/id/1");
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
        }

        [TestMethod]
        public async Task Error_GetUserById()
        {
            var resp = await fixture.client.GetAsync(url + "/id/13564");
            Assert.AreEqual(HttpStatusCode.NoContent, resp.StatusCode);
        }

        [TestMethod]
        public async Task Success_Post()
        {

            var ProductRequest = new ProductDto
            {
                Description = Guid.NewGuid().ToString(),
                PointsValue = 12345
            };
            var contentProductRequest = fixture.ConvertToRawJson(ProductRequest);
            var responseProductRequest = await fixture.client.PostAsync(url, contentProductRequest);
            string responseHtml = await responseProductRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);
            
            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.OK, responseProductRequest.StatusCode);
        }


        [TestMethod]
        public async Task Error_SizeState_Post()
        {

            var locationRequest = new ProductDto
            {
                Description = "asfasd asdfasda sdfasd asdfasd fasdf asdfasdf asdfsd asfasd asdfasda sdfasd asdfasd fasdf asdfasdf asdfsdasfasd asdfasda sdfasd asdfasd fasdf asdfasdf asdfsdasfasd asdfasda sdfasd asdfasd fasdf asdfasdf asdfsdasfasd asdfasda sdfasd asdfasd fasdf asdfasdf asdfsd",
                PointsValue = 12345
            };
            var contentUserRequest = fixture.ConvertToRawJson(locationRequest);
            var responseLocationRequest = await fixture.client.PostAsync(url, contentUserRequest);
            string responseHtml = await responseLocationRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<ErrorsValidate>(responseHtml);
            
            Assert.IsNotNull(resposta);

            string mensagem = string.Empty;
            foreach (var item in resposta.Errors.Description)
            {
                mensagem = item;
                break;
            }

            
            Assert.AreEqual("Descrião do produto ultrapassa o tamanho permitido!", mensagem);
        }

        [TestMethod]
        public async Task Error_Post()
        {

            var productRequest = new ProductDto
            {
                PointsValue = 12345
            };
            var contentProductRequest = fixture.ConvertToRawJson(productRequest);
            var responseProductRequest = await fixture.client.PostAsync(url, contentProductRequest);
            string responseHtml = await responseProductRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseProductRequest.StatusCode);
        }

        [TestMethod]
        public async Task Success_Put()
        {

            var productRequest = new ProductDto
            {
                Id = 1,
                Description = "Alterando Produto",
                PointsValue = 12345
            };
            var contentProductRequest = fixture.ConvertToRawJson(productRequest);
            var responseProductRequest = await fixture.client.PutAsync(url, contentProductRequest);
            string responseHtml = await responseProductRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.OK, responseProductRequest.StatusCode);
        }

        [TestMethod]
        public async Task Error_Put()
        {

            var produtRequest = new ProductDto
            {
                PointsValue = 12345
            };
            var contentProductRequest = fixture.ConvertToRawJson(produtRequest);
            var responseProductRequest = await fixture.client.PutAsync(url, contentProductRequest);
            string responseHtml = await responseProductRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseProductRequest.StatusCode);
        }



        private async Task<string> Token()
        {
            var token = new LoginRequesty
            {
                Password = "Admin",
                UserName = "Admin"
            };
            var contentToken = fixture.ConvertToRawJson(token);
            var respToken = await fixture.client.PostAsync(urlToken, contentToken);
            string responseHtml = await respToken.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            return resposta.Token;

        }
    }
}
