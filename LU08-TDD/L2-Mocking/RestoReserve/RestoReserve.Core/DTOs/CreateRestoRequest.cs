using RestoReserve.Core.Models;

namespace RestoReserve.Core.DTOs;

public record CreateRestoRequest(
    string Name, 
    Cuisine Cuisine, 
    TimeOnly OpeningTime, 
    TimeOnly ClosingTime
);