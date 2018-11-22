using System;

using Topshelf;

namespace MTConsoleBarista
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TopShelf
            HostFactory.Run(c =>
            {
                c.SetServiceName("BaristaService");
                c.SetDisplayName("Barista Service");
                c.SetDescription("a Mass Transit Barista Service");
                c.RunAsLocalSystem();
                c.StartAutomaticallyDelayed();

                c.Service<BaristaService>(s =>
                {
                    var uniqueinstance = Guid.NewGuid().ToString();
                    s.ConstructUsing(() => new BaristaService(uniqueinstance));
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o => o.Stop(uniqueinstance));
                });
            });
        }
    }
}

