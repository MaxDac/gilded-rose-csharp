# Gilded Rose refactoring project in C#

I've realised a C# refactoring project as well in the spirit of the original problem, as stated in http://iamnotmyself.com/2012/12/08/why-most-solutions-to-gilded-rose-miss-the-bigger-picture/.

The refactoring started with the unit tests: I moved the unit test to another project, to separate the business logic implementation from the unit testing.

Then, I wrote the unit test to represent the correct behavior and the edge cases of the requirements listed in the original problem, adding as well the new requirements. At this point, some unit test fail.

Before implementing the new feature, I refactored the code in order to make easier adding new feature, otherwise the implementation of another requirements would have been nearly impossible.

The first refactoring consisted in factoring the two main updates in the function GildedRose.UpdateQuality. I separated the quality update before the SellIn update, and after. But even then, it was nearly impossible to find the right spot to implement the new Conjured item feature.

I then decided to implement a Strategy Pattern: I first defined an interface representing the "Standard" update, i.e. the update that happens before the update of the SellIn property, refactoring the implemented UpdateQualityStandard method. This was a major refactory, so I decided to identify the code related to each different item, and copy the conditions directly in the method implementation. I then run the unit test to verify that the code still works.

With the strategy patter in place, the next refactory was to translate the quality update after the update of the SellIn property inside the strategies. This was easy due to the previous strategy selector method implemented based on the name of the item. I added a method to the interface, and implemented it in the strategies copying the code in the UpdateQualityAfterSellInUpdate method previously defined.
The only piece of logic left in the method ***UpdateQuality*** was the control of the SellIn property: the if determining whether the item expired or not, common to all the strategies, was left in the update function of the ***GildedRose*** class.

The next thing to refactor before implementing the new feature was to implement the SellIn property update in the strategies, and then refactor the detection of the expiration logic. I decided to create another method in the interface ***IUpdateStrategy*** to manage the SellIn property update.
As for the implementation of the update logic, that will encapsulate the whole behavior defined by the strategies, due to the limitation of this version of C#, I had to refactor the interface as an abstract class.

The last refactory before the implementation of the new functionality is to declare an instance of every strategy before the loop, in order to not recreate an instance for every item in the list.

The last thing to do is to implement the new functionality, the Conjured items. This would consist in the implementation of a new strategy, and the update of the strategy selector method. In order to keep the strategy logic in one place, I moved the strategy selector inside the abstract class.

You may check the various steps with each individual commit I've registered for the exercise.
