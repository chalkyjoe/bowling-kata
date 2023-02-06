using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Application.Models;

namespace Bowling.Application
{
    internal static class StringExtensions
    {
        public static IEnumerable<Frame> ToFrames(this string scoreSheet)
        {
            var frames = scoreSheet.Split(" ").Select(m => new Frame(m));
            return frames;
        }
    }
}
