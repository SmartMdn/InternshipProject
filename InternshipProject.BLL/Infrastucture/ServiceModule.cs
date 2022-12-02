using InternshipProject.DAL.Interfaces;
using InternshipProject.DAL.Repositories;
using Ninject.Modules;

namespace InternshipProject.BLL.Infrastucture;

public class ServiceModule : NinjectModule
{
    private string connectionString;

    public ServiceModule(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public override void Load()
    {
        Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
    }
}