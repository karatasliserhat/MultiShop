using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var connect = new MongoClient(_databaseSettings.ConnectionString);
            var database = connect.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _contactCollection.InsertOneAsync(_mapper.Map<Contact>(createContactDto));

        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            return _mapper.Map<List<ResultContactDto>>(await _contactCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            return _mapper.Map<GetByIdContactDto>(await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, _mapper.Map<Contact>(updateContactDto));
        }
    }
}
