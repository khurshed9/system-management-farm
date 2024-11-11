using SystemManagementFactory.Domain.Enums;

namespace SystemManagementFactory.Features.BaceInfos;

public readonly record struct PurchaseRequestBaseInfo(
    int CropId,
    int BusinessOwnerId,
    decimal RequestedQuantity,
    DateTime RequestDate,
    PurchaseStatus Status);