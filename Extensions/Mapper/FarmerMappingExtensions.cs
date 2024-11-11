using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;

namespace SystemManagementFactory.Extensions.Mapper;

public static class FarmerMappingExtensions
{
    public static GetFarmerVm ToReadInfo(this Farmer farmer)
    {
        return new()
        {
            Id = farmer.Id,
            FarmerBaseInfo = new()
            {
                FullName = farmer.FullName,
                PhoneNumber = farmer.PhoneNumber,
                Address = farmer.Address,
                Gender = farmer.Gender,
                Experience = farmer.Experience,
            }
        };
    }
    
    public static GetFarmerByIdVm ToReadByIdInfo(this Farmer farmer)
    {
        return new()
        {
            Id = farmer.Id,
            FarmerBaseInfo = new()
            {
                FullName = farmer.FullName,
                PhoneNumber = farmer.PhoneNumber,
                Address = farmer.Address,
                Gender = farmer.Gender,
                Experience = farmer.Experience
            }
        };
    }

    public static Farmer ToFarmer(this CreateFarmerRequest createInfo)
    {
        return new()
        {
            FullName = createInfo.FarmerBaseInfo.FullName,
            PhoneNumber = createInfo.FarmerBaseInfo.PhoneNumber,
            Address = createInfo.FarmerBaseInfo.Address,
            Gender = createInfo.FarmerBaseInfo.Gender,
            Experience = createInfo.FarmerBaseInfo.Experience
        };
    }

    public static Farmer ToUpdateFarmer(this Farmer farmer ,UpdateFarmerRequest updateInfo)
    {
        farmer.FullName = updateInfo.FarmerBaseInfo.FullName;
        farmer.PhoneNumber = updateInfo.FarmerBaseInfo.PhoneNumber;
        farmer.Address = updateInfo.FarmerBaseInfo.Address;
        farmer.Gender = updateInfo.FarmerBaseInfo.Gender;
        farmer.Experience = updateInfo.FarmerBaseInfo.Experience;
        farmer.Version++;
        farmer.UpdatedAt = DateTime.UtcNow;
        return farmer;
    }

    public static Farmer ToDeletedFarmer(this Farmer farmer, UpdateFarmerRequest request)
    {
        farmer.IsDeleted = true;
        farmer.DeletedAt = DateTime.UtcNow;
        farmer.UpdatedAt = DateTime.UtcNow;
        farmer.Version++;
        return farmer;
    }
}