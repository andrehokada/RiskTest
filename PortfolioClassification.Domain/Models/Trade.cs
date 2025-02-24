using PortfolioClassification.Domain.Enums;

namespace PortfolioClassification.Domain.Models
{
    public class Trade
    {
        public Trade
        (
            double value, 
            ClientSectorEnum clientSector, 
            DateTime nextPaymentDate
        )
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }

        public double Value { get; }
        public ClientSectorEnum ClientSector { get; }
        public DateTime NextPaymentDate { get; }
    }
}
