using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagProLeague.Models;

namespace TagProLeague.Services
{
    public interface IDocumentsRepository<T>
    {
        Task<IEnumerable<T>> GetAllDocuments();
        Task<T> GetDocumentByName(string name);
        Task<T> GetDocumentById(string id);
        Task<List<T>> GetDocumentListByIds(List<string> id);
        Task CreateDocument(T document);
        Task<bool> UpdateDocument(T document);
        Task<bool> DeleteDocumentByName(string name);
        Task<bool> DeleteDocumentById(string id);
    }

    public class DocumentsRepository<T> : IDocumentsRepository<T>
    {
        private readonly IMongoDbContext _context;

        public DocumentsRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllDocuments()
        {
            return await _context.Collection<T>()
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<T> GetDocumentByName(string name)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => (m as Document).Name, name);
            return _context.Collection<T>()
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<T> GetDocumentById(string id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => (m as Document).Id, id);
            return _context.Collection<T>()
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<List<T>> GetDocumentListByIds(List<string> ids)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.In(m => (m as Document).Id, ids);
            return _context.Collection<T>()
                    .Find(filter)
                    .ToListAsync();
        }

        public async Task CreateDocument(T document)
        {
            await _context.Collection<T>()
                .InsertOneAsync(document);
        }

        public async Task<bool> UpdateDocument(T document)
        {
            ReplaceOneResult updateResult =
                await _context.Collection<T>()
                .ReplaceOneAsync(
                    filter: m => (m as Document).Id == (document as Document).Id,
                    replacement: document);
            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteDocumentByName(string name)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => (m as Document).Name, name);
            UpdateDefinition<T> update = Builders<T>.Update.Set(m => (m as Document).DeletedDate, DateTime.UtcNow);
            UpdateResult updateResult = await _context.Collection<T>()
                .UpdateOneAsync(filter, update);
            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteDocumentById(string id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => (m as Document).Id, id);
            UpdateDefinition<T> update = Builders<T>.Update.Set(m => (m as Document).DeletedDate, DateTime.UtcNow);
            UpdateResult updateResult = await _context.Collection<T>()
                .UpdateOneAsync(filter, update);
            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
