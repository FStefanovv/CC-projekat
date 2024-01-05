using LocalLib;
using LocalLib.Model;

public class LocalRepository {
    private readonly LocalDbContext _context;

    public LocalRepository(LocalDbContext context){
        _context = context;
    }

    public void Create(Loan newLoan) {
        newLoan.BorrowedOn = DateTime.UtcNow;
        newLoan.Active = true;

        _context.Loans.Add(newLoan);
        _context.SaveChanges();
    }

    public Loan GetById(int id) {
        return (Loan)_context.Loans.Where(loan => loan.Id == id).FirstOrDefault();
    }

    public void ReturnBook(Loan loan)
    {
        loan.Active = false;
        _context.SaveChanges();
    }
}