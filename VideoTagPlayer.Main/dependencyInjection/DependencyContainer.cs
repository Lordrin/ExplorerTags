using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoTagPlayer.Main.dependencyInjection
{
    class DependencyContainer
    {
        // using Autofac;
        //public static class AppContainer
        //{
        //    private static IContainer _container;

        //    public static void RegisterDependencies()
        //    {
        //        var builder = new ContainerBuilder();

        //        //viewmodels
        //        builder.RegisterType<AnswersDetailsViewModel>().SingleInstance();
        //        builder.RegisterType<QuizViewModel>().SingleInstance();
        //        builder.RegisterType<HomePageViewModel>().SingleInstance();
        //        builder.RegisterType<RegisterViewModel>().SingleInstance();
        //        builder.RegisterType<SignInViewModel>().SingleInstance();
        //        builder.RegisterType<RoundDetailsViewModel>().SingleInstance();

        //        //Services
        //        builder.RegisterType<NavigationManager>().As<INavigationService>();
        //        builder.RegisterType<LoginManager>().As<IConnect<Quiz, string>>();
        //        builder.RegisterType<RoundManager>().As<IConnect<List<Round>, int>>();
        //        builder.RegisterType<DatabaseManager>().As<IAnswersRepository>();


        //        //General
        //        builder.RegisterInstance(QuizAnswersContextFactory.Create()).As<QuizAnswersContext>();

        //        _container = builder.Build();

        //    }

        //    public static object Resolve(Type typeName)
        //    {
        //        return _container.Resolve(typeName);
        //    }

        //    public static T Resolve<T>()
        //    {
        //        return _container.Resolve<T>();
        //    }
        //}
    }
}
