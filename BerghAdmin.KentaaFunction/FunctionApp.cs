using BerghAdmin.ApplicationServices.KentaaInterface;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using System;

namespace BerghAdmin.KentaaFunction;
public class FunctionApp
{
    private readonly IKentaaInterfaceService service;
    private readonly HttpClient berghClient;

    public FunctionApp(IHttpClientFactory httpClientFactory, IKentaaInterfaceService service)
    {
        this.service = service;
        this.berghClient = httpClientFactory.CreateClient();
    }

    [FunctionName("ReadDonations")]
    public async Task ReadDonations([TimerTrigger("0/10 * * * * *")] TimerInfo myTimer, ILogger log)
    {
        var donaties = await service.GetDonationsByQuery(new KentaaFilter());
        foreach (var donatie in donaties)
        {
            await berghClient.PostAsJsonAsync("https://localhost:5001/donaties", donatie);
        }
    }
}
