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
    public class LocationController_CreateTests
    {
        private ApiFixture fixture;
        private const string url = "api/location";
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

            var locationRequest = new LocationDto
            {
                UserId = 1,
                PostalCode = "72145 - 902",
                Street = "SAGOCA",
                Number = "1",
                Complement = "RESIDENCIAL ITAMARATY",
                District = "SETOR M NORTE",
                State = "DF",
                City = "BRASILIA",
                Phone = "62 981246386"
            };
            var contentUserRequest = fixture.ConvertToRawJson(locationRequest);
            var responseLocationRequest = await fixture.client.PostAsync(url, contentUserRequest);
            string responseHtml = await responseLocationRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);
            
            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.OK, responseLocationRequest.StatusCode);
        }


        [TestMethod]
        public async Task Error_SizeState_Post()
        {

            var locationRequest = new LocationDto
            {
                UserId = 1,
                PostalCode = "72145 - 902",
                Street = "SAGOCA",
                Number = "1",
                Complement = "RESIDENCIAL ITAMARATY",
                District = "SETOR M NORTE",
                State = "DFasfsdf dsfaf asdf asdf asdfasd asdf asdf adas dfasd",
                City = "BRASILIA",
                Phone = "62 981246386"
            };
            var contentUserRequest = fixture.ConvertToRawJson(locationRequest);
            var responseLocationRequest = await fixture.client.PostAsync(url, contentUserRequest);
            string responseHtml = await responseLocationRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<ErrorsValidate>(responseHtml);
            
            Assert.IsNotNull(resposta);

            string mensagem = string.Empty;
            foreach (var item in resposta.Errors.State)
            {
                mensagem = item;
                break;
            }

            
            Assert.AreEqual("Estado ultrapassa o tamanho permitido!", mensagem);
        }

        [TestMethod]
        public async Task Error_Post()
        {

            var locationRequest = new LocationDto
            {
                UserId = 1,
                PostalCode = "72145 - 902",
                Street = "SAGOCA",
                Number = "1",
                Complement = "RESIDENCIAL ITAMARATY",
 
                Phone = "62 981246386"
            };
            var contentLocationRequest = fixture.ConvertToRawJson(locationRequest);
            var responseLocationRequest = await fixture.client.PostAsync(url, contentLocationRequest);
            string responseHtml = await responseLocationRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseLocationRequest.StatusCode);
        }

        [TestMethod]
        public async Task Success_Put()
        {

            var locationRequest = new LocationDto
            {
                Id = 1,
                UserId = 1,
                PostalCode = "72145 - 902",
                Street = "SAGOCA",
                Number = "1",
                Complement = "RESIDENCIAL ITAMARATY",
                District = "SETOR M NORTE",
                State = "DF",
                City = "BRASILIA",
                Phone = "62 981246386"
            };
            var contentLocationRequest = fixture.ConvertToRawJson(locationRequest);
            var responseUserRequest = await fixture.client.PutAsync(url, contentLocationRequest);
            string responseHtml = await responseUserRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.OK, responseUserRequest.StatusCode);
        }

        [TestMethod]
        public async Task Error_Put()
        {

            var locationRequest = new LocationDto
            {
                Id = 1,
                UserId = 1,
                District = "SETOR M NORTE",
                State = "DF",
                City = "BRASILIA",
                Phone = "62 981246386"
            };
            var contentLocationRequest = fixture.ConvertToRawJson(locationRequest);
            var responseLocationRequest = await fixture.client.PutAsync(url, contentLocationRequest);
            string responseHtml = await responseLocationRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseLocationRequest.StatusCode);
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
