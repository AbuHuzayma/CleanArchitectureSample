using System;
using CASample.Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace CASample.Application.UnitTests.Common.Exceptions
{
    public class ValidateModelExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidateModelException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

    }
}
