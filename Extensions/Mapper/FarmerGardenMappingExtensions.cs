using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;
using SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenViewModels;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;

namespace SystemManagementFactory.Extensions.Mapper;

public static class FarmerGardenMappingExtensions
{
    public static GetFarmerGardenVm ToReadInfo(this FarmerGarden farmerGarden)
    {
        return new()
        {
            Id = farmerGarden.Id,
            FarmerGardenBaseInfo = new()
            {
                Name = farmerGarden.Name,
                Description = farmerGarden.Description,
                LandSize = farmerGarden.LandSize,
                Status = farmerGarden.Status,
                FarmerId = farmerGarden.FarmerId
            }
        };
    }
    
    public static GetFarmerGardenByIdVm ToReadByIdInfo(this FarmerGarden farmerGarden)
    {
        return new()
        {
            Id = farmerGarden.Id,
            FarmerGardenBaseInfo = new()
            {
                Name = farmerGarden.Name,
                Description = farmerGarden.Description,
                LandSize = farmerGarden.LandSize,
                Status = farmerGarden.Status,
                FarmerId = farmerGarden.FarmerId
            }
        };
    }

    public static FarmerGarden ToFarmerGarden(this CreateFarmerGardenRequest createInfo)
    {
        return new()
        {
            Name = createInfo.FarmerGardenBaseInfo.Name,
            Description = createInfo.FarmerGardenBaseInfo.Description,
            LandSize = createInfo.FarmerGardenBaseInfo.LandSize,
            Status = createInfo.FarmerGardenBaseInfo.Status,
            FarmerId = createInfo.FarmerGardenBaseInfo.FarmerId
        };
    }

    public static FarmerGarden ToUpdateFarmerGarden(this FarmerGarden farmerGarden ,UpdateFarmerGardenRequest updateInfo)
    {
        farmerGarden.Name = updateInfo.FarmerGardenBaseInfo.Name;
        farmerGarden.Description = updateInfo.FarmerGardenBaseInfo.Description;
        farmerGarden.LandSize = updateInfo.FarmerGardenBaseInfo.LandSize;
        farmerGarden.Status = updateInfo.FarmerGardenBaseInfo.Status;
        farmerGarden.FarmerId = updateInfo.FarmerGardenBaseInfo.FarmerId;
        farmerGarden.Version++;
        farmerGarden.UpdatedAt = DateTime.UtcNow;
        return farmerGarden;
    }

    public static FarmerGarden ToDeletedFarmerGarden(this FarmerGarden farmerGarden, UpdateFarmerGardenRequest request)
    {
        farmerGarden.IsDeleted = true;
        farmerGarden.DeletedAt = DateTime.UtcNow;
        farmerGarden.UpdatedAt = DateTime.UtcNow;
        farmerGarden.Version++;
        return farmerGarden;
    }
}