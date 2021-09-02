using System;
using System.Collections.Generic;
using System.Linq;
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
                _fixture.Create<int>(),
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

        [Fact]
        public void Add_ShouldThrowArgumentException_WhenValueIsAlreadyConnectedToItem()
        {
            var dummyItem = _fixture.Create<int>();
            var valueToCheck = _fixture.Create<int>();

            Graph<int> graph = new() {valueToCheck, {dummyItem, valueToCheck}};

            Action action = () => graph.Add(dummyItem, valueToCheck);

            action.Should().ThrowExactly<ArgumentException>().Where(
                ex => ex.Message.Contains("A node can't have multiple connections to another same node") &&
                      ex.ParamName == "value"
            );
        }

        [Fact]
        public void Traverse_ShouldWork_WhenFromAndToAreConnected()
        {
            var random = new Random();

            var startNode = _fixture.Create<int>();
            var endNode = _fixture.Create<int>();
            var randomNodesCount = random.Next(15, 100);
            var randomNodes = _fixture.CreateMany<int>(randomNodesCount).ToArray();

            Graph<int> graph = new()
            {
                startNode, endNode,
            };

            foreach(var node in randomNodes)
            {
                graph.Add(node);
            }

            var actualNodesTraversed = ConnectNodes() + 1;

            var expectedNodesTraversed = 0;
            graph.Traverse(
                startNode,
                endNode,
                (_) =>
                {
                    expectedNodesTraversed++;
                }
            );

            expectedNodesTraversed.Should().Be(actualNodesTraversed);

            int ConnectNodes()
            {
                var pathLength = randomNodes.Length / 3;

                var startToEndPath = randomNodes[^pathLength..];

                var current = startNode;

                foreach(var node in startToEndPath)
                {
                    graph.Add(current, node);
                    current = node;
                }

                graph.Add(current, endNode);

                var randomAddedNodes = randomNodes[..^pathLength];

                foreach(var node in randomAddedNodes)
                {
                    var randomNodeValue = randomNodes[random.Next(randomNodesCount)];

                    graph.Add(randomNodeValue, node);
                }

                return pathLength;
            }
        }
    }

    public class Dummy : IComparable<Dummy>
    {
        public int CompareTo(Dummy other) => throw new NotImplementedException();
    }
}
