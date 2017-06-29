using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URSpot.Core.Api.LocalDatabase;
using URSpot.Core.Api.Proxies;
//using URSpot.Core.Api.GoogleMaps;

namespace URSpot.Core
{
    public class MvxApplication : MvvmCross.Core.ViewModels.MvxApplication
    {
        public static string AppName { get { return "URSpot"; } }

        public object GmsDirection { get; private set; }

        public override void Initialize()
        {

            #region Register Proxies

            Mvx.LazyConstructAndRegisterSingleton<IMediaProxy, MediaProxy>();
            Mvx.LazyConstructAndRegisterSingleton<IAuthProxy, AuthProxy>();
            Mvx.LazyConstructAndRegisterSingleton<IVenueProxy, VenueProxy>();
            Mvx.LazyConstructAndRegisterSingleton<IFriendProxy, FriendProxy>();
            Mvx.LazyConstructAndRegisterSingleton<IStaticDataProxy, StaticDataProxy>();

            #endregion


            #region Repository

            Mvx.RegisterType<ISqlLiteConnection, SqlLite>();
            Mvx.RegisterType<IStaticDataRepository, StaticDataRepository>();
            Mvx.RegisterType<IUserRepository, UserRepository>();
            Mvx.RegisterType<IFriendRepository, FriendRepository>();

            #endregion

            //GmsPlace.Init("AIzaSyAxNviCHKM5aEFIAp0WepDvhhqs1d2yjPM");

            RegisterAppStart(new AppStart());
            //RegisterAppStart<ViewModels.Account.LaunchViewModel>();
            //{
            //    var repository = Mvx.IocConstruct<StaticDataRepository>();
            //    repository.SyncronizeDatabase();
            //}
        }

    }
}
