using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment3.Models
{
  interface INewScoreRepository
  {
    IEnumerable<NewScore> GetNewScores();
    NewScore GetNewScore(int id);
    void EditNewScore(NewScore newScore);
  }
}
