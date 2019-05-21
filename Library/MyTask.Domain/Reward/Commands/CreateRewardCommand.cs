using MediatR;
using MyTask.Domain.Reward.Repositories;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MyTask.Domain.Reward.Commands
{
    public static class CreateRewardCommand
    {
        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRewardRepository Repository;

            public Handler(IRewardRepository repository)
            {
                Repository = repository;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                Response response = null;
                try
                {
                    if (!string.IsNullOrEmpty(request.Name))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            await request.File.CopyToAsync(ms);

                            RewardInfo reward = new RewardInfo
                            {
                                Name = request.Name,
                                Icon = ms.ToArray()
                            };

                            await Repository.Create(reward);

                            response = new Response
                            {
                                Id = reward.Id
                            };
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return response;
            }
        }

        public class Request : IRequest<Response>
        {
            public string Name { get; set; }

            public Stream File { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
        }
    }
}