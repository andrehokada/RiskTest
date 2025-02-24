using PortfolioClassification.Domain.Enums;
using PortfolioClassification.Domain.Interface;
using PortfolioClassification.Domain.Models;
using PortfolioClassification.Service;

namespace PortfolioClassification.ConsoleApp
{
    public class Program
    {
        private readonly IPortfolioClassificationService _portfolioClassificationService;

        public Program(IPortfolioClassificationService portfolioClassificationService)
        {
            _portfolioClassificationService = portfolioClassificationService;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Entre com a data de referência, seguindo o modelo (dd/MM/yyyy):");
            DateTime referenceDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a quantidade de trades:");
            int n = int.Parse(Console.ReadLine());

            List<Trade> trades = new();
            Console.WriteLine("Entre com os dados do Trade (valor negociado, setor do cliente e data do próximo pagamento previsto):");

            for (int i = 0; i < n; i++)
            {
                string[] tradeData = Console.ReadLine().Split(' ');
                double value = double.Parse(tradeData[0]);
                ClientSectorEnum clientSector = Enum.Parse<ClientSectorEnum>(tradeData[1], true); // Change this line
                DateTime nextPaymentDate = DateTime.Parse(tradeData[2]);

                trades.Add(new Trade(value, clientSector, nextPaymentDate));
            }
            
            Console.WriteLine("------------------------------------");
            var program = new Program(new PortfolioClassificationService());
            Console.WriteLine("Resultado da Classificação dos Trades Inseridos:");
            foreach (var trade in trades)
            {
                Console.WriteLine(program._portfolioClassificationService.ClassifyTrade(trade, referenceDate));
            }
        }
    }
}
