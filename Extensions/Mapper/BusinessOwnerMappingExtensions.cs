using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Features.Commands.BusinessOwnerCommand.BusinessOwnerCommandRequest;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;

namespace SystemManagementFactory.Extensions.Mapper;

public static class BusinessOwnerMappingExtensions
{
    
    public static GetBusinessOwnerVm ToReadInfo(this BusinessOwner businessOwner)
    {
        return new()
        {
            Id = businessOwner.Id,
            BusinessOwnerBaseInfo = new()
            {
                FullName = businessOwner.FullName,
                CompanyName = businessOwner.CompanyName,
                PhoneNumber = businessOwner.PhoneNumber,
                Address = businessOwner.Address,
            }
        };
    }
    
    public static GetBusinessOwnerByIdVm ToReadByIdInfo(this BusinessOwner businessOwner)
    {
        return new()
        {
            Id = businessOwner.Id,
            BusinessOwnerBaseInfo = new()
            {
                FullName = businessOwner.FullName,
                CompanyName = businessOwner.CompanyName,
                PhoneNumber = businessOwner.PhoneNumber,
                Address = businessOwner.Address,
            }
        };
    }

    public static BusinessOwner ToBusinessOwner(this CreateBusinessOwnerRequest createInfo)
    {
        return new()
        {
            FullName = createInfo.BusinessOwnerBaseInfo.FullName,
            CompanyName = createInfo.BusinessOwnerBaseInfo.CompanyName,
            PhoneNumber = createInfo.BusinessOwnerBaseInfo.PhoneNumber,
            Address = createInfo.BusinessOwnerBaseInfo.Address,
        };
    }

    public static BusinessOwner ToUpdateBusinessOwner(this BusinessOwner businessOwner ,UpdateBusinessOwnerRequest updateInfo)
    {
        businessOwner.FullName = updateInfo.BusinessOwnerBaseInfo.FullName;
        businessOwner.CompanyName = updateInfo.BusinessOwnerBaseInfo.CompanyName;
        businessOwner.PhoneNumber = updateInfo.BusinessOwnerBaseInfo.PhoneNumber;
        businessOwner.Address = updateInfo.BusinessOwnerBaseInfo.Address;
        businessOwner.Version++;
        businessOwner.UpdatedAt = DateTime.UtcNow;
        return businessOwner;
    }

    public static BusinessOwner ToDeletedBusinessOwner(this BusinessOwner businessOwner, UpdateBusinessOwnerRequest request)
    {
        businessOwner.IsDeleted = true;
        businessOwner.DeletedAt = DateTime.UtcNow;
        businessOwner.UpdatedAt = DateTime.UtcNow;
        businessOwner.Version++;
        return businessOwner;
    }
}