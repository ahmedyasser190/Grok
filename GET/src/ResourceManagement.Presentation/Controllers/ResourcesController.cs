using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Application.Common;
using ResourceManagement.Application.Features.Resources;
using ResourceManagement.Application.Features.Resources.CreateResource;
using ResourceManagement.Application.Features.Resources.GetResource;

namespace ResourceManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public ResourcesController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    //[HttpGet("{id:guid}")]
    //public async Task<ActionResult<ResourceResponse>> Get(Guid id, CancellationToken cancellationToken)
    //{
    //    var result = await _dispatcher.Send<GetResourceQuery, ResourceResponse?>(new GetResourceQuery(id), cancellationToken);
    //    if (result is null)
    //        return NotFound();
    //    return Ok(result);
    //}

    //[HttpPost]
    //public async Task<ActionResult<ResourceResponse>> Create([FromBody] CreateResourceRequest request, CancellationToken cancellationToken)
    //{
    //    var result = await _dispatcher.Send<CreateResourceCommand, ResourceResponse>(new CreateResourceCommand(request.Name, request.Description), cancellationToken);
    //    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    //}
}
