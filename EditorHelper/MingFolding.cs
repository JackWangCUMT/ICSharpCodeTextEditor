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
    public class MingFolding : IFoldingStrategy
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
            //stack 先进先出
            var startLines = new Stack<int>();
            // Create foldmarkers for the whole document, enumerate through every line.
            for (int i = 0; i < document.TotalNumberOfLines; i++)
            {
                // Get the text of current line.
                string text = document.GetText(document.GetLineSegment(i));

                if (text.Trim().StartsWith("#region")) // Look for method starts
                {
                    startLines.Push(i);

                }
                if (text.Trim().StartsWith("#endregion")) // Look for method endings
                {
                    int start = startLines.Pop();
                    // Add a new FoldMarker to the list.
                    // document = the current document
                    // start = the start line for the FoldMarker
                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                    // i = The current line = end line of the FoldMarker.
                    // 7 = The end column
                    list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 57, FoldType.Region, "..."));
                }
                //支持嵌套 {}
                if (text.Trim().StartsWith("{")) // Look for method starts
                {
                    startLines.Push(i);
                }
                if (text.Trim().StartsWith("}")) // Look for method endings
                {
                    if (startLines.Count > 0)
                    {
                        int start = startLines.Pop();
                        list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 57, FoldType.TypeBody, "...}"));
                    }
                }


                // /// <summary>
                if (text.Trim().StartsWith("/// <summary>")) // Look for method starts
                {
                    startLines.Push(i);
                }
                if (text.Trim().StartsWith("/// <returns>")) // Look for method endings
                {

                    int start = startLines.Pop();
                    //获取注释文本（包括空格）
                    string display = document.GetText(document.GetLineSegment(start + 1).Offset, document.GetLineSegment(start + 1).Length);
                    //remove ///
                    display = display.Trim().TrimStart('/');
                    list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 57, FoldType.TypeBody, display));
                }
            }

            return list;
        }
    }
}
