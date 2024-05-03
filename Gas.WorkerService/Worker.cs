using Gas.Application.Features.CylinderSaleFeatures.QueryHandler;
using MediatR;

namespace Gas.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;

        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                SendYesterDayTotalSales();
                await Task.Delay(10000, stoppingToken);
            }
        }

        public async void SendTotalSales()
        {
            var result = await _mediator.Send(new GetCylinderSaleQuery());
            decimal TotalSum = 0;
            result.Data = result.Data.Where(x => x.Super_dealer_id == 1).ToList();
            if (result.Data.Count > 0)
            {
                foreach (var item in result.Data)
                {
                    decimal price = (decimal)(item.Price??0);
                    TotalSum += price;
                }
            }
            _logger.LogInformation(message: "-------- Total Sales = {total}", TotalSum.ToString("N"));
        }

        public async void SendYesterDayTotalSales()
        {
            DateTime yesterday = DateTime.Today.AddDays(-6);
            var result = await _mediator.Send(new GetCylinderSaleQuery());
            _logger.LogInformation("{time}",yesterday.ToLongDateString());
            decimal TotalSum = 0;
            result.Data = result.Data.Where(x => x.Super_dealer_id == 1 && (DateTime.Parse(x.Sale_date)).ToShortDateString() == yesterday.ToShortDateString()).ToList();
            if (result.Data.Count > 0)
            {
                foreach (var item in result.Data)
                {
                    decimal price = (decimal)(item.Price ?? 0);
                    TotalSum += price;
                }
            }
            _logger.LogInformation(message: "-------- Total Sales = {total}", TotalSum.ToString("N"));
        }
    }
}
