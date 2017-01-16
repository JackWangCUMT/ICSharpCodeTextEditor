using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackWangCUMT.WinForm
{
    
    /// <summary>
    /// The class to generate the foldings, it implements ICSharpCode.TextEditor.Document.IFoldingStrategy
    /// </summary>
    public class MingHTMLFolding : IFoldingStrategy
    {
        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            List<FoldMarker> list = new List<FoldMarker>();
            //需要分开
            int start = 0;
            int start2 = 0;
            int start3 = 0;
            int start4 = 0;
            int start_script = 0;
            //stack 先进先出
            var startLines = new Stack<int>();
            // Create foldmarkers for the whole document, enumerate through every line.
            for (int i = 0; i < document.TotalNumberOfLines; i++)
            {
                // Get the text of current line.
                string text = document.GetText(document.GetLineSegment(i));

                if (text.Trim().StartsWith("//region")) // Look for method starts
                    start = i;
                if (text.Trim().StartsWith("//endregion")) // Look for method endings
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 7));

                //<head></head>
                if (text.Trim().StartsWith("<head>")) // Look for method starts
                    start2 = i;
                if (text.Trim().StartsWith("</head>")) // Look for method endings
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start2, document.GetLineSegment(start2).Length, i, 57));

                //<style></style>
                if (text.Trim().StartsWith("<style")) // Look for method starts
                    start4 = i;
                if (text.Trim().StartsWith("</style>")) // Look for method endings
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start4, document.GetLineSegment(start4).Length, i, 57));


                //body
                if (text.Trim().StartsWith("<body")) // Look for method starts
                    start3 = i;
                if (text.Trim().StartsWith("</body>")) // Look for method endings
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start3, document.GetLineSegment(start3).Length, i, 57));

                //script
                if (text.Trim().StartsWith("<script")) // Look for method starts
                    start_script = i;
                if (text.Trim().StartsWith("</script>")) // Look for method endings
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start_script, document.GetLineSegment(start_script).Length, i, 57));

                //支持嵌套 {}
                if (text.Trim().StartsWith("{") || text.Trim().EndsWith("{")) // Look for method starts
                {
                    startLines.Push(i);
                }
                if (text.Trim().StartsWith("}")) // Look for method endings
                {
                    if (startLines.Count > 0)
                    {
                        int start0 = startLines.Pop();
                        list.Add(new FoldMarker(document, start0, document.GetLineSegment(start0).Length, i, 57, FoldType.TypeBody, "...}"));
                    }
                }

              


            }

            return list;
        }
    }
}
