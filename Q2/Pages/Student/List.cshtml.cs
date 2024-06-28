using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Models;
namespace Q2.Pages.Students
{
    public class ListModel : PageModel
    {
		private readonly Q2.Models.DUONGPV14_PRNContext _context;

		public ListModel(Q2.Models.DUONGPV14_PRNContext context)
		{
			_context = context;
		}

		public IList<Student> students { get; set; } = default!;
		[BindProperty(SupportsGet = true)]
		public string? SearchString { get; set; }

		public async Task OnGetAsync()
		{
			if (_context.Students != null)
			{
				students = await _context.Students
					.Include(s => s.Lecture)
					.Include(s => s.Classes)
					.Include(s => s.StudentSubjects)
				.ToListAsync();
				if (!string.IsNullOrEmpty(SearchString))
				{
					students = students.Where(s => s.FullName.Contains(SearchString)).ToList();
				}
			}
		}
	}
}
