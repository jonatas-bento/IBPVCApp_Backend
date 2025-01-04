using IPBVC_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBVC_Backend.Domain.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetByPlace(string location)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Location == location);
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
