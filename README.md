# Gilded Rose refactoring project in C#

I've realised a C# refactoring project as well in the spirit of the original problem, as stated in http://iamnotmyself.com/2012/12/08/why-most-solutions-to-gilded-rose-miss-the-bigger-picture/.

The refactoring started with the unit tests: I moved the unit test to another project, to separate the business logic implementation from the unit testing.

Then, I wrote the unit test to represent the correct behavior and the edge cases of the requirements listed in the original problem, adding as well the new requirements. At this point, some unit test fail.

Before implementing the new feature, I refactored the code in order to make easier adding new feature, otherwise the implementation of another requirements would have been nearly impossible.

The first refactoring consisted in factoring the two main updates in the function GildedRose.UpdateQuality. I separated the quality update before the SellIn update, and after. But even then, it was nearly impossible to find the right spot to implement the new Conjured item feature. 