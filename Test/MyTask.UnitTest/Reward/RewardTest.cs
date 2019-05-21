using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTask.Core.Infrastructure.Data.Repositories;
using MyTask.Domain.Reward.Commands;
using MyTask.Domain.Reward.Repositories;
using System.IO;
using System.Threading.Tasks;

namespace MyTask.UnitTest.Reward
{
    [TestClass]
    public class RewardTest
    {
        [TestMethod]
        public async Task Create()
        {
            string path = @"D:\Temp\infinite.png";

            try
            {
                IMediator mediator = BuildMediator();

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    CreateRewardCommand.Response response = await mediator.Send(new CreateRewardCommand.Request { File = fs, Name = "MyFile" });
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private IMediator BuildMediator()
        {
            var services = new ServiceCollection();

            services.AddScoped(typeof(IExmaple), typeof(ExampleA));
            services.AddScoped(typeof(IExmaple), typeof(ExampleB));

            services.AddScoped(typeof(IRewardRepository), typeof(RewardRepository));
            services.AddMediatR(typeof(CreateRewardCommand));

            var provider = services.BuildServiceProvider();

            var temp = provider.GetService<IExmaple>();

            return provider.GetRequiredService<IMediator>();
        }
    }

    public interface IExmaple
    {
        string HelloWorld();
    }

    public class ExampleA : IExmaple
    {
        public string HelloWorld()
        {
            return $"Hello {GetType().FullName}";
        }
    }

    public class ExampleB : IExmaple
    {
        public string HelloWorld()
        {
            return $"Hello {GetType().FullName}";
        }
    }
}