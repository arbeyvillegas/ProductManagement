using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductManagement.App.Startup))]
namespace ProductManagement.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
