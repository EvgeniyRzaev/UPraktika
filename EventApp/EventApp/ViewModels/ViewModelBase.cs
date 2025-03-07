using ReactiveUI;
using EventApp.Models;
namespace EventApp.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public PostgresContext db = new PostgresContext();
}
