using System.Collections.Generic;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRoseWithGoldenMaster;
using NUnit.Framework;
using StatePrinter;
using StatePrinter.Configurations;

namespace GildedRose.Tests
{
    [UseReporter(typeof(VisualStudioReporter))]
    [TestFixture]
    public class DescribeGildedRose
    {
        private Stateprinter _printer = new Stateprinter();
        
        [Test]
        public void CombinatorialInputsForGildedRose()
        {
            var possibleNames = new[] { "", "a", "abc", "\t", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert" };
            var possibleSellIns = new[] {int.MinValue, -1, 0 , 1 , int.MaxValue};
            var possibleQualities = new[] { int.MinValue, -1, 0, 1, int.MaxValue };
            

            CombinationApprovals.VerifyAllCombinations(
                (name, sellIn, quality) =>
                { 
                    var items = new List<Item>();                    
                    var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
                    items.Add(item);
                    Program.TestableUpdateQuality(items);
                    return _printer.PrintObject(items);
                },
                possibleNames,
                possibleSellIns,
                possibleQualities);

        }
    }
}