using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.ReSharper.Daemon.Stages;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using Moq;
using Resharper.ProtoBuf.Rules;
using Xunit;

namespace Resharper.Protobuf.Rules.Tests
{
    public class Class1
    {
        [Fact]
        public void Tesxt()
        {
            var mockAttributeElement = new Mock<IAttribute>();
            var mockConsumer = new Mock<IHighlightingConsumer>();
            
            var analyzer = new TagValueAnalyzer();
            analyzer.Analyze(mockAttributeElement.Object, mockConsumer.Object);
        }
    }
}
