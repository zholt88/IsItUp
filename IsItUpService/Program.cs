using Topshelf;

namespace IsItUpService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<Service>(service =>
                {
                    service.ConstructUsing(s => new Service());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                configure.RunAsLocalSystem();
                configure.SetServiceName("Is It Up?");
                configure.SetDisplayName("Is It Up?");
                configure.SetDescription("Is It Up? Checks if the configured URL is available every configured interval.");
            });
        }
    }
}
