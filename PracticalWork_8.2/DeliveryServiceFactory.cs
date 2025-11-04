using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public static class DeliveryServiceFactory
    {
        public static IInternalDeliveryService Create(DeliveryProviderType type, ILogger logger)
        {
            switch (type)
            {
                case DeliveryProviderType.Internal:
                    return new InternalDeliveryService(logger);
                case DeliveryProviderType.ExternalA:
                    {
                        var ext = new ExternalLogisticsServiceA(logger);
                        return new LogisticsAdapterA(ext, logger);
                    }
                case DeliveryProviderType.ExternalB:
                    {
                        var ext = new ExternalLogisticsServiceB(logger);
                        return new LogisticsAdapterB(ext, logger);
                    }
                case DeliveryProviderType.ExternalC:
                    {
                        var ext = new ExternalLogisticsServiceC(logger);
                        return new LogisticsAdapterC(ext, logger);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }
}
