using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MTConsoleCashier
{
    class Program
    {
        static void Main(string[] args)
        {
            // TopShelf
            HostFactory.Run(c =>
            {
                c.SetServiceName("CashierService");
                c.SetDisplayName("Cashier Service");
                c.SetDescription("a Mass Transit cashier Service");

                c.RunAsLocalSystem();
                c.StartAutomaticallyDelayed();

                c.Service<CashierService>(s =>
                {
                    s.ConstructUsing(() => new CashierService());
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o => o.Stop());
                });
            });
        
    }
    }
}
