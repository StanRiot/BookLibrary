using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookLibrary.CORE.Models;
using BookLibrary.Models;

namespace BookLibrary.AutoMapperProfiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>();

        }
    }
}
