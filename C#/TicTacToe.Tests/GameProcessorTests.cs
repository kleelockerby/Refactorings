using TicTacToe.Enums;

namespace TicTacToe.Tests
{
    public class GameProcessorTests
    {
        private readonly GameProcessor? _sut;
        private readonly IBoardService _boardService = new BoardService();
        private readonly IGameValidations _gameValidations = Substitute.For<IGameValidations>();
        private readonly IFixture _fixture = new Fixture();

        public GameProcessorTests()
        {
            //_sut = new GameProcessor(_boardService, _gameValidations);
            _sut = new GameProcessor();
        }

        //Test Happy Path
        [Fact]
        public void CheckWinner_ReturnsTrue_ValidInput()
        {
            //Arrange
            FieldInfo? currentPlayerField = typeof(GameProcessor).GetField("_currentPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            currentPlayerField?.SetValue(_sut, CurrentPlayer.X);

            List<int> testboxes = new List<int>() { 1, 3, 5, 9 };
            MethodInfo? updateBox = typeof(GameProcessor).GetMethod("UpdateBoard", BindingFlags.NonPublic | BindingFlags.Instance);
            testboxes.ForEach(x => updateBox?.Invoke(_sut, new object[] { x }));

            MethodInfo? checkWinner = typeof(GameProcessor).GetMethod("CheckWinner", BindingFlags.NonPublic | BindingFlags.Instance);

            //Act
            _ = checkWinner?.Invoke(_sut, null)!;
            FieldInfo? isWinnerInfoField = typeof(GameProcessor).GetField("_isWinner", BindingFlags.NonPublic | BindingFlags.Instance);
            bool? isWinnerValue = (bool)isWinnerInfoField?.GetValue(_sut)!;

            //Assert
            isWinnerValue.ShouldBe(true);
        }

    }
}



/*
private CurrentPlayer _currentPlayer = CurrentPlayer.N;
var field = typeof(GameProcessor).GetField("_currentPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
field.SetValue(_sut, CurrentPlayer.X);

List<char> input = new List<char>();
List<char> boxes = new List<char> { GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty };


public void CheckWinner_ReturnsTrue_ValidInput()
{
    //Arrange
    FieldInfo? currentPlayerField = typeof(GameProcessor).GetField("_currentPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
    currentPlayerField?.SetValue(_sut, CurrentPlayer.X);

    List<int> testboxes = new List<int>() { 1, 3, 5, 9 };
    MethodInfo? updateBox = typeof(GameProcessor).GetMethod("UpdateBoard", BindingFlags.NonPublic | BindingFlags.Instance);
    testboxes.ForEach(x => updateBox?.Invoke(_sut, new object[] { x }) );

    MethodInfo? checkWinner = typeof(GameProcessor).GetMethod("CheckWinner", BindingFlags.NonPublic | BindingFlags.Instance);

    //Act
    _ = checkWinner?.Invoke(_sut, null)!;
    FieldInfo? isWinnerInfoField = typeof(GameProcessor).GetField("_isWinner", BindingFlags.NonPublic | BindingFlags.Instance);
    bool? isWinnerValue = (bool)isWinnerInfoField?.GetValue(_sut)!;

    //Assert
    isWinnerValue.ShouldBe(true);
}

*/