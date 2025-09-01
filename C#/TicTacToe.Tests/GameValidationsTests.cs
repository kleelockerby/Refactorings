namespace TicTacToe.Tests
{
    public class GameValidationsTests
    {
        private readonly GameValidations _sut;
        private readonly IBoardService _boardService = Substitute.For<IBoardService>();
        private IGameValidations _gameValidations = Substitute.For<IGameValidations>();

        public GameValidationsTests()
        {
            _sut = new GameValidations();
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
