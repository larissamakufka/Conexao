using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conexao;

namespace ConexaoTeste
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void AdicionarMaisElementosQueOInformado()
        {
            Conjunto c = new Conjunto(2);
            try
            {
                c.Conectar(1, 2);
                c.Conectar(1, 3);
                Assert.Fail("Um erro deveria ser lançado \"Limite de quantidade de elementos alcançado.\"");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Limite de quantidade de elementos alcançado.", ex.Message);
            }
        }

        [TestMethod]
        public void TestarConexaoDireta1()
        {
            Conjunto c = new Conjunto(3);
            c.Conectar(1, 2);
            c.Conectar(1, 3);
            Assert.IsTrue(c.Consulta(2, 1));
        }

        [TestMethod]
        public void TestarConexaoDireta2()
        {
            Conjunto c = new Conjunto(3);
            c.Conectar(1, 2);
            c.Conectar(1, 3);
            Assert.IsTrue(c.Consulta(1, 2));
        }

        [TestMethod]
        public void TestarConexaoIndireta1()
        {
            Conjunto c = new Conjunto(6);
            c.Conectar(1, 2);
            c.Conectar(1, 6);
            c.Conectar(2, 4);
            c.Conectar(2, 6);
            c.Conectar(5, 8);
            Assert.IsTrue(c.Consulta(1, 4));
        }

        [TestMethod]
        public void TestarConexaoIndireta2()
        {
            Conjunto c = new Conjunto(6);
            c.Conectar(1, 2);
            c.Conectar(1, 6);
            c.Conectar(2, 4);
            c.Conectar(2, 6);
            c.Conectar(5, 8);
            Assert.IsTrue(c.Consulta(4, 1));
        }

        [TestMethod]
        public void TestarConexaoInexistente()
        {
            Conjunto c = new Conjunto(6);
            c.Conectar(1, 2);
            c.Conectar(1, 6);
            c.Conectar(2, 4);
            c.Conectar(2, 6);
            c.Conectar(5, 8);
            Assert.IsFalse(c.Consulta(1, 7));
        }
    }
}
