namespace BoletosBus_CleanModularApp.Common.Data.Base
{
    public abstract class BaseEntity<TType>
    {
        public abstract TType Id { get; set; }

    }
}
