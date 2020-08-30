using Initiation.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initiation.Server.Data.Seed
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedInstruments()
        {
            var instrumentsData = File.ReadAllText("Data/Seed/InstrumentSeed.json", Encoding.GetEncoding("iso-8859-1"));
            var instruments = JsonConvert.DeserializeObject<List<Instrument>>(instrumentsData);
            foreach(var instrument in instruments)
            {
                if(!_dataContext.Instruments.Any(x=> x.Name == instrument.Name))
                {
                    _dataContext.Instruments.Add(instrument);
                }
            }
            _dataContext.SaveChanges();
        }
    }
}
