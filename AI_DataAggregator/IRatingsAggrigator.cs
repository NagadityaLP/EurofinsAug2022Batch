using AI_DataLoader;
using System.Collections.Generic;

namespace AI_DataAggregator
{
    public interface IRatingsAggrigator
    {
        Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference);
    }
}
