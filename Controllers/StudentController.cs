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
//Get:Student/Edit/5
public async Task<IActionResult> Edit(string id)
{
    if (id == null)
    {
        return Notfound();
    }
}

var student = await _context.Student.FindAsync(id);
if ( student == null )
{
    return Notfound();
}    
    return View(student);
}
//Post: Student/Edit/5 
[HttpPost]
[ValidateAntiForgeryToken]
public  async Task<IActionResult> Edit (string id, [Bind("StudentID,StudentName")] Student std)
{
    if (id !=std.StudentID)
    {
        return NotFound();
    }
    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(std);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(std.StudentID))
            {
                return NotFound();
            }
            else 
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
        }
        return View(std)
    }