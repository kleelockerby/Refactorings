#nullable disable warnings
using TicTacToe.Enums;
using TicTacToe.Extensions;
using TicTacToe.Models;
using TicTacToe.Providers;

namespace TicTacToe.Tests
{
    public class GameProcessorTests
    {
        private readonly GameProcessor? sut;
        private readonly ConsoleProviderFactory consoleProviderFactory = new ConsoleProviderFactory();
        private readonly IPlayerStateContainer playerStateContainer = Substitute.For<IPlayerStateContainer>();
        private readonly IGameValidations gameValidations = Substitute.For<IGameValidations>();
        private readonly IFixture fixture = new Fixture();

        public GameProcessorTests()
        {
            sut = new GameProcessor(consoleProviderFactory, playerStateContainer, gameValidations);
        }

        [Fact]
        public void CheckWinnerX_ReturnsTrue_ValidInput()
        {
            //Arrange
            List<char> boxes = new List<char>() { 'X', 'Y', 'X', 'Y', 'X', 'Y', 'X', ' ', ' ' };

            FieldInfo? boxesField = typeof(GameProcessor).GetField("_boxes", BindingFlags.NonPublic | BindingFlags.Instance);

            var boxModel = fixture.Build<BoxModel>()
                            .With(x => x.Boxes , boxes)
                            .Create();

            boxesField.SetValue(sut, boxModel);

            PlayerState expectedState = new PlayerState(CurrentPlayerType.X, CurrentPlayerType.N, false);
            playerStateContainer.State = expectedState;

            //Act
            bool isWinner = sut.CheckWinner();

            //Assert
            isWinner.ShouldBeTrue();
        }

        [Fact]
        public void CheckWinnerY_ReturnsTrue_ValidInput()
        {
            //Arrange
            List<char> boxes = new List<char>() { 'Y', 'Y', 'X', 'X', 'Y', 'X', 'X', ' ', 'Y' };

            FieldInfo? boxesField = typeof(GameProcessor).GetField("_boxes", BindingFlags.NonPublic | BindingFlags.Instance);

            var boxModel = fixture.Build<BoxModel>()
                            .With(x => x.Boxes, boxes)
                            .Create();

            boxesField.SetValue(sut, boxModel);

            PlayerState expectedState = new PlayerState(CurrentPlayerType.Y, CurrentPlayerType.N, false);
            playerStateContainer.State = expectedState;

            //Act
            bool isWinner = sut.CheckWinner();

            //Assert
            isWinner.ShouldBeTrue();
        }

        [Fact]
        public void CheckWinnerX_ReturnsFalse_WrongUser()
        {
            List<char> boxes = new List<char>() { 'X', 'Y', 'X', 'Y', 'X', 'Y', 'X', ' ', ' ' };

            var boxModel = fixture.Build<BoxModel>()
                            .With(x => x.Boxes, boxes)
                            .Create();

            FieldInfo? boxesField = typeof(GameProcessor).GetField("_boxes", BindingFlags.NonPublic | BindingFlags.Instance);
            boxesField.SetValue(sut, boxModel);

            PlayerState expectedState = new PlayerState(CurrentPlayerType.Y, CurrentPlayerType.N, false);
            playerStateContainer.State = expectedState;

            bool isWinner = sut.CheckWinner();

            isWinner.ShouldBeFalse();
        }

        [Theory]
        [InlineData('X', 'Y', 'X', 'Y', 'X', 'Y', 'X', ' ', ' ')]
        [InlineData('X', 'X', 'Y', 'X', 'X', 'Y', 'Y', 'Y', 'X')]
        [InlineData('X', 'Y', 'X', 'Y', 'X', 'Y', ' ', ' ', 'X')]
        [InlineData('X', 'X', 'X', 'Y', 'X', ' ', 'Y', ' ', 'Y')]
        [InlineData('X', 'Y', ' ', 'X', ' ', ' ', 'X', 'Y', ' ')]
        public void CheckWinnerX_ReturnsTrue_DataSet(char c0, char c1, char c2, char c3, char c4, char c5, char c6, char c7, char c8 )
        {
            //Arrange
            List<char> boxes = new List<char>() { c0, c1, c2, c3, c4, c5, c6, c7, c8 };

            FieldInfo? boxesField = typeof(GameProcessor).GetField("_boxes", BindingFlags.NonPublic | BindingFlags.Instance);

            var boxModel = fixture.Build<BoxModel>()
                            .With(x => x.Boxes, boxes)
                            .Create();

            boxesField.SetValue(sut, boxModel);

            PlayerState expectedState = new PlayerState(CurrentPlayerType.X, CurrentPlayerType.N, false);
            playerStateContainer.State = expectedState;

            //Act
            bool isWinner = sut.CheckWinner();

            //Assert
            isWinner.ShouldBeTrue();
        }

