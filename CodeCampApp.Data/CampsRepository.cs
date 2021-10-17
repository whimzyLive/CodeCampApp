using CodeCampApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCampApp.Data
{
    public class CampsRepository : ICampRepository
    {
        private readonly CampsContext context;

        public CampsRepository(CampsContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public Task<Camp[]> GetAllCampsAsync(bool includeTalks = false)
        {
            IQueryable<Camp> query = this.context.Camps
                .Include(camp => camp.Location);

            if (includeTalks)
            {
                query = query.Include(camp => camp.Talks)
                    .ThenInclude(talk => talk.Speaker);
            }

            query = query.OrderByDescending(camp => camp.EventDate);
            return query.ToArrayAsync();
        }

        public Task<Camp[]> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false)
        {
            IQueryable<Camp> query = this.context.Camps
                .Include(camp => camp.Location);

            if (includeTalks)
            {
                query = query.Include(camp => camp.Talks)
                    .ThenInclude(talk => talk.Speaker);
            }

            query = query.OrderByDescending(camp => camp.EventDate)
                .Where(camp => camp.EventDate == dateTime);
            return query.ToArrayAsync();
        }

        public Task<Speaker[]> GetAllSpeakersAsync()
        {
            return this.context.Speakers
                .OrderBy(speaker => speaker.LastName)
                .ToArrayAsync();
        }

        public Task<Camp> GetCampAsync(string moniker, bool includeTalks = false)
        {
            IQueryable<Camp> query = this.context.Camps
                .Include(camp => camp.Location);

            if (includeTalks)
            {
                query = query.Include(camp => camp.Talks)
                    .ThenInclude(talk => talk.Speaker);
            }

            query = query.Where(camp => camp.Moniker == moniker);
            return query.FirstOrDefaultAsync();
        }

        public Task<Speaker> GetSpeakerAsync(int speakerId)
        {
            var query = this.context.Speakers
                .Where(speaker => speaker.SpeakerId == speakerId);

            return query.FirstOrDefaultAsync();
        }

        public Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker)
        {
            IQueryable<Speaker> query = this.context.Talks
                .Where(talk => talk.Camp.Moniker == moniker)
                .Select(talk => talk.Speaker)
                .Where(speaker => speaker != null)
                .OrderBy(speaker => speaker.LastName)
                .Distinct();

            return query.ToArrayAsync();
        }

        public Task<Talk> GetTalkByMonikerAsync(string moniker, int talkId, bool includeSpeakers = false)
        {
            IQueryable<Talk> query = this.context.Talks;
            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            query = query
              .Where(t => t.TalkId == talkId && t.Camp.Moniker == moniker);

            return query.FirstOrDefaultAsync();
        }

        public Task<Talk[]> GetTalksByMonikerAsync(string moniker, bool includeSpeakers = false)
        {
            IQueryable<Talk> query = this.context.Talks;

            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            query = query
              .Where(t => t.Camp.Moniker == moniker)
              .OrderByDescending(t => t.Title);

            return query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;
        }
    }
}
