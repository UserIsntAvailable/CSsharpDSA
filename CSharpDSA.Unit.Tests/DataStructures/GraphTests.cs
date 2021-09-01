using System;
using System.Collections.Generic;
using AutoFixture;
using CSharpDSA.DataStructures;
using FluentAssertions;
using Xunit;

namespace CSharpDSA.Unit.Tests.DataStructures
{
    public class GraphTests
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public void Add_ShouldWork_WhenItemIsInTheGraph()
        {
            var itemInGraph = _fixture.Create<int>();
            var valueInGraph = _fixture.Create<int>();

            Graph<int> graph = new()
            {
                itemInGraph,
                valueInGraph,
                3,
            };

            graph.Add(itemInGraph, valueInGraph);

            graph[itemInGraph].Should().Contain(valueInGraph);
        }

        [Fact]
        public void Add_ShouldThrowArgumentNullException_WhenParametersAreNull()
        {
            var dummy = _fixture.Create<Dummy>();

            Graph<Dummy> graph = new();

            Action itemAction = () => graph.Add(null, dummy);
            Action valueAction = () => graph.Add(dummy, null);

            itemAction.Should().ThrowExactly<ArgumentNullException>();
            valueAction.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Add_ShouldAddNewNode_WhenItemIsNotInTheGraph()
        {
            var itemToAdd = _fixture.Create<int>();
            var dummyNode = _fixture.Create<int>();

            Graph<int> graph = new() {dummyNode,};

            graph.Add(itemToAdd, dummyNode);

            graph.Should().Contain(itemToAdd);
        }

        [Fact]
        public void Add_ShouldThrowKeyNotFound_WhenValueIsNotInTheGraph()
        {
            var dummyNode = _fixture.Create<int>();

            Graph<int> graph = new();

            Action action = () => graph.Add(dummyNode, _fixture.Create<int>());

            action.Should().ThrowExactly<KeyNotFoundException>();
        }
    }

    public class Dummy : IComparable<Dummy>
    {
        public int CompareTo(Dummy other) => throw new NotImplementedException();
    }
}
