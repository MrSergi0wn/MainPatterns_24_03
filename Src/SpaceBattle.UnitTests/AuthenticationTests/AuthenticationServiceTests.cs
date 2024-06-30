using System.Collections.Concurrent;
using FluentAssertions;
using SpaceBattle.Actions;
using SpaceBattle.Authentication;
using System.Numerics;
using Moq;
using SpaceBattle.Commands;
using SpaceBattle.Commands.Simple;
using SpaceBattle.Ioc;
using SpaceBattle.MessageBus;
using SpaceBattle.Server;

namespace SpaceBattle.UnitTests.AuthenticationTests
{
    public class AuthenticationServiceTests
    {
        private IAuthenticationService authenticationService;

        public AuthenticationServiceTests()
        {
            this.authenticationService = new AuthenticationService();
        }

        [Theory]
        [InlineData(1, "FirstUser", true)]
        [InlineData(1, "SecondUser", false)]
        [InlineData(3, "ThirdUser", true)]
        [InlineData(4, "User321", false)]
        [InlineData(55, "FifthUser", false)]
        public void ValidateAuthenticationUserJwtTest(int userId, string userName, bool validationResult)
        {
            this.authenticationService = new AuthenticationService();

            var userAuthenticationJwt = this.authenticationService.GetUserAuthenticationJwt(userId, userName);

            this.authenticationService.ValidateToken(userAuthenticationJwt).Should().Be(validationResult);
        }

        [Theory]
        [InlineData(1, "FirstUser", true)]
        [InlineData(1, "SecondUser", false)]
        [InlineData(3, "ThirdUser", true)]
        [InlineData(4, "User321", false)]
        [InlineData(55, "FifthUser", false)]
        public void CreateNewSpaceBattleGameForAuthenticatedUsersTest(int userId, string userName, bool validationResult)
        {
            this.authenticationService = new AuthenticationService();

            var spaceBattleId = this.authenticationService.SpaceBattleRegister(
                this.authenticationService.GetUserAuthenticationJwt(userId, userName), new[] { 1, 3, 5 });

            (spaceBattleId != 0).Should().Be(validationResult);
        }

        [Theory]
        [InlineData(1, "FirstUser", true)]
        [InlineData(1, "SecondUser", false)]
        [InlineData(3, "ThirdUser", true)]
        [InlineData(4, "User321", false)]
        [InlineData(55, "FifthUser", false)]
        public void ValidateAuthenticationSpaceBattleGameJwtTest(int userId, string userName, bool validationResult)
        {
            this.authenticationService = new AuthenticationService();

            var userAuthenticationToken = this.authenticationService.GetUserAuthenticationJwt(1, "FirstUser");

            var spaceBattleId = this.authenticationService.SpaceBattleRegister(userAuthenticationToken, new[] { 1, 3, 5 });

            userAuthenticationToken = this.authenticationService.GetUserAuthenticationJwt(userId, userName);

            var spaceBattleAuthenticationJwt =
                this.authenticationService.GetStarBattleAuthorizationJwt(spaceBattleId, userAuthenticationToken);

            this.authenticationService.ValidateToken(spaceBattleAuthenticationJwt).Should().Be(validationResult);
        }

        [Theory]
        [InlineData(1, "FirstUser", true)]
        [InlineData(10, "SecondUser", false)]
        public void ConfirmThatGameServerExecutedAuthenticatedUsersCommandsInSpaceBattle(int userId, string userName, bool validationResult)
        {
            this.authenticationService = new AuthenticationService();
            var userAuthenticationToken = this.authenticationService.GetUserAuthenticationJwt(1, "FirstUser");
            var spaceBattleId = this.authenticationService.SpaceBattleRegister(userAuthenticationToken, new []{1, 2, 3, 4, 5});
            userAuthenticationToken = this.authenticationService.GetUserAuthenticationJwt(userId, userName);
            var spaceBattleAuthenticationToken = this.authenticationService.GetStarBattleAuthorizationJwt(spaceBattleId, userAuthenticationToken);

            var movableObject = new Mock<IMovable>();
            movableObject.SetupGet(mo => mo.Position).Returns(new Vector2(10, 3));
            movableObject.SetupGet(mo => mo.Velocity).Returns(new Vector2(-7, 2));

            var ioc = new IoContainer();
            ioc.Resolve<ICommand>("IoC.Register",
                "Services.Authentication",
                (Func<object[], object>)(_ => this.authenticationService)
            ).Execute();
            ioc.Resolve<ICommand>("IoC.Register",
                $"Objects.Id_Number_{userId}",
                (Func<object[], object>)(_ => movableObject.Object)
            ).Execute();
            ioc.Resolve<ICommand>("IoC.Register",
                "Commands.Move",
                (Func<object[], object>)(args => new MoveCommand((IMovable)args[0]))
            ).Execute();

            var gameServer = new GameServer(ioc, new ConcurrentQueue<ICommand>());
            gameServer.RunMultithreadCommands();
            var gameMessage = new GameMessage
            {
                GameId = 1,
                GameObjectId = $"Objects.Id_Number_{userId}",
                GameOperationId = "Commands.Move",
                ArgsJson = spaceBattleAuthenticationToken
            };
            gameServer.AuthenticReceiveMessage(gameMessage);

            movableObject.VerifySet(mo => mo.Position = new Vector2(3, 5), validationResult ? Times.Once : Times.Never);
        }

    }
}
