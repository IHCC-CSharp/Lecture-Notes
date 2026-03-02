using Microsoft.AspNetCore.Mvc; //don't remove i guess

namespace FortuneCookie.Controllers;

[ApiController]
[Route("fortune")]
public class OracleController : ControllerBase
{
    private static readonly string[] Fortunes =
    [
        "A clean API is a sign of a clean mind.",
        "The bug you find today will be the feature of tomorrow.",
        "Your code will compile on the first try... eventually.",
        "A semicolon is a small price to pay for functionality."
    ];

    // GET /fortune
    [HttpGet]
    public ContentResult GetFortune() 
    {
        var random = new Random();
        string myFortune = Fortunes[random.Next(Fortunes.Length)];

        string html = $@"
            <html>
                <body>
                        <h2>The Kestrel Oracle says:</h2>
                        <p>""{myFortune}""</p>                
                </body>
            </html>";

        return Content(html, "text/html");
    }
}