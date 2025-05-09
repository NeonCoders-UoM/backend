using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPassport.Data;
using VPassport.DTOs;
using VPassport.Models;

[Route("api/[controller]")]
[ApiController]
public class CustomerVehiclesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerVehiclesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetCustomers()
    {
        return await _context.Customers
            .Select(c => new CustomerResponseDTO
            {
                Customer_ID = c.Customer_ID,
                First_Name = c.First_name,
                Last_Name = c.Last_name,
                Email = c.Email,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                NIC = c.NIC
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerResponseDTO>> GetCustomer(int id)
    {
        var c = await _context.Customers.FindAsync(id);
        if (c == null) return NotFound();

        return new CustomerResponseDTO
        {
            Customer_ID = c.Customer_ID,
            First_Name = c.First_name,
            Last_Name = c.Last_name,
            Email = c.Email,
            Address = c.Address,
            PhoneNumber = c.PhoneNumber,
            NIC = c.NIC
        };
    }

    [HttpPost]
    public async Task<ActionResult<CustomerResponseDTO>> PostCustomer(CustomerDTO dto)
    {
        var c = new Customer
        {
            First_name = dto.First_Name,
            Last_name = dto.Last_Name,
            Email = dto.Email,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            NIC = dto.NIC,
            Password = dto.Password // Store securely in production
        };

        _context.Customers.Add(c);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCustomer), new { id = c.Customer_ID }, new CustomerResponseDTO
        {
            Customer_ID = c.Customer_ID,
            First_Name = c.First_name,
            Last_Name = c.Last_name,
            Email = c.Email,
            Address = c.Address,
            PhoneNumber = c.PhoneNumber,
            NIC = c.NIC
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, CustomerDTO dto)
    {
        var c = await _context.Customers.FindAsync(id);
        if (c == null) return NotFound();

        c.First_name = dto.First_Name;
        c.Last_name = dto.Last_Name;
        c.Email = dto.Email;
        c.Address = dto.Address;
        c.PhoneNumber = dto.PhoneNumber;
        c.NIC = dto.NIC;
        c.Password = dto.Password;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var c = await _context.Customers.FindAsync(id);
        if (c == null) return NotFound();

        _context.Customers.Remove(c);
        await _context.SaveChangesAsync();
        return NoContent();
    }


}
