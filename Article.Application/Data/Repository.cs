using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.Application.Models;

namespace Article.Application.Data
{
    public class Repository : IRepository
    {

        DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public ArticleModel Article(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleModel> Articles()
        {
            return _context.Articles.ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
