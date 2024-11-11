using SystemManagementFactory.Domain.Enums;

namespace SystemManagementFactory.Features.BaceInfos;

public readonly record struct FarmerGardenBaseInfo(
    string Name,
    string Description,
    decimal LandSize,
    GardenStatus Status,
    int FarmerId);