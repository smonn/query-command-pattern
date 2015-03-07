namespace SampleEntityFramework.DataAccess.Queries
{
    public interface IQuery<out TModel>
    {
        TModel Execute(ISchoolContext context);
    }
}