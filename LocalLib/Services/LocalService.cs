using LocalLib.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LocalLib.Services;

public class LocalService {
    private readonly LocalRepository _repository;
    private readonly String central_lib;

    public LocalService(LocalRepository repository) {
        _repository = repository;
        central_lib = Environment.GetEnvironmentVariable("CENTRAL_HOST");
    }
    
    public async Task Register(User user) {
        using(var client = new HttpClient()) {
            try {
                var apiUrl = $"http://{central_lib}:80/register";
                var jsonPayload = JsonSerializer.Serialize(user);

                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if(!response.IsSuccessStatusCode) {
                    throw new Exception("User with that JMBG already exists");
                }
               
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }

    public async Task<bool> Borrow(Loan newLoan) {
        using(var client = new HttpClient()) {
            try {
                var apiUrl = $"http://{central_lib}:80/borrow/"+newLoan.UserId;

                HttpContent content = new StringContent("", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                if(response.IsSuccessStatusCode) {
                    
                    _repository.Create(newLoan);

                    return true;
                }
                else {
                    return false;
                }
            }
            catch  {
                return false;
            }
        }
    }

    public async Task Return(int id) {
        Loan loan = _repository.GetById(id);

        if(!loan.Active)
            throw new Exception();
        _repository.ReturnBook(loan);

        using(var client = new HttpClient()) {
            try {
                var apiUrl = $"http://{central_lib}:80/return/"+loan.UserId;

                HttpContent content = new StringContent("", Encoding.UTF8, "application/json");

                await client.PutAsync(apiUrl, content);
            }
            catch  {    

            }
        }
    }
}