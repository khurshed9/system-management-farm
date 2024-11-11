using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandRequest;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Features.Queries.PurchaseRequestQueries.PurchaseRequestViewModels;

namespace SystemManagementFactory.Extensions.Mapper;

public static class PurchaseRequestMappingExtensions
{
    public static GetPurchaseRequestVm ToReadInfo(this PurchaseRequest request)
    {
        return new()
        {
            Id = request.Id,
            PurchaseRequestBaseInfo = new()
            {
                CropId = request.CropId,
                BusinessOwnerId = request.BusinessOwnerId,
                RequestedQuantity = request.RequestedQuantity,
                RequestDate = request.RequestDate,
                Status = request.Status
            }
        };
    }

    public static GetPurchaseRequestByIdVm ToReadByIdInfo(this PurchaseRequest request)
    {
        return new()
        {
            Id = request.Id,
            PurchaseRequestBaseInfo = new()
            {
                CropId = request.CropId,
                BusinessOwnerId = request.BusinessOwnerId,
                RequestedQuantity = request.RequestedQuantity,
                RequestDate = request.RequestDate,
                Status = request.Status
            }
        };
    }

    public static PurchaseRequest ToPurchaseRequest(this CreatePurchaseRequestRequest createInfo)
    {
        return new()
        {
            CropId = createInfo.PurchaseRequestBaseInfo.CropId,
            BusinessOwnerId = createInfo.PurchaseRequestBaseInfo.BusinessOwnerId,
            RequestedQuantity = createInfo.PurchaseRequestBaseInfo.RequestedQuantity,
            RequestDate = DateTime.UtcNow,
            Status = createInfo.PurchaseRequestBaseInfo.Status
        };
    }

    public static PurchaseRequest ToUpdatePurchaseRequest(this PurchaseRequest request, UpdatePurchaseRequestRequest updateInfo)
    {
        request.CropId = updateInfo.PurchaseRequestBaseInfo.CropId;
        request.BusinessOwnerId = updateInfo.PurchaseRequestBaseInfo.BusinessOwnerId;
        request.RequestedQuantity = updateInfo.PurchaseRequestBaseInfo.RequestedQuantity;
        request.Status = updateInfo.PurchaseRequestBaseInfo.Status;
        request.UpdatedAt = DateTime.UtcNow;
        return request;
    }

    public static PurchaseRequest ToDeletedPurchaseRequest(this PurchaseRequest request)
    {
        request.IsDeleted = true;
        request.DeletedAt = DateTime.UtcNow;
        request.UpdatedAt = DateTime.UtcNow;
        return request;
    }
}
