using System.ComponentModel.DataAnnotations;

namespace CentralLib.Model;

public class User {
    public int Id {get; set;}
    public String FirstName {get; set;}
    public String LastName {get; set;}
    public String Jmbg {get; set;}
    public String Address {get; set;}
    public int Loans {get; set;}


    public User(){}
}