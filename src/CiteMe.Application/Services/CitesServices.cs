using CiteMe.Application.Contracts;
using CiteMe.Domain;
using CiteMe.Models;
using CiteMe.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiteMe.Application.Services
{
    public class CitesServices : ICitesServices
    {
        private readonly DataContext _context;

        public CitesServices(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CitesModel>> GetAll()
        {

            var citesDb = await _context.Cites.ToListAsync();
            var cites = new List<CitesModel>();
            foreach (var citeDb in citesDb)
            {
                cites.Add(new CitesModel
                {

                    id = citeDb.id,
                    name = citeDb.name,
                    telephone = citeDb.telephone,
                    date = citeDb.date,
                    time = citeDb.time

                });
            }
            return cites;

        }

        public async Task<CitesModel> Get(int id)
        {

            //var citeDb = await _context.Cites.FindAsync(id);
            var citeDb = await GetCite(id);
            var cite = new CitesModel
            {

                id = citeDb.id,
                name = citeDb.name,
                telephone = citeDb.telephone,
                date = citeDb.date,
                time = citeDb.time

            };

            return cite;

        }

        public bool Create(CitesModel cites)
        {
            try
            {
                var citeDb = new Cites
                {
                    name = cites.name,
                    telephone = cites.telephone,
                    date = cites.date,
                    time = cites.time

                };
                _context.Cites.Add(citeDb);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        public async Task<bool> Remove(CitesModel cites)
        {
            try
            {
                var citeDb = await GetCite(cites.id);
                _context.Cites.Remove(citeDb);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        private async Task<Cites> GetCite(int id)
        {

            return await _context.Cites.FindAsync(id);

        }

    }
}
