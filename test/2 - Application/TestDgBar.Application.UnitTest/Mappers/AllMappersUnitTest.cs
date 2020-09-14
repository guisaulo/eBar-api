﻿using AutoMapper;
using TestDgBar.Application.Mappers;
using Xunit;

namespace TestDgBar.Application.UnitTest.Mappers
{
    public class AllMappersUnitTest
    {
        [Fact]
        public void Deve_Validar_Todos_Mapeamentos()
        {
            var mappingTests = new MapperConfiguration(cfg => { 
                cfg.AddProfile<ComandaProfile>();
                cfg.AddProfile<ComandaItemProfile>();
                cfg.AddProfile<ItemProfile>();
                cfg.AddProfile<NotaFiscalProfile>();
            }).CreateMapper();

            mappingTests.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
