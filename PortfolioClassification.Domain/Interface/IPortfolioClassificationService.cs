using PortfolioClassification.Domain.Models;

namespace PortfolioClassification.Domain.Interface
{
    public interface IPortfolioClassificationService
    {
        string ClassifyTrade(Trade trade, DateTime referenceDate);
    }
}
