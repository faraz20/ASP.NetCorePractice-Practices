using Microsoft.EntityFrameworkCore;

namespace Practice01
{
    public static class ExtMethod
    {
        public static void RemoveAll<T>(this DbSet<T> entity) where T : class
        {
            Program.Practice01 ctx = new Program.Practice01();
            ctx.RemoveRange(entity);
            ctx.SaveChanges();

        }
    }
}
