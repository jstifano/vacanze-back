using System;
using NUnit.Framework;
using vacanze_back.VacanzeApi.Common.Entities.Grupo8;
using vacanze_back.VacanzeApi.Common.Exceptions.Grupo8;

namespace vacanze_back.VacanzeApiTest.Grupo8
{
    [TestFixture]
    public class LayoverEntitytests
    {
        private Layover layover;
        [Test]
        public void EmptyDepartureDateTest()
        {
            var layover = new Layover(1,"", "2019-01-02",2000,0,2);
            Assert.Throws<InvalidAttributeException>(() => layover.Validate());
        }
        [Test]
        public void EmptyArrivalDateTest()
        {
            var layover = new Layover(1,"2019-01-01", "",2000,0,2);
            Assert.Throws<InvalidAttributeException>(() => layover.Validate());
        }
        [Test]
        public void NullLocDepartureTest()
        {
            var layover = new Layover(1,"2019-01-01", "2019-01-02",2000,0,2);
            Assert.Throws<InvalidAttributeException>(() => layover.Validate());
        }
        [Test]
        public void NullLocArrivalTest()
        {
            var layover = new Layover(1,"2019-01-01", "2019-01-02",2000,1,0);
            Assert.Throws<InvalidAttributeException>(() => layover.Validate());
        }
    }
}