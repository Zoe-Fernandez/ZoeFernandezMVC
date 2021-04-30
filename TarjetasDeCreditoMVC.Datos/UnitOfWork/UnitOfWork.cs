namespace TarjetaDeCreditoMVC.Datos.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly TarjetasDeCreditoDbContext _context;

        public UnitOfWork(TarjetasDeCreditoDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
