namespace csharpcore
{
    public abstract class IUpdateStrategy
    {
        /// <summary>
        /// This method updates the item characteristics before updating the SellIn property
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item.</returns>
        public abstract Item UpdateItemStandard(Item item);

        /// <summary>
        /// This method updates the expiration of the item.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item.</returns>
        public abstract Item UpdateExpiration(Item item);

        /// <summary>
        /// This method updates an item whose SellIn property is less than 0.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item</returns>
        public abstract Item UpdateExpiredItem(Item item);

        /// <summary>
        /// Updates the item for a day.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item</returns>
        public Item UpdateItem(Item item)
        {
            item = this.UpdateItemStandard(item);

            item = this.UpdateExpiration(item);

            if (item.SellIn < 0)
            {
                item = this.UpdateExpiredItem(item);
            }

            return item;
        }
    }
}