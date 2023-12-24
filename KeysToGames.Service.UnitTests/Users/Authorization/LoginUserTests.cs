using IdentityModel.Client;
using KeysToGames.BL.Auth.Entities;
using KeysToGames.BL.UnitTests;
using KeysToGames.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using KeysToGames.DataAccess;
using FluentAssertions;

namespace KeysToGames.Service.UnitTests.Users.Authorization
{
   public class LoginUserTests : KeysToGamesTestBaseClass
    {
        [Test]
        public async Task SuccessFullResult()
        {
            // prepare: create new user (login, password) => execute (try to login) => assert (Success : access token, refresh token)
            //prepare
            var user = new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                Login = "test",
                PasswordHash =1,
                MoneyBalance = 0,
                CardNumber = "15125125"

            };
            var password = "Password1@";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
            var result = await userManager.CreateAsync(user, password);

            //execute
            var query = $"?login={user.UserName}&password={password}";
            var requestUri =
                KeysToGamesApiEndPoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseContentJson = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

            content.Should().NotBeNull();
            content.AccessToken.Should().NotBeNull();
            content.RefreshToken.Should().NotBeNull();

            //check that access token is valid

            var requestToGetAllTrainers =
                new HttpRequestMessage(HttpMethod.Get, KeysToGamesApiEndPoints.GetAllUsersEndpoint);

            var clientWithToken = TestHttpClient;
            client.SetBearerToken(content.AccessToken);
            var getAllUsersResponse = await client.SendAsync(requestToGetAllTrainers);

            getAllUsersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task BadRequestUserNotFoundResultTest()
        {
            // prepare: (imagine_login, imagine_password) => execute (try to login) => assert (BadRequest user not found)
            //prepare
            var login = "not_existing@mail.ru";
            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
            var user = userRepository.GetAll().FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
            if (user != null)
            {
                userRepository.Delete(user);
            }

            var password = "password";
            //100% confidence
            //execute
            var query = $"?email={login}&password={password}";
            var requestUri =
                KeysToGamesApiEndPoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await TestHttpClient.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task LoginWithWrongPasswordTest()
        {
            //prepare
            var user = new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                Login = "test",
                PasswordHash = 1,
                MoneyBalance = 0,
                CardNumber = "15125125"
            };
            var password = "Password1@";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();

            var findResult = await userManager.FindByNameAsync(user.UserName);
            if (findResult is null)
            {
                var result = await userManager.CreateAsync(user, password);
                result.Succeeded.Should().BeTrue(); 
            }
            var incorrect_password = "kvhdbkvhbk";

            //execute
            var query = $"?email={user.UserName}&password={incorrect_password}";
            var requestUri = KeysToGamesApiEndPoints.AuthorizeUserEndpoint + query;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        [TestCase("", "")]
        [TestCase("qwe", "")]
        [TestCase("test@test", "")]
        [TestCase("", "password")]
        public async Task LoginOrPasswordAreInvalidResultTest(string login, string password)
        {
            //execute
            var query = $"?login={login}&password={password}";
            var requestUri =
                KeysToGamesApiEndPoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=kvhdbkvhbk
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
        }
    }
}
