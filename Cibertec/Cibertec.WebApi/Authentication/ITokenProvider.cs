﻿using Cibertec.Models;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Cibertec.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameteres();
    }
}