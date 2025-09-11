using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Providers
{
    public class ConsoleProviderBase
    {
        protected readonly PlayerStateContainer PlayerStateContainer;

        //public ConsoleProviderBase() : this(new PlayerStateContainer()) { }
        // public ConsoleProviderBase(PlayerStateContainer playerStateContainer) { _playerStateContainer = playerStateContainer; }
        public ConsoleProviderBase(PlayerStateContainer playerStateContainer) => PlayerStateContainer = playerStateContainer;

        public PlayerStateContainer GetStateContainer()
        {
            return PlayerStateContainer;
        }
    }
}
