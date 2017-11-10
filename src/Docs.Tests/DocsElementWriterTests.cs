using Docs.Utils;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace Docs.Tests
{
   public class DocsElementWriterTests
   {
      [Fact]
      public void ShouldWriteDocsElement()
      {
         var element = new DocsElement
         {
            Attributes = new Dictionary<string, string>
            {
               {"a", "b"},
               {"c", "d"},
            },
            Indentation = " ",
            Line = 1,
            Lines = 1,
            Name = "xyz"
         };

         var content = new[]
         {
            "foo",
            " bar"
         };

         new DocsElementWriter().Write(element, content)
            .ShouldBe(new[]
            {
               " <!--<docs:xyz a=\"b\" c=\"d\">-->",
               " foo",
               "  bar",
               " <!--</docs:xyz>-->"
            });
      }
   }
}