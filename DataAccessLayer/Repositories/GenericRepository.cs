using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories {
    public class GenericRepository<T> : IGenericDal<T> where T : class {

        private readonly Context _context;

        public GenericRepository(Context context) {
            _context = context;
        }

        public void Add(T entity) {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity) {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id) {
            return _context.Set<T>().Find(id);  // id ye göre bul ve bunu dön
        }


        public List<T> GetListAll() {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity) {
            _context.Update(entity);
            _context.SaveChanges(); 
        }

    }
}
