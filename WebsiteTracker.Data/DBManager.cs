using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebsiteTracker.Data
{
   public class DBManager
    {
        private string _connectionString;
        public DBManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddCandidate(Candidate c)
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                context.Candidates.InsertOnSubmit(c);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Candidate> GetPendingCandidates()
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                return context.Candidates.ToList().Where(c => c.Status == Status.Pending);
            }
        }
        public IEnumerable<Candidate> GetConfirmedCandidates()
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                return context.Candidates.ToList().Where(c => c.Status == Status.Confirmed);
            }
        }
        public IEnumerable<Candidate> GetRefusedCandidates()
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                return context.Candidates.ToList().Where(c => c.Status == Status.Refused);
            }
        }
        public Candidate GetCandidateById(int id)
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                return context.Candidates.ToList().FirstOrDefault(c => c.Id == id);
            }
        }
        public int GetNumPending()
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                return context.Candidates.ToList().Where(c => c.Status == 0).Count();
            }
        }
        public StatusCounts GetCounts()
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                var counts = new StatusCounts
                {
                    Pending = context.Candidates.ToList().Where(c => c.Status == Status.Pending).Count(),
                    Refused = context.Candidates.ToList().Where(c => c.Status == Status.Refused).Count(),
                    Confirmed = context.Candidates.ToList().Where(c => c.Status == Status.Confirmed).Count(),
                };
                return counts;
            }
        }
        public void Confirm(int candidateId)
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = 1 WHERE Id={0}", candidateId);
            }
        }
        public void Refuse(int candidateId)
        {
            using (var context = new CandidateDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = 2 WHERE Id={0}", candidateId);
            }
        }
    }
}
