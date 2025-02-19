﻿using MediatR;
using EHRBS_backend.Application.DTO;

namespace EHRBS_backend.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }

}
