using IPBVC_Backend.Domain.Entities;
using IPBVC_Backend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBVC_Backend.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IRepository _repository;
        private readonly IEventRepository _eventRepository;

        public EventService(IRepository repository, IEventRepository eventRepository)
        {
            _repository = repository;
            _eventRepository = eventRepository;
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            try
            {
                var eventExists = await _repository.Exists<Event>(e => e.Name == newEvent.Name);
                if (eventExists)
                {
                    throw new Exception("Event already exists");
                }
                    _repository.Add(newEvent);
                    if (await _repository.SaveChangesAsync())
                    {
                        return await _eventRepository.GetEventById(newEvent.Id);

                    }

                    return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            try
            {
                var eventToDelete = await _eventRepository.GetEventById(id);
                if (eventToDelete == null)
                {
                    throw new Exception("Event not found");
                }
                _repository.Delete<Event>(id);
                return (await _repository.SaveChangesAsync());
                

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<Event> GetEventByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            try
            {
                return await _eventRepository.GetAllEvents();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEventAsync(Event updatedEvent)
        {
            try
            {
                var existingEvent = await _eventRepository.GetEventById(updatedEvent.Id);
                if (existingEvent == null)
                {
                    throw new Exception("Event not found");
                }
                _repository.Update(updatedEvent);
                if (await _repository.SaveChangesAsync())
                {
                    return await _eventRepository.GetEventById(updatedEvent.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
