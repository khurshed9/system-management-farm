using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Repositories.BaseRepository;

namespace SystemManagementFactory.UOW;

public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
{
    private readonly AppCommandDbContext _appCommand;
    private readonly AppQueryDbContext _queryContext;
    
    public IGenericUpdateRepository<Farmer> FarmerUpdateRepository { get; }
    public IGenericDeleteRepository<Farmer> FarmerDeleteRepository { get; }
    public IGenericFindRepository<Farmer> FarmerFindRepository { get; }
    public IGenericAddRepository<Farmer> FarmerAddRepository { get; }


    public IGenericUpdateRepository<BusinessOwner> BusinessOwnerUpdateRepository { get; }
    public IGenericDeleteRepository<BusinessOwner> BusinessOwnerDeleteRepository { get; }
    public IGenericFindRepository<BusinessOwner> BusinessOwnerFindRepository { get; }
    public IGenericAddRepository<BusinessOwner> BusinessOwnerAddRepository { get; }


    public IGenericUpdateRepository<Crop> CropUpdateRepository { get; }
    public IGenericDeleteRepository<Crop> CropDeleteRepository { get; }
    public IGenericFindRepository<Crop> CropFindRepository { get; }
    public IGenericAddRepository<Crop> CropAddRepository { get; }


    public IGenericUpdateRepository<PurchaseRequest> PurchaseRequestUpdateRepository { get; }
    public IGenericDeleteRepository<PurchaseRequest> PurchaseRequestDeleteRepository { get; }
    public IGenericFindRepository<PurchaseRequest> PurchaseRequestFindRepository { get; }
    public IGenericAddRepository<PurchaseRequest> PurchaseRequestAddRepository { get; }


    public IGenericUpdateRepository<Transaction> TransactionUpdateRepository { get; }
    public IGenericDeleteRepository<Transaction> TransactionDeleteRepository { get; }
    public IGenericFindRepository<Transaction> TransactionFindRepository { get; }
    public IGenericAddRepository<Transaction> TransactionAddRepository { get; }


    public IGenericUpdateRepository<FarmerGarden> FarmerGardenUpdateRepository { get; }
    public IGenericDeleteRepository<FarmerGarden> FarmerGardenDeleteRepository { get; }
    public IGenericFindRepository<FarmerGarden> FarmerGardenFindRepository { get; }
    public IGenericAddRepository<FarmerGarden> FarmerGardenAddRepository { get; }

    public UnitOfWork(AppCommandDbContext appCommand,
                      AppQueryDbContext queryContext,
                      IGenericUpdateRepository<Farmer> farmerUpdateRepository,
                      IGenericDeleteRepository<Farmer> farmerDeleteRepository,
                      IGenericFindRepository<Farmer> farmerFindRepository,
                      IGenericAddRepository<Farmer> farmerAddRepository,
                      IGenericUpdateRepository<BusinessOwner> businessOwnerUpdateRepository,
                      IGenericDeleteRepository<BusinessOwner> businessOwnerDeleteRepository,
                      IGenericFindRepository<BusinessOwner> businessOwnerFindRepository,
                      IGenericAddRepository<BusinessOwner> businessOwnerAddRepository,
                      IGenericUpdateRepository<Crop> cropUpdateRepository,
                      IGenericDeleteRepository<Crop> cropDeleteRepository,
                      IGenericFindRepository<Crop> cropFindRepository,
                      IGenericAddRepository<Crop> cropAddRepository,
                      IGenericUpdateRepository<PurchaseRequest> purchaseRequestUpdateRepository,
                      IGenericDeleteRepository<PurchaseRequest> purchaseRequestDeleteRepository,
                      IGenericFindRepository<PurchaseRequest> purchaseRequestFindRepository,
                      IGenericAddRepository<PurchaseRequest> purchaseRequestAddRepository,
                      IGenericUpdateRepository<Transaction> transactionUpdateRepository,
                      IGenericDeleteRepository<Transaction> transactionDeleteRepository,
                      IGenericFindRepository<Transaction> transactionFindRepository,
                      IGenericAddRepository<Transaction> transactionAddRepository,
                      IGenericUpdateRepository<FarmerGarden> farmerGardenUpdateRepository,
                      IGenericDeleteRepository<FarmerGarden> farmerGardenDeleteRepository,
                      IGenericFindRepository<FarmerGarden> farmerGardenFindRepository,
                      IGenericAddRepository<FarmerGarden> farmerGardenAddRepository)
    {
        _appCommand = appCommand;
        _queryContext = queryContext;

        FarmerUpdateRepository = farmerUpdateRepository;
        FarmerDeleteRepository = farmerDeleteRepository;
        FarmerFindRepository = farmerFindRepository;
        FarmerAddRepository = farmerAddRepository;

        BusinessOwnerUpdateRepository = businessOwnerUpdateRepository;
        BusinessOwnerDeleteRepository = businessOwnerDeleteRepository;
        BusinessOwnerFindRepository = businessOwnerFindRepository;
        BusinessOwnerAddRepository = businessOwnerAddRepository;

        CropUpdateRepository = cropUpdateRepository;
        CropDeleteRepository = cropDeleteRepository;
        CropFindRepository = cropFindRepository;
        CropAddRepository = cropAddRepository;

        PurchaseRequestUpdateRepository = purchaseRequestUpdateRepository;
        PurchaseRequestDeleteRepository = purchaseRequestDeleteRepository;
        PurchaseRequestFindRepository = purchaseRequestFindRepository;
        PurchaseRequestAddRepository = purchaseRequestAddRepository;

        TransactionUpdateRepository = transactionUpdateRepository;
        TransactionDeleteRepository = transactionDeleteRepository;
        TransactionFindRepository = transactionFindRepository;
        TransactionAddRepository = transactionAddRepository;

        FarmerGardenUpdateRepository = farmerGardenUpdateRepository;
        FarmerGardenDeleteRepository = farmerGardenDeleteRepository;
        FarmerGardenFindRepository = farmerGardenFindRepository;
        FarmerGardenAddRepository = farmerGardenAddRepository;
    }

    public async Task<int> Complete()
    {
        return await _appCommand.SaveChangesAsync();
    }
    

    public void Dispose()
    {
        _appCommand.Dispose();
        _queryContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _appCommand.DisposeAsync();
        await _queryContext.DisposeAsync();
    }
}
