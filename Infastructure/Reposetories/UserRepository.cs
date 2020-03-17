﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.IRepositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Reposetories
{
    class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
