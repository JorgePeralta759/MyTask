using System.Threading.Tasks;

namespace MyTask.Domain.Reward.Repositories
{
    public interface IRewardRepository
    {
        Task<RewardInfo> Create(RewardInfo record);
    }
}