﻿using Xunit;

namespace AASharp.Tests
{
    public class CoordinateTransformationTest
    {
        [Fact]
        public void Equatorial2EclipticTest()
        {
            AAS2DCoordinate Ecliptic = AASCoordinateTransformation.Equatorial2Ecliptic(AASCoordinateTransformation.DMSToDegrees(7, 45, 18.946), AASCoordinateTransformation.DMSToDegrees(28, 01, 34.26), 23.4392911);
            Assert.Equal(113.215629227584, Ecliptic.X);
            Assert.Equal(6.6841700720452888, Ecliptic.Y);
        }

        [Fact]
        public void Ecliptic2EquatorialTest()
        {
            var equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(113.215629227584, 6.6841700720452888, 23.4392911);
            Assert.Equal(7.7552627777777783, equatorial.X);
            Assert.Equal(28.026183333333329, equatorial.Y);
        }

        [Fact]
        public void Equatorial2GalacticTest()
        {
            AAS2DCoordinate galactic = AASCoordinateTransformation.Equatorial2Galactic(AASCoordinateTransformation.DMSToDegrees(17, 48, 59.74), AASCoordinateTransformation.DMSToDegrees(14, 43, 8.2, false));
            Assert.Equal(12.959250041566406, galactic.X);
            Assert.Equal(6.0462984779957027, galactic.Y);
        }

        [Fact]
        public void Galactic2EquatorialTest()
        {
            AAS2DCoordinate equatorial = AASCoordinateTransformation.Galactic2Equatorial(12.959250041566406, 6.0462984779957027);
            Assert.Equal(17.816594444444444, equatorial.X);
            Assert.Equal(-14.718944444444446, equatorial.Y);

        }

        [Theory]
        [InlineData(-19.709867023950196, -6.7198916666666664, 38.921388888888885, 68.033595944105741, 15.12497383921664)]
        public void Equatorial2HorizontalTest(double localHourAngle, double delta, double latitude, double expectedX, double expectedY)
        {
            AAS2DCoordinate horizontal = AASCoordinateTransformation.Equatorial2Horizontal(localHourAngle, delta, latitude);
            Assert.Equal(expectedX, horizontal.X);
            Assert.Equal(expectedY, horizontal.Y);
        }

        [Theory]
        [InlineData(68.033595944105741, 15.12497383921664, 38.921388888888885, 4.2901329760498026, -6.7198916666666628)]
        public void Horizontal2EquatorialTest(double azimuth, double altitude, double latitude, double expectedX, double expectedY)
        {
            AAS2DCoordinate horizontal = AASCoordinateTransformation.Horizontal2Equatorial(azimuth, altitude, latitude);
            Assert.Equal(expectedX, horizontal.X);
            Assert.Equal(expectedY, horizontal.Y);
        }

        [Theory]
        [InlineData(-7, 5.5663706143591725)]
        [InlineData(-1, 5.2831853071795862)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(7, 0.71681469282041377)]
        public void MapTo0To2PIRangeTest(double angle, double expectedValue)
        {
            double mappedValue = AASCoordinateTransformation.MapTo0To2PIRange(angle);
            Assert.Equal(expectedValue, mappedValue);
        }

        [Theory]
        [InlineData(-361, 359)]
        [InlineData(-150, 210)]
        [InlineData(-50, 310)]
        [InlineData(50, 50)]
        [InlineData(150, 150)]
        [InlineData(250, 250)]
        [InlineData(370, 10)]
        [InlineData(770, 50)]
        public void MapTo0To360RangeTest(double degrees, double expectedValue)
        {
            double mappedValue = AASCoordinateTransformation.MapTo0To360Range(degrees);
            Assert.Equal(expectedValue, mappedValue);
        }

        [Theory]
        [InlineData(-26, 22)]
        [InlineData(-15, 9)]
        [InlineData(-5, 19)]
        [InlineData(5, 5)]
        [InlineData(15, 15)]
        [InlineData(25, 1)]
        [InlineData(37, 13)]
        [InlineData(77, 5)]
        public void MapTo0To24RangeTest(double hourAngle, double expectedValue)
        {
            double mappedValue = AASCoordinateTransformation.MapTo0To24Range(hourAngle);
            Assert.Equal(expectedValue, mappedValue);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 0.10000000000000001)]
        [InlineData(1, 1)]
        [InlineData(7, 7)]
        [InlineData(40, 40)]
        [InlineData(87, 87)]
        [InlineData(90, 90)]
        [InlineData(170, 10)]
        [InlineData(180, 0)]
        [InlineData(185, -5)]
        [InlineData(269, -89)]
        [InlineData(272, -88)]
        [InlineData(360, 0)]
        [InlineData(361, 1)]
        [InlineData(-361, -1)]
        [InlineData(-360, 0)]
        [InlineData(-272, 88)]
        [InlineData(-269, 89)]
        [InlineData(-185, 5)]
        [InlineData(-180, 0)]
        [InlineData(-170, -10)]
        [InlineData(-97, -83)]
        [InlineData(-90, -90)]
        [InlineData(-87, -87)]
        [InlineData(-40, -40)]
        [InlineData(-7, -7)]
        [InlineData(-1, -1)]
        public void MapToMinus90To90RangeTest(double degrees, double expectedValue)
        {
            double mappedValue = AASCoordinateTransformation.MapToMinus90To90Range(degrees);
            Assert.Equal(expectedValue, mappedValue);
        }
    }
}