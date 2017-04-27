using KTM.App;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace KTM.App
{
    using Owin;

    public partial class Startup
 
    { 
        public void Configuration(IAppBuilder app)
        {
         
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
