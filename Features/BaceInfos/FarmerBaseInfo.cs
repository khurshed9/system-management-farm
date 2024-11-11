using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Domain.Enums;

namespace SystemManagementFactory.Features.BaceInfos;

public readonly record struct FarmerBaseInfo(
    string FullName,
    string Address,
    string PhoneNumber,
    FarmerGender Gender,
    int Experience);