namespace SampleEntityFramework.DataAccess.Commands
{
    public interface ICommand<out TModel>
    {
        TModel Execute(ISchoolContext context);
    }
}