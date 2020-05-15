# Gilded Rose refactoring project in C#

I've realised a C# refactoring project as well in the spirit of the original problem, as stated in http://iamnotmyself.com/2012/12/08/why-most-solutions-to-gilded-rose-miss-the-bigger-picture/.

The refactoring started with the unit tests: I moved the unit test to another project, to separate the business logic implementation from the unit testing.

Then, I wrote the unit test to represent the correct behavior and the edge cases of the requirements listed in the original problem, adding as well the new requirements. At this point, some unit test fail.

Before implementing the new feature, I refactored the code in order to make easier adding new feature, otherwise the implementation of another requirements would have been nearly impossible.

The first refactoring consisted in factoring the two main updates in the function GildedRose.UpdateQuality. I separated the quality update before the SellIn update, and after. But even then, it was nearly impossible to find the right spot to implement the new Conjured item feature.

I then decided to implement a Strategy Pattern: I first defined an interface representing the "Standard" update, i.e. the update that happens before the update of the SellIn property, refactoring the implemented UpdateQualityStandard method. This was a major refactory, so I decided to identify the code related to each different item, and copy the conditions directly in the method implementation. I then run the unit test to verify that the code still works.

With the strategy patter in place, the next refactory was to translate the quality update after the update of the SellIn property inside the strategies. This was easy due to the previous strategy selector method implemented based on the name of the item. I added a method to the interface, and implemented it in the strategies copying the code in the UpdateQualityAfterSellInUpdate method previously defined.
The only piece of logic left in the method ***UpdateQuality*** was the control of the SellIn property: the if determining whether the item expired or not, common to all the strategies, was left in the update function of the ***GildedRose*** class.

