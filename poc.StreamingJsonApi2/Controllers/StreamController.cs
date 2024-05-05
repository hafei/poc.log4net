using Microsoft.AspNetCore.Mvc;
using poc.StreamingJsonApi2.Models;

namespace poc.StreamingJsonApi2.Controllers;

[ApiController]
[Route("[controller]")]
public class StreamController: ControllerBase
{
    private static readonly List<DataItem> Items = Enumerable.Range(1, 1000)
        .Select(index => new DataItem
        {
            Id = index,
            Name = $"Item {index}"
        }).ToList();

    [HttpGet]
    public async IAsyncEnumerable<DataItem> Get()
    {
        foreach (var item in Items)
        {
            yield return item;
            await Task.Delay(100); // simulate delay
        }
    }
}