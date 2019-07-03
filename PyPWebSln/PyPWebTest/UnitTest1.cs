using System;
using PyPWeb.Controllers;
using Xunit;

namespace PyPWebTest
{
    public class UnitTest1
    {
        PicoPlacaController _controller;
        private string[] compSi;
        private string[] compNo;

        public UnitTest1()
        {
            _controller = new PicoPlacaController();
            compSi= new string[] { "SI" };
            compNo = new string[] { "NO" };
        }

        [Fact]
        public void Test_PlacaProhibida_HorarioProhibido()
        {
            var placa = "PBY0499";
            var fecha="2019-07-05";
            var hora = "08:46";
            // Act
            var resultado = _controller.Get(placa, fecha, hora);

            // Assert
            Assert.Equal(compNo, resultado);
        }

        [Fact]
        public void Test_PlacaProhibida_HorarioPermitido()
        {
            var placa = "PBY0499";
            var fecha = "2019-07-05";
            var hora = "21:46";
            // Act
            var resultado = _controller.Get(placa, fecha, hora);

            // Assert
            Assert.Equal(compSi, resultado);
        }

        [Fact]
        public void Test_PlacaPermitida_HorarioProhibido()
        {
            var placa = "PBY0496";
            var fecha = "2019-07-05";
            var hora = "08:46";
            // Act
            var resultado = _controller.Get(placa, fecha, hora);

            // Assert
            Assert.Equal(compSi, resultado);
        }
    }
}
