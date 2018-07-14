// Copyright (c) Francois Karman. All rights reserved.
// Licensed under the MIT license.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MSTest.Analyzer
{
    /// <summary>
    /// Checks that none of the non-public methods of a test project are marked with the [TestMethod] attribute.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class MT1004Analyzer : DiagnosticAnalyzer
    {
        /// <summary>
        /// The ID for diagnostics produced by the <see cref="MT1004Analyzer"/> analyzer.
        /// </summary>
        public static readonly string DiagnosticId = "MT1004";

        /// <summary>
        /// The title of the rule.
        /// </summary>
        private const string Title = "Non-public method should not have a test attribute";

        /// <summary>
        /// The message format used by the rule.
        /// </summary>
        private const string MessageFormat = "The method '{0}.{1}' should not be marked with the [TestMethod] attribute";

        /// <summary>
        /// The category of the rule.
        /// </summary>
        private const string Category = "Maintainability";

        /// <summary>
        /// The descriptor associated with the rule.
        /// </summary>
        private static readonly DiagnosticDescriptor Rule
            = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, true);

        /// <summary>
        /// Gets a set of descriptors for the diagnostics that this analyzer is capable of producing.
        /// </summary>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get { return ImmutableArray.Create(Rule); }
        }

        /// <summary>
        /// Registers the actions in this analysis context.
        /// </summary>
        /// <param name="context">The context for the analysis.</param>
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(HandleMethod, SymbolKind.Method);
        }

        /// <summary>
        /// Checks the methods definition.
        /// </summary>
        /// <param name="context">The current analysis context.</param>
        private static void HandleMethod(SymbolAnalysisContext context)
        {
            IMethodSymbol symbol = context.Symbol as IMethodSymbol;
            if (symbol == null)
            {
                throw new InvalidOperationException("symbol can't be null or not represent a method");
            }

            if (symbol.DeclaredAccessibility == Accessibility.Public)
            {
                return;
            }

            if (symbol.GetAttributes().Any(
                a => a.AttributeClass.Name == MSTestConstants.TestMethod
                && a.AttributeClass.GetNamespace() == MSTestConstants.Namespace))
            {
                string type = symbol.ContainingType.Name;
                string method = symbol.Name;
                Diagnostic diagnostic = Diagnostic.Create(Rule, symbol.Locations[0], type, method);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
