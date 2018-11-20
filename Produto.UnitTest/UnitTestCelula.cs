using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Produto.Application.Interface;
using Produto.Domain.Entities;

namespace Produto.UnitTest
{
    [TestClass]
    public class UnitTestCelula
    {
        private Mock<ICelulaAppService> _mock;
        [TestMethod]
        public void GetCelula()
        {

            _mock = new Mock<ICelulaAppService>();
            Celula _celula = new Celula()
            {
                CelulaId = 10
            };
            _mock.Setup(x => x.GetById(_celula.CelulaId)).Returns(_celula);

            Assert.IsTrue(_celula.CelulaId == 10);
        }
    }
}
