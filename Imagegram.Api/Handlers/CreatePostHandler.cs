﻿using Imagegram.Api.Dtos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Imagegram.Api.Handlers
{
    public class CreatePostHandler : IRequestHandler<CreatePostRequest, CreatePostResponse>
    {
        public Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreatePostResponse
            {
                CreatedAt = DateTime.UtcNow,
                Creator = new AccountDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Account"
                },
                Id = 1
            });
        }
    }
}
