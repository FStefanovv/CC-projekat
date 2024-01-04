using CentralLib;
using CentralLib.Model;


namespace CentralLib.Repository;

public class UserRepository {
    private CentralDbContext _dbContext;

    public UserRepository(CentralDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void Register(User user) {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public bool CheckIfExists(string jmbg)
    {
        User user = (User)_dbContext.Users.Where(u => u.Jmbg == jmbg).FirstOrDefault();
        if(user == null)
            return false;
        return true;
    }

    public User GetById(int id)
    {
        return _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
    }

    public void BorrowBook(User user)
    {
        user.Loans += 1;
        _dbContext.SaveChanges();
    }

    public void ReturnBook(User user) {
        user.Loans -= 1;
        _dbContext.SaveChanges();
    }
}