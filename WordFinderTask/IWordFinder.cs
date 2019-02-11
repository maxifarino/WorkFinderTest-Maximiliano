using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinderTask
{
    public interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}
