#nullable disable warnings
using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace TicTacToe.Providers
{
    public class ConsoleProviderFactory
    {
        private readonly IDictionary<string, IConsoleProvider> _consoleProviders;

        public ConsoleProviderFactory(PlayerStateContainer playerStateContainer)
        {
            Type consoleProviderType = typeof(IConsoleProvider);
            
            _consoleProviders = consoleProviderType.Assembly.ExportedTypes
                     .Where(x => consoleProviderType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                     .Select(t => (IConsoleProvider)Activator.CreateInstance(t, playerStateContainer))
                     .ToImmutableDictionary(x => ((IConsoleProvider)x).Name, x => (IConsoleProvider)x);
        }

        public IConsoleProvider GetProviderByClientName(string name)
        {
            IConsoleProvider provider = _consoleProviders.GetValueOrDefault(name);
            return provider;
        }

    }
}
