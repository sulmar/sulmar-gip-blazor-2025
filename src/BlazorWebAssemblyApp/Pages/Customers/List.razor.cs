using Domain.Models;

namespace BlazorWebAssemblyApp.Pages.Customers;

public partial class List
{
    private string message = "Lorem ipsum...";

    private List<Customer> customers = [];

    private DateTime GetCurrentDate()
    {
        return DateTime.Now;
    }

    protected override void OnInitialized()
    {
        customers = new List<Customer>
        {
            new Customer { Id =1, Name = "a", Email = "a@domain.com"},
            new Customer { Id =2, Name = "b", Email = "b@domain.com"},
            new Customer { Id =3, Name = "c", Email = "c@domain.com", IsArchived = true },
        };

        customers = customers.Where(c => !c.IsArchived).ToList();
    }
}
