﻿using MediatR;

namespace Expert.Application.Commands.CreateProject
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public int IdUser { get; private set; }
    }
}
