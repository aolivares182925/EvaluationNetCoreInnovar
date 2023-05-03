using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarApi.Models;
using Microsoft.EntityFrameworkCore;
using NetCoreTestInnovar.Models;

namespace NetCoreTestInnovar.DataService
{
    public class ScoreDataService
    {
        private Context _context;
        public ScoreDataService(Context context){
            _context = context;
        }

        public List<Score> GetScores(){
            return _context.Scores.ToList();
        }

        public Score CreateScore(Score score){
            _context.Scores.Add(score);
            _context.SaveChanges();
            return score;
        }
    }
}