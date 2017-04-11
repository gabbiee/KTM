using KTM.App;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace KTM.App
{
    using Owin;

    public partial class Startup
    //{
    //    static string[] Scopes = { DriveService.Scope.DriveReadonly };
    //    static string ApplicationName = "Drive API .NET Quickstart";

    { //UserCredential credential;
        


        public void Configuration(IAppBuilder app)
        {
          // GetCredentials();
            ConfigureAuth(app);
        }
    }
}
