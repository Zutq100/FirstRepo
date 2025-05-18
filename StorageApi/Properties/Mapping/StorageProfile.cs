using AutoMapper;
using StorageApi.DTO;
using StorageApi.Models;

namespace StorageApi.Properties.Mapping
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<StorageItem, StorageItemDTO>();
            CreateMap<CreateStorageItemDTO, StorageItem>();
            CreateMap<UpdateStorageItemDTO, StorageItem>();

            CreateMap<StorageMovement, StorageMovementDTO>()
                .ForMember(dest => dest.StorageItemName, opt => opt.MapFrom(src => src.StorageItem.Name));
            CreateMap<CreateStorageMovementDTO, StorageMovement>();
            CreateMap<UpdateStorageItemDTO, StorageMovement>()
             .ForMember(dest => dest.Id, opt => opt.Ignore()) // Игнорируем ID при обновлении
            .ForMember(dest => dest.MovementDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.StorageItem, opt => opt.Ignore()); ;
        }
    }
}
