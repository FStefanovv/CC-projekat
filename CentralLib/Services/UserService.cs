using CentralLib.Model;
using CentralLib.Repository;

namespace CentralLib.Services;

public class UserService {
    private readonly UserRepository _repository;
    
    public UserService(UserRepository repository) {
        _repository = repository;
    }

    public void Register(User user)  {
        bool exists  = _repository.CheckIfExists(user.Jmbg);        
        if(!exists){
            _repository.Register(user);
        }
        else throw new Exception();  
    }

    public void Borrow(int id)
    {
        User user = _repository.GetById(id);

        if(user == null)
            throw new Exception("user not found");
        if(user.Loans==3)
            throw new Exception("cannot borrow because the loan is 3");
        
        _repository.BorrowBook(user);        
    }

    public void ReturnBook(int id){
        User user = _repository.GetById(id);

        if(user == null)
            throw new Exception("user not found");
        if(user.Loans==0)
            throw new Exception("user hasnt borrowed any books");
        
        _repository.ReturnBook(user);    
    }
}