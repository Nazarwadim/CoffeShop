public interface IBuildingBuyer
{
    bool CanAffordBuilding(int cost);
    void PurchaseBuilding(int cost);
}