        [Theory]
        [InlineData('Y', 'Y', 'X', 'X', 'Y', 'X', 'X', ' ', 'Y')]
        [InlineData('X', 'Y', 'X', 'X', 'Y', ' ', ' ', 'Y', ' ')]
        [InlineData('X', ' ', 'X', 'Y', 'Y', 'Y', ' ', ' ', 'X')]
        [InlineData('Y', 'X', 'Y', 'X', 'Y', 'X', 'X', ' ', 'Y')]
        [InlineData('X', 'Y', 'X', 'Y', 'Y', 'Y', 'X', 'X', ' ')]
        public void CheckWinnerY_ReturnsTrue_DataSet(char c0, char c1, char c2, char c3, char c4, char c5, char c6, char c7, char c8)
        {
            //Arrange
            List<char> boxes = new List<char>() { c0, c1, c2, c3, c4, c5, c6, c7, c8 };

            FieldInfo? boxesField = typeof(GameProcessor).GetField("_boxes", BindingFlags.NonPublic | BindingFlags.Instance);

            var boxModel = fixture.Build<BoxModel>()
                            .With(x => x.Boxes, boxes)
                            .Create();

            boxesField.SetValue(sut, boxModel);

            PlayerState expectedState = new PlayerState(CurrentPlayerType.Y, CurrentPlayerType.N, false);
            playerStateContainer.State = expectedState;

            //Act
            bool isWinner = sut.CheckWinner();

            //Assert
            isWinner.ShouldBeTrue();
        }

        [Theory]
        [InlineData('X', 'Y', 'Y', 'Y', 'X', 'X', 'X', 'X', 'Y')]
        [InlineData('Y', 'X', 'Y', 'Y', 'X', 'X', 'X', 'Y', 'X')]
        [InlineData('Y', 'X', 'X', 'X', 'X', 'Y', 'Y', 'Y', ' ')]
        [InlineData('X', 'Y', 'X', 'Y', 'X', 'Y', 'X', ' ', ' ')]
        public void CheckNoWinner_XandY(char c0, char c1, char c2, char c3, char c4, char c5, char c6, char c7, char c8)
        {
            //Arrange
            List<char> boxes = new List<char>() { c0, c1, c2, c3, c4, c5, c6, c7, c8 };

            FieldInfo? boxesField = typeof(GameProcessor).GetField("_boxes", BindingFlags.NonPublic | BindingFlags.Instance);

            var boxModel = fixture.Build<BoxModel>()
                            .With(x => x.Boxes, boxes)
                            .Create();

            boxesField.SetValue(sut, boxModel);

            PlayerState expectedStateX = new PlayerState(CurrentPlayerType.X, CurrentPlayerType.N, false);
            PlayerState expectedStateY = new PlayerState(CurrentPlayerType.Y, CurrentPlayerType.N, false);

            playerStateContainer.State = expectedStateX;
            bool isWinnerX = sut.CheckWinner();

            playerStateContainer.State = expectedStateY;
            bool isWinnerY = sut.CheckWinner();
            bool isWinnerAll = isWinnerX && isWinnerY;

            //Assert
            isWinnerAll.ShouldBeFalse();
        }

        [Fact]
        public void GameValidation_AreAllTrue()
        {
            string input = "5";
            int expectedIndex = 4;

            gameValidations
             .IsInRange(input, out Arg.Any<int>())
             .Returns(call =>
             {
                 call[1] = expectedIndex; // set out parameter
                 return true;
             });

            gameValidations.IsCorrectInputLength(input).Returns(true);
            gameValidations.IsVacant(Arg.Any<int>(), Arg.Any<BoxModel>()).Returns(true);

            object?[] parameters = { input, 0 };    //out parameters

            // Act
            var result = sut.CallPrivateMethod<(bool, string)>("ValidateInput", parameters);
            int actualIndex = (int)parameters[1]!;

            result.Item1.ShouldBeTrue();
            result.Item2.ShouldBeEmpty();
            actualIndex.ShouldBe(expectedIndex);

            gameValidations.Received(1).IsInRange(input, out Arg.Any<int>());
            gameValidations.Received(1).IsCorrectInputLength(input);
            gameValidations.Received(1).IsVacant(expectedIndex - 1, Arg.Any<BoxModel>());
        }
    }
}