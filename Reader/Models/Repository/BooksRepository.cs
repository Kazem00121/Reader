using Reader.Models.ViewModels;

namespace Reader.Models.Repository
{
    public class BooksRepository
    {
        private readonly ReaderContext _context;
        public BooksRepository(ReaderContext context)
        {
            _context = context;
        }    
        
        public void BindSubCategories(TreeViewCategory category)
        {
            var SubCategories = (from c in _context.Categories
                                 where (c.ParentCategoryID == category.CategoryID)
                                 select new TreeViewCategory { CategoryID = c.CategoryID, CategoryName = c.CategoryName }).ToList();
            foreach(var item in SubCategories)
            {
                BindSubCategories(item);
                category.SubCategories.Add(item);
            }
        }
    }
}
