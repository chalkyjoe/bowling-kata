using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Application.Models
{
    public record Frame
    {
        private IEnumerable<Roll> Rolls;
        public Frame(string frame)
        {
            Rolls = frame.Select(m => new Roll(m));
        }

        public int CalculateScore()
        {
            return Rolls.Sum(m => m.Value);
        }
    }
}
