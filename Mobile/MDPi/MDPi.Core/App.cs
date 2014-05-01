using Cirrious.CrossCore.IoC;
using MDPi.Core.Services.ServerInteractionServices;

namespace MDPi.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            MvxSimpleIoCContainer.Instance.RegisterType<IServerCommunicationService, DummyServerCommunicationService>();
            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}