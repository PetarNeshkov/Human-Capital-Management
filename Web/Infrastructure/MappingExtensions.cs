using AutoMapper;

namespace HumanCapitalManagement.Web.Infrastructure;

public static class MappingExtensions
{
    public static TDestination Map<TDestination>(this object source, IMapper mapper)
        => mapper.Map<TDestination>(source);
}