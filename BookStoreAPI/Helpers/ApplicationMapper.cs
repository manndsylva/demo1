using AutoMapper;
using BookStoreAPI.Models;
using BookStoreAPI.Data;

namespace BookStoreAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Books, BookModel>().ReverseMap();

        }  
    }
}
