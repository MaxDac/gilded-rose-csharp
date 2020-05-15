namespace csharpcore
{
    public interface IUpdateStrategy
    {
        /// <summary>
        /// This method updates the item characteristics before updating the SellIn property
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item.</returns>
        Item UpdateItemStandard(Item item);

        /// <summary>
        /// This method updates an item whose SellIn property is less than 0.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item</returns>
        Item UpdateExpiredItem(Item item);
    }
}