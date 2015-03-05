namespace SampleEntityFramework.DataAccess
{
    public interface IQuery<out TModel>
    {
        TModel Execute(ISchoolContext context);
    }
}