﻿using System.Collections.Generic;
using FluentAssertions;
using HeavyMetalBakeSale.Kata;
using Xunit;

namespace HeavyMetalBakeSale.Tests
{
    public class BakeSaleTests
    {
        private readonly BakeSale bakeSale;

        public BakeSaleTests()
        {
            var items = new List<Item>()
            {
                new()
                {
                    Name = "Brownie",
                    Identifier = 'B',
                    Cost = .65M,
                    Quantity = 48
                },
                new()
                {
                    Name = "Muffin",
                    Identifier = 'M',
                    Cost = 1M,
                    Quantity = 36
                },
                new()
                {
                    Name = "Cake Pop",
                    Identifier = 'C',
                    Cost = 1.35M,
                    Quantity = 24
                },
                new()
                {
                    Name = "Water",
                    Identifier = 'W',
                    Cost = 1.5M,
                    Quantity = 30
                },
            };

            bakeSale = new BakeSale(items);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("BB,B")]
        [InlineData("A")]
        [InlineData("A,Z")]
        public void ItemsToPurchase_ShouldThrowException_WhenInputIsInvalid(string items)
        {
            bakeSale
                .Invoking(x => x.ItemsToPurchase(items))
                .Should()
                .Throw<InvalidItemException>();
        }

        [Theory]
        [InlineData("B", .65)]
        [InlineData("B,C,M", 3)]
        [InlineData("C,M", 2.35)]
        [InlineData("W,W,W,W,W,W", 9)]
        public void ItemsToPurchase_ShouldReturnAnAppropriateTransaction_WhenInputIsValid(string items, decimal cost)
        {
            var transaction = bakeSale.ItemsToPurchase(items);

            transaction.Total.Should().Be(cost);
        }

        [Theory]
        [InlineData("B", .65, 0)]
        [InlineData("B", .75, .1)]
        [InlineData("C,M", 3.36, 1.01)]
        public void MakeATransaction(string items, decimal amountPayed, decimal expectedChange)
        {
            var transaction = bakeSale.ItemsToPurchase(items);
            var receipt = bakeSale.MakeTransaction(transaction, amountPayed);
            receipt.ChangeDue.Should().Be(expectedChange);
        }
    }
}