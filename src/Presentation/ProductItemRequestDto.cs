using System;

namespace Presentation;

public class ProductItemRequestDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
