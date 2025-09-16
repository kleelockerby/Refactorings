#nullable disable warnings
using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TicTacToe.Extensions;


namespace TicTacToe.Providers
{
    public class ConsoleProviderFactory
    {
        public readonly IDictionary<string, IConsoleProvider> _consoleProviders;

        public ConsoleProviderFactory()
        {
            Type consoleProviderType = typeof(IConsoleProvider);
            
            _consoleProviders = consoleProviderType.Assembly.ExportedTypes
                     .Where(x => consoleProviderType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                     .Select(t => (IConsoleProvider)Activator.CreateInstance(t))
                     .ToImmutableDictionary(x => ((IConsoleProvider)x).Name, x => (IConsoleProvider)x);
        }

        public IConsoleProvider GetProviderByClientName(string name)
        {
            IConsoleProvider provider = _consoleProviders.GetValueOrDefault(name);
            return provider;
        }

    }
}
