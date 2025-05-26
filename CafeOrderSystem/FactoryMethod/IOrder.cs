namespace CafeteriaOrderSystem.FactoryMethod
{
    public interface IOrder
    {
        string GetDescription();
        double GetCost();
        void Prepare();
    }
}