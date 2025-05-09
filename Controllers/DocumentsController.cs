using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPassport.Data;
using VPassport.DTOs;
using VPassport.Models; // Replace with your actual namespace

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DocumentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentResponseDTO>>> GetDocuments()
    {
        return await _context.Documents
            .Select(d => new DocumentResponseDTO
            {
                Document_ID = d.Document_ID,
                Document_Type = d.Document_type,
                File_Path = d.File_path,
                Vehicle_ID = d.Vehicle_ID
            }).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DocumentResponseDTO>> GetDocument(int id)
    {
        var d = await _context.Documents.FindAsync(id);

        if (d == null) return NotFound();

        return new DocumentResponseDTO
        {
            Document_ID = d.Document_ID,
            Document_Type = d.Document_type,
            File_Path = d.File_path,
            Vehicle_ID = d.Vehicle_ID
        };
    }

    [HttpPost]
    public async Task<ActionResult<DocumentResponseDTO>> PostDocument(DocumentDTO dto)
    {
        var doc = new Document
        {
            Document_type = dto.Document_Type,
            File_path = dto.File_Path,
            Vehicle_ID = dto.Vehicle_ID
        };

        _context.Documents.Add(doc);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDocument), new { id = doc.Document_ID }, new DocumentResponseDTO
        {
            Document_ID = doc.Document_ID,
            Document_Type = doc.Document_type,
            File_Path = doc.File_path,
            Vehicle_ID = doc.Vehicle_ID
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDocument(int id, DocumentDTO dto)
    {
        var doc = await _context.Documents.FindAsync(id);
        if (doc == null) return NotFound();

        doc.Document_type = dto.Document_Type;
        doc.File_path = dto.File_Path;
        doc.Vehicle_ID = dto.Vehicle_ID;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocument(int id)
    {
        var doc = await _context.Documents.FindAsync(id);
        if (doc == null) return NotFound();

        _context.Documents.Remove(doc);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
