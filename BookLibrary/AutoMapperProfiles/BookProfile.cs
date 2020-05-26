using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookLibrary.CORE.Models;
using BookLibrary.Models;

namespace BookLibrary.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(B => B.Authors, M => M.MapFrom(A => A.Authors.Select(BA => BA.Author.Name).ToArray()))
                .ForMember(B => B.Genres, M => M.MapFrom(A => A.Genres.Select(BG => BG.Genre.Name).ToArray()));

        }
    }
}
