using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BevBuddyApp_v1._2_.Views;
using Microsoft.Extensions.DependencyInjection;
using BevBuddyApp_v1._2_.Repository;
using BevBuddyApp_v1._2_.ViewModels;

namespace BevBuddyApp_v1._2_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<RepositoryBase>();
        }

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {            
            var loginView = new LoginView();

            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    loginView.Close();
                }
            };
        }
    }
}
