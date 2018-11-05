namespace RainChance.BL.Test.Extensions
{
    using FluentAssertions;
    using RainChance.BL.Extensions;
    using SWE.Xunit.Attributes;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ValueExtensionsTest
    {
        private static List<float> _list = new List<float>
        {
            -0.1f,
            2.6f,
            3.1f,
            0.5f,
            1.3f,
            1.5f,
            1.6f
        };

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnAverage()
        {
            _list
                .ToValueData()
                .Average
                .Should()
                .Be(1.5f);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnCount()
        {
            _list
                .ToValueData()
                .Count
                .Should()
                .Be(7);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnDelta()
        {
            _list
                .ToValueData()
                .Delta
                .Should()
                .Be(3.2f);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnLatest()
        {
            _list
                .ToValueData()
                .Latest
                .Should()
                .Be(1.6f);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnMax()
        {
            _list
                .ToValueData()
                .Max
                .Should()
                .Be(3.1f);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnMin()
        {
            _list
                .ToValueData()
                .Min
                .Should()
                .Be(-0.1f);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnTrendSwitches()
        {
            _list
                .ToValueData()
                .TrendSwitches
                .Should()
                .Be(2);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnTrendDelta()
        {
            _list
                .ToValueData()
                .TrendDelta
                .Should()
                .Be(1.1f);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnTrendDuration()
        {
            _list
                .ToValueData()
                .TrendDuration
                .Should()
                .Be(3);
        }

        [Fact]
        [Category("ValueExtensions")]
        public void ToValueData_Should_ReturnTrendIncreasing()
        {
            _list
                .ToValueData()
                .TrendIncreasing
                .Should()
                .Be(true);

            var list = _list.ToList();
            list.Add(1.5f);

            list
                .ToValueData()
                .TrendIncreasing
                .Should()
                .Be(false);
        }
    }
}