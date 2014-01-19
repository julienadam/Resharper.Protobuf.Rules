using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.DataFlow;
using JetBrains.DocumentModel;
using JetBrains.Metadata.Reader.API;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Daemon.Stages;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Modules;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util;
using Moq;
using Resharper.ProtoBuf.Rules;
using Xunit;

namespace Resharper.Protobuf.Rules.Tests
{
    public class TagValueAnalyzerTests
    {
        [Fact]
        public void Test()
        {
            
        }

        [Fact]
        public void Returns_a_warning_when_tag_is_zero()
        {
            var mockPsiModule = new Mock<IPsiModule>();
            

            var mockName = new Mock<IReferenceName>();
            mockName.Setup(n => n.ShortName).Returns("ProtoMember");
            var mockConstructorExpression = new Mock<ICSharpExpression>();
            mockConstructorExpression.Setup(e => e.IsConstantValue()).Returns(true);
            var constantValue = new ConstantValue(0, mockPsiModule.Object, DiagnosticResolveContext.Instance);
            mockConstructorExpression.Setup(e => e.ConstantValue).Returns(constantValue);

            var mockAttributeElement = new Mock<IAttribute>();
            mockAttributeElement.Setup(a => a.Name).Returns(mockName.Object);
            var expressionTree = new TreeNodeCollection<ICSharpExpression>(new[] {mockConstructorExpression.Object});
            mockAttributeElement.Setup(a => a.ConstructorArgumentExpressions).Returns(expressionTree);
            
            var mockConsumer = new Mock<IHighlightingConsumer>();
            
            var analyzer = new TagValueAnalyzer();
            analyzer.Analyze(mockAttributeElement.Object, mockConsumer.Object);
            mockConsumer.Verify(v => v.ConsumeHighlighting(It.IsAny<HighlightingInfo>()));
        }
    }
}
