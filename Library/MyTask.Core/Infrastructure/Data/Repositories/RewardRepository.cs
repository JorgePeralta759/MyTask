using MyTask.Domain.Reward;
using MyTask.Domain.Reward.Repositories;
using System.Threading.Tasks;

namespace MyTask.Core.Infrastructure.Data.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        public Task<RewardInfo> Create(RewardInfo record)
        {
            throw new System.NotImplementedException();
        }
    }
}