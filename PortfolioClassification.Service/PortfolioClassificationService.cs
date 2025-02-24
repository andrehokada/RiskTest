using PortfolioClassification.Domain.Enums;
using PortfolioClassification.Domain.Interface;
using PortfolioClassification.Domain.Models;

namespace PortfolioClassification.Service
{
    public class PortfolioClassificationService : IPortfolioClassificationService
    {
        /// <summary>
        /// Classificação do Trade baseado nos valores de entrada, é possivel classificar como EXPIRED, HIGHRISK, MEDIUMRISK e LOWRISK
        /// </summary>
        /// <param name="trade"></param>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        public string ClassifyTrade(Trade trade, DateTime referenceDate)
        {
            var daysDifference = (referenceDate - trade.NextPaymentDate).TotalDays;
            if (daysDifference > 30)
                return "EXPIRED";

            if (trade.Value > 1000000)
                return trade.ClientSector == ClientSectorEnum.Public ? "HIGHRISK" : "MEDIUMRISK";

            return "LOWRISK";
        }
    }
}
