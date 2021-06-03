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
    public class UserController_CreateTests
    {
        private ApiFixture fixture;
        private const string url = "api/user";
        private const string urlToken = "api/login";

        private string token;
        [TestInitialize]
        public async Task Setup()
        {
            fixture = new ApiFixture();
            token = await Token();
            fixture.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

            var userRequest = new UserRequest
            {
                UserName = Guid.NewGuid().ToString(),
                Password = "teste",
                Role = Model.UserRoles.Admin
            };
            var contentUserRequest = fixture.ConvertToRawJson(userRequest);
            var responseUserRequest = await fixture.client.PostAsync(url, contentUserRequest);
            string responseHtml = await responseUserRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);
            
            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.OK, responseUserRequest.StatusCode);
        }

        [TestMethod]
        public async Task Error_Password_Post()
        {

            var userRequest = new UserRequest
            {
                UserName = Guid.NewGuid().ToString(),
                Password = "teste sfasfsd fsadf asdf asdf sdf asdfasdfasd asdfasdf sdf asdfasdf asdasdf asdf asdfasdf asdf asdfasd asdf asdf asdf asdf asdf asd asd asdf asd",
                Role = Model.UserRoles.Admin
            };
            var contentUserRequest = fixture.ConvertToRawJson(userRequest);
            var responseUserRequest = await fixture.client.PostAsync(url, contentUserRequest);
            string responseHtml = await responseUserRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<ErrorsValidate>(responseHtml);

            Assert.IsNotNull(resposta);

            string mensagem = string.Empty;
            foreach (var item in resposta.Errors.Password)
            {
                mensagem = item;
                break;
            }
            
            Assert.AreEqual("Senha do úsuario ultrapassa o tamanho permitido!", mensagem);
        }

        [TestMethod]
        public async Task Error_Post()
        {

            var userRequest = new UserRequest
            {
                UserName = "Admin",
                Role = Model.UserRoles.Admin
            };
            var contentUserRequest = fixture.ConvertToRawJson(userRequest);
            var responseUserRequest = await fixture.client.PostAsync(url, contentUserRequest);
            string responseHtml = await responseUserRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseUserRequest.StatusCode);
        }

        [TestMethod]
        public async Task Success_Put()
        {

            var userRequest = new UserRequest
            {
                Id = 2,
                UserName = Guid.NewGuid().ToString(),
                Password = "teste",
                Role = Model.UserRoles.Admin
            };
            var contentUserRequest = fixture.ConvertToRawJson(userRequest);
            var responseUserRequest = await fixture.client.PutAsync(url, contentUserRequest);
            string responseHtml = await responseUserRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.OK, responseUserRequest.StatusCode);
        }

        [TestMethod]
        public async Task Error_Put()
        {

            var userRequest = new UserRequest
            {
                Id = 1,
                UserName = "Admin",
                Role = Model.UserRoles.Admin
            };
            var contentUserRequest = fixture.ConvertToRawJson(userRequest);
            var responseUserRequest = await fixture.client.PutAsync(url, contentUserRequest);
            string responseHtml = await responseUserRequest.Content.ReadAsStringAsync();
            var resposta = JsonConvert.DeserializeObject<UserResult>(responseHtml);

            Assert.IsNotNull(resposta);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseUserRequest.StatusCode);
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
