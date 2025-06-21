using kolokwiumPoprawa.Dto;
using kolokwiumPoprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwiumPoprawa.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private AppService _appService;
    public ApiController(AppService appService) => _appService = appService;
    
    [HttpGet("/records")]
    public IActionResult GetRecords()
    {
        return Ok(_appService.GetRecords());
    }

    [HttpPost("/record/add")]
    public ActionResult AddRecord([FromBody] CreateRecordDto createRecordDto)
    {
        return Ok(_appService.InsertRecord(createRecordDto));
    }
}