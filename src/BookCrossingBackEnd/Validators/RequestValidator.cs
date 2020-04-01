﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using FluentValidation;

namespace BookCrossingBackEnd.Validators
{
    public class RequestValidator : AbstractValidator<RequestDto>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Book.Id).GreaterThan(0);
            RuleFor(x => x.Owner.Id).GreaterThan(0);
            RuleFor(x => x.RequestDate).NotNull();
        }
    }
}
