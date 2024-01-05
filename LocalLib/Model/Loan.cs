namespace LocalLib.Model;

public class Loan {
    public Loan(){ }

    public int Id {get; set;}
    public int UserId {get; set;}
    public String BookName {get; set;}
    public String Writer {get; set;}
    public String ISBN {get; set;}
    public DateTime BorrowedOn {get; set;}
    public bool Active {get; set;}
}