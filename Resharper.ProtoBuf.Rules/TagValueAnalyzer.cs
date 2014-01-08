using System;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Daemon.Stages;
using JetBrains.ReSharper.Daemon.Stages.Dispatcher;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Files;

namespace Resharper.ProtoBuf.Rules
{
    [ElementProblemAnalyzer(new[] { typeof(IAttribute) }, HighlightingTypes = new[] { typeof(TagValueWarning) })]
    public class TagValueAnalyzer : ElementProblemAnalyzer<IAttribute>
    {
        protected override void Run(IAttribute element, ElementProblemAnalyzerData data, IHighlightingConsumer consumer)
        {
            Analyze(element, consumer);
        }

        internal void Analyze(IAttribute element, IHighlightingConsumer consumer)
        {
            if (element.Name.ShortName != "ProtoMember")
            {
                return;
            }

            var constructorParam = element.ConstructorArgumentExpressions.First();
            if (!constructorParam.IsConstantValue() || !constructorParam.ConstantValue.IsInteger())
            {
                return;
            }

            int tagValue = (int) constructorParam.ConstantValue.Value;
            if (tagValue == 0)
            {
                AddWarning(element, consumer, constructorParam, new TagValueWarning(TagError.Zero));
            }
            else if (tagValue < 0)
            {
                AddWarning(element, consumer, constructorParam, new TagValueWarning(TagError.Negative));
            }
            else if (tagValue > Math.Pow(2, 29) - 1)
            {
                AddWarning(element, consumer, constructorParam, new TagValueWarning(TagError.TooBig));
            }
            else if (tagValue >= 19000 && tagValue <= 19999)
            {
                AddWarning(element, consumer, constructorParam, new TagValueWarning(TagError.Reserved));
            }
        }

        private static void AddWarning(IAttribute element, IHighlightingConsumer consumer, ICSharpExpression constructorParam, TagValueWarning error)
        {
            consumer.AddHighlighting(
                error,
                constructorParam.GetHighlightingRange(),
                element.GetSourceFile().GetDominantPsiFile<CSharpLanguage>());
        }
    }
}
