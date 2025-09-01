namespace TicTacToe.Tests
{
    public class BoardServiceTests
    {
        private readonly BoardService _sut;
        private readonly IBoardService _boardService = Substitute.For<IBoardService>();
        private IGameValidations _gameValidations = Substitute.For<IGameValidations>();

        public BoardServiceTests()
        {
            _sut = new BoardService(new List<char> { GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty });
        }

        //Test Happy Path
        public void TestBoardService_x_x()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
