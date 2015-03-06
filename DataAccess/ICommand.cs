namespace SampleEntityFramework.DataAccess
{
    public interface ICommand<out TModel>
    {
        TModel Execute(ISchoolContext context);
    }
}