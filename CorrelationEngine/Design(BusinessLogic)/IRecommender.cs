
using System.Collections.Generic;

namespace CorrelationEngine.Design
{
    public interface IRecommender
    {
        double GetCorrelation(List<int> baseData, List<int> otherData);
    }
}
