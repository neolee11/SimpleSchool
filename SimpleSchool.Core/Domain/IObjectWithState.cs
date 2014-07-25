namespace SimpleSchool.Core.Domain
{
    public interface IObjectWithEntityState
    {
        ObjectEntityState EntityState { get; set; }

    }


   
}