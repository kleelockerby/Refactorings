using TicTacToe.Domain;
using TicTacToe.Enums;

namespace TicTacToe.Tests
{
    public class GameProcessorTests
    {
        private readonly GameProcessor? _sut;
        private readonly IBoardService _boardService = new BoardService();
        private readonly IGameValidations _gameValidations = Substitute.For<IGameValidations>();
        private readonly IFixture _fixture = new Fixture();
/*
        public GameProcessorTests()
        {
            _sut = new GameProcessor(_boardService, _gameValidations);
        }

        //Test Happy Path
        [Fact]
        public void CheckWinner_ReturnsTrue_ValidInput()
        {
            //Arrange
            FieldInfo? currentPlayerField = typeof(GameManager).GetField("_currentPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            currentPlayerField?.SetValue(_sut, CurrentPlayerType.X);

            List<int> testboxes = new List<int>() { 1, 3, 5, 9 };
            testboxes.ForEach(x => _boardService.UpdateBox(x - 1, CurrentPlayerType.X.ToString().First()));

            MethodInfo? checkWinner = typeof(GameManager).GetMethod("CheckWinner", BindingFlags.NonPublic | BindingFlags.Instance);

            //Act
            _ = checkWinner?.Invoke(_sut, null)!;
            FieldInfo? isWinnerInfoField = typeof(GameManager).GetField("_isWinner", BindingFlags.NonPublic | BindingFlags.Instance);
            bool? isWinnerValue = (bool)isWinnerInfoField?.GetValue(_sut)!;

            //Assert
            isWinnerValue.ShouldBe(true);
        }
*/
    }
}