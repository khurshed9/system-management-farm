namespace SystemManagementFactory.Features.BaceInfos;

public readonly record struct CropBaseInfo(
    string Name,
    decimal Quantity,
    decimal PricePerUnit,
    int FarmerGardenId);