using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace assignment2_test
{
  class AlphabeticalOrderer : ITestCaseOrderer
  {
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
      return testCases.OrderBy(testCase => testCase.TestMethod.Method.Name);
    }
  }
}
