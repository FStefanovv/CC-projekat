using System.ComponentModel.DataAnnotations;

namespace LocalLib.Model;

public class User {
    public String FirstName {get; set;}
    public String LastName {get; set;}
    public String Jmbg {get; set;}
    public String Address {get; set;}

    public User(){}
}