using NUnit.Framework;

namespace vacanze_back.VacanzeApiTest.Grupo9
{
    [TestFixture]
    public class ClaimsTest
    {
        /*
        [SetUp]
        public void setup()
        {
            controller = new ClaimController();
            cs = new ClaimSecundary();
            conec = new ClaimRepository();
        }

        [TearDown]
        public void tearDown()
        {
            controller = null;
            cs = null;
            conec = null;
        }

        private ActionResult<IEnumerable<Claim>> claim;
        private ClaimController controller;
        private ClaimSecundary cs;
        private ClaimRepository conec;
        private int response;

        [Test]
        [Order(8)]
        public void DeleteClaimTest()
        {
            //se pone un id que exista en la bd por lo menos el 7 
            var enumerable = controller.Get(0);
            var claimList = enumerable.Value.ToList().Find(x =>
                x.Title.Equals("Despues del put") && x.Description.Equals("descripcion despues"));
            var rows = controller.Get();
            controller.Delete(Convert.ToInt32(claimList.Id));
            var rowsresponse = controller.Get();
            Assert.AreEqual(rows - 1, rowsresponse);
        }

        [Test]
        [Order(3)]
        public void GetClaimEspecificTest()
        {
            var enumerable = controller.Get(0);
            var claimList = enumerable.Value.ToList().Find(x =>
                x.Title.Equals("Probando") && x.Description.Equals("Esta es mi descripcion") &&
                x.Status.Equals("ABIERTO"));

            //response = claimList.Value.Count();
            Assert.AreEqual("Probando", claimList.Title);
            Assert.AreEqual("Esta es mi descripcion", claimList.Description);
            Assert.AreEqual("ABIERTO", claimList.Status);
        }

        [Test]
        [Order(7)]
        public void GetClaimGetDocumentTest()
        {
            claim = controller.GetDocument("20766589");

            response = claim.Value.Count();
            Assert.AreEqual(response, 1);
        }

        [Test]
        [Order(6)]
        public void GetClaimStatusTest()
        {
            claim = controller.GetStatus("CERRADO");
            response = claim.Value.Count();
            Assert.True(response >= 0);
        }

        [Test]
        [Order(1)]
        public void GetClaimsTest()
        {
            var rows = controller.Get();
            Assert.True(0 <= rows);
        }

        [Test]
        [Order(9)]
        public void NullClaimExceptionDeleteTest()
        {
            Assert.Throws<ClaimNotFoundException>(() => conec.DeleteClaim(-1));
        }

        [Test]
        [Order(13)]
        public void NullClaimExceptionGetClaimDocumentTest()
        {
            Assert.Throws<ClaimNotFoundException>(() => conec.GetClaimDocument("0"));
        }

        [Test]
        [Order(12)]
        public void NullClaimExceptionGetClaimTest()
        {
            Assert.Throws<ClaimNotFoundException>(() => conec.GetClaim(-1));
        }

        [Test]
        [Order(11)]
        public void NullClaimExceptionModifyStatusTest()
        {
            var p = new Claim("PROBANDO", "UNITARIA", "CERRADO");

            Assert.Throws<ClaimNotFoundException>(() => conec.ModifyClaimStatus(-1, p));
        }

        [Test]
        [Order(10)]
        public void NullClaimExceptionModifyTitleTest()
        {
            var p = new Claim("PROBANDO", "UNITARIA", "CERRADO");

            Assert.Throws<ClaimNotFoundException>(() => conec.ModifyClaimTitle(-1, p));
        }


        [Test]
        [Order(2)]
        public void PostClaimTest()
        {
            cs.title = "Probando";
            cs.description = "Esta es mi descripcion";
            cs.status = "ABIERTO";

            var rows = controller.Get();
            controller.Post(2, cs);
            Assert.AreEqual(rows + 1, controller.Get());
        }

        [Test]
        [Order(5)]
        public void PutClaimStatusTest()
        {
            cs.status = "CERRADO";
            var enumerable = controller.Get(0);
            var claimList = enumerable.Value.ToList().Find(x =>
                x.Title.Equals("Despues del put") && x.Description.Equals("descripcion despues"));

            controller.Put(Convert.ToInt32(claimList.Id), cs);
            enumerable = controller.Get(Convert.ToInt32(claimList.Id));
            var claim = enumerable.Value.ToArray();
            Assert.AreEqual(claim[0].Status, "CERRADO");
        }

        [Test]
        [Order(4)]
        public void PutClaimTitleTest()
        {
            cs.title = "Despues del put";
            cs.description = "descripcion despues";
            var enumerable = controller.Get(0);
            var claimList = enumerable.Value.ToList().Find(x =>
                x.Title.Equals("Probando") && x.Description.Equals("Esta es mi descripcion"));

            controller.Put(Convert.ToInt32(claimList.Id), cs);
            enumerable = controller.Get(Convert.ToInt32(claimList.Id));
            var claim = enumerable.Value.ToArray();
            Assert.AreEqual(claim[0].Title, "Despues del put");
            Assert.AreEqual(claim[0].Description, "descripcion despues");
            Assert.AreEqual(claim[0].Status, "ABIERTO");
        }

        [Test]
        [Order(15)]
        public void ValidateLengTitleClaimTest()
        {
            var c = new Claim("validaaxedededdededededdedendod3dd3dd3d33", "mi test", "ABIERTO");
            Assert.Throws<AttributeSizeException>(() => c.Validate());
        }

        [Test]
        [Order(16)]
        public void ValidatePutClaimTest()
        {
            var c = new Claim("valida", "mi test", "ABIERTO");
            Assert.Throws<AttributeValueException>(() => c.ValidatePut());
        }

        [Test]
        [Order(14)]
        public void ValidateStatusClaimTest()
        {
            var c = new Claim("validando", "mi test", "mal");
            Assert.Throws<AttributeValueException>(() => c.Validate());
        }
    */
    }
}