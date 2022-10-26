using MaiVietAnhBTH2.Data;
using MaiVietAnhBTH2.Models
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace MaiVietAnhBTH2.Controllers
{
    public class StudentController : Controllers
{
private readonly ApplicationDbContext _context;
public StudentController ( ApplicationDbContext context )
{
  _context = context;
}
public async Task<IActionResult> Index()
{
    var model = await _context.Student.ToListAsync();
    return View(model); 
}
public IActionResult Create()
{
    return View() ;
}
[HttpPost]
public async Task(IActionResult) Creat(Student std)
{
    if(ModelState.IsValid)
    {
        _context.add(std);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index)) ;
    }
}
}
