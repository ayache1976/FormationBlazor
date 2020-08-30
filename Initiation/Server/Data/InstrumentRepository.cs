using Initiation.Server.Helpers;
using Initiation.Server.Helpers.PagedParams;
using Initiation.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiation.Server.Data
{
    public interface IInstrumentRepository : IRepository
    {
        Task<List<Instrument>> GetInstruments();
        Task<Instrument> GetInstrument(int id);
        Task<PagedList<Instrument>> GetInstrumentsPaged(InstrumentParams instrumentParams);
    }
    public class InstrumentRepository : Repository, IInstrumentRepository
    {
        private readonly DataContext _context;

        public InstrumentRepository(DataContext context):base(context)
        {
            _context = context;
        }
        public async Task<List<Instrument>> GetInstruments()
        {
            return await _context.Instruments.OrderBy(x => x.Name).ToListAsync();
        }
        public async Task<Instrument> GetInstrument(int id)
        {
            return await _context.Instruments.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Instrument>> GetInstrumentsPaged(InstrumentParams instrumentParams)
        {
            var items = _context.Instruments.OrderBy(x => x.Name).AsQueryable();
            return await PagedList<Instrument>.CreateAsync(items, instrumentParams.PageNumber, instrumentParams.PageSize);
        }


        //public async Task<Instrument> CreatInstrument(Instrument instrument)
        //{
        //    await _context.Instruments.Add(instrument);
        //    return 
        //}
    }
}
