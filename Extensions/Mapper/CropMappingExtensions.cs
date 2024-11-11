using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;

namespace SystemManagementFactory.Extensions.Mapper;

public static class CropMappingExtensions
{
    public static GetCropVm ToReadInfo(this Crop crop)
    {
        return new()
        {
            Id = crop.Id,
            CropBaseInfo = new()
            {
                Name = crop.Name,
                Quantity = crop.Quantity,
                PricePerUnit = crop.PricePerUnit,
                FarmerGardenId = crop.FarmerGardenId
            }
        };
    }

    public static GetCropByIdVm ToReadByIdInfo(this Crop crop)
    {
        return new()
        {
            Id = crop.Id,
            CropBaseInfo = new()
            {
                Name = crop.Name,
                Quantity = crop.Quantity,
                PricePerUnit = crop.PricePerUnit,
                FarmerGardenId = crop.FarmerGardenId
            }
        };
    }

    public static Crop ToCrop(this CreateCropRequest createInfo)
    {
        return new()
        {
            Name = createInfo.CropBaseInfo.Name,
            Quantity = createInfo.CropBaseInfo.Quantity,
            PricePerUnit = createInfo.CropBaseInfo.PricePerUnit,
            FarmerGardenId = createInfo.CropBaseInfo.FarmerGardenId
        };
    }

    public static Crop ToUpdateCrop(this Crop crop, UpdateCropRequest updateInfo)
    {
        crop.Name = updateInfo.CropBaseInfo.Name;
        crop.Quantity = updateInfo.CropBaseInfo.Quantity;
        crop.PricePerUnit = updateInfo.CropBaseInfo.PricePerUnit;
        crop.FarmerGardenId = updateInfo.CropBaseInfo.FarmerGardenId;
        crop.Version++;
        crop.UpdatedAt = DateTime.UtcNow;
        return crop;
    }

    public static Crop ToDeletedCrop(this Crop crop)
    {
        crop.IsDeleted = true;
        crop.DeletedAt = DateTime.UtcNow;
        crop.UpdatedAt = DateTime.UtcNow;
        crop.Version++;
        return crop;
    }
}
