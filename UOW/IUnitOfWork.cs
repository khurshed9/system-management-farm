using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Repositories.BaseRepository;

namespace SystemManagementFactory.UOW;

public interface IUnitOfWork<T> : IDisposable,IAsyncDisposable where T : BaseEntity
{
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
 
    Task<int> Complete();
    
    
}