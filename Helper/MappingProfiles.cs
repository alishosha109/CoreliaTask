using AutoMapper;
using CoreliaTask.DTO;
using CoreliaTask.Models;

namespace CoreliaTask.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<CTask, CoreliaTaskDTO>();

        }

    }
}
