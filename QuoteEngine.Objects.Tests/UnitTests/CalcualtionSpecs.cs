using System;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using QuoteEngine.Objects.Domain;

namespace QuoteEngine.Objects.Tests.UnitTests
{
    public class CalcualtionSpecs
    {
        private IInsuranceModule[] _insuranceModules;
        private IInsuranceModule _insuranceModule;
        private CalculationEngine _calculationEngine;

        [Test]
        public void should_invoke_canHandle()
        {
            GivenAnInsuranceModule();
            GivenACalculationEngine();
            GivenNoErrorHandler();

            InsuranceQuote quote=InsuranceQuote.CreateFrom("car", "audi");
            _calculationEngine.CalculatePremium(quote);

            _insuranceModule.Received().CanHandle(quote);
        }

        [Test]
        public void Should_not_invoke_handle_if_no_relevant_module()
        {
            GivenAnInsuranceModule();
            GivenACalculationEngine();
            GivenNoErrorHandler();

            _insuranceModule.CanHandle(Arg.Any<InsuranceQuote>()).Returns(false);
            
            InsuranceQuote quote = InsuranceQuote.CreateFrom("car", "audi");
            _calculationEngine.CalculatePremium(quote);

            _insuranceModule.DidNotReceive().Handle(Arg.Any<InsuranceQuote>());
        }

        [Test]
        public void Should_invoke_module_handler_if_can_handle()
        {
            GivenAnInsuranceModule();
            GivenACalculationEngine();
            GivenNoErrorHandler();

            _insuranceModule.CanHandle(Arg.Any<InsuranceQuote>()).Returns(true);

            InsuranceQuote quote = InsuranceQuote.CreateFrom("car", "audi");
            _calculationEngine.CalculatePremium(quote);

            _insuranceModule.Received().Handle(Arg.Any<InsuranceQuote>());
        }

        [Test]
        public void Should_raise_error_when_no_modules_to_handle_quote()
        {
            GivenAnInsuranceModule();
            GivenACalculationEngine();

            _insuranceModule.CanHandle(Arg.Any<InsuranceQuote>()).Returns(false);

            InsuranceQuote quote = InsuranceQuote.CreateFrom("car", "audi");
            Assert.Throws<Exception>(()=> _calculationEngine.CalculatePremium(quote));

        }


        private void GivenAnInsuranceModule()
        {
            _insuranceModules = new IInsuranceModule[1];
            _insuranceModule = Substitute.For<IInsuranceModule>();
            _insuranceModules[0] = _insuranceModule;
        }

        private void GivenACalculationEngine()
        {
            _calculationEngine = new CalculationEngine(_insuranceModules);
        }

        private void GivenNoErrorHandler()
        {
            var calculationEngineErrorHandler = Substitute.For<CalculationEngine.CalculationEngineErrorHandler>();
            _calculationEngine.ErrorHandler = calculationEngineErrorHandler;
        }
    }
}