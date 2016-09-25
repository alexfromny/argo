using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Argo.Startup))]
namespace Argo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
