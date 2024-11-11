namespace SystemManagementFactory.Features.BaceInfos;

public readonly record struct BusinessOwnerBaseInfo(
    string FullName,
    string CompanyName,
    string PhoneNumber,
    string Address);