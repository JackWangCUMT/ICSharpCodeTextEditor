using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICSharpCodeTextEditor
{
    public partial class Form1 : Form
    {
        private TextEditorControl textEditor = null;
        public Form1()
        {
            InitializeComponent();
            textEditor = new TextEditorControl();
            textEditor.Dock = DockStyle.Fill;
            this.pContainer.Controls.Add(textEditor);

            textEditor.TextChanged += TextEditor_TextChanged;
            
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            //更新，以便进行代码折叠
            textEditor.Document.FoldingManager.UpdateFoldings(null, null);
        }

        private void btnFormatCSharp_Click(object sender, EventArgs e)
        {
            textEditor.Text = 
                JackWangCUMT.WinForm.CSharpFormatHelper.FormatCSharpCode(textEditor.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sampleCode = @"using ICSharpCode.TextEditor;
using System;
using System.Collections.Generic;
         using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ICSharpCodeTextEditor
{
    public partial class Form1 : Form
    {
        private TextEditorControl textEditor = null;
        public Form1()
        {
            InitializeComponent();
                     textEditor = new TextEditorControl();
            textEditor.Dock = DockStyle.Fill;
   this.pContainer.Controls.Add(textEditor);
            textEditor.TextChanged += TextEditor_TextChanged;
        }
        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
   //更新，以便进行代码折叠
            textEditor.Document.FoldingManager.UpdateFoldings(null, null);
        }
        private void btnFormatCSharp_Click(object sender, EventArgs e)
        {
            textEditor.Text = 
            JackWangCUMT.WinForm.CSharpFormatHelper.FormatCSharpCode(textEditor.Text);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if(textEditor!=null)
                   {
     textEditor.SetHighlighting(""C#"");

                textEditor.Encoding = System.Text.Encoding.UTF8;
            textEditor.Document.FoldingManager.FoldingStrategy = new JackWangCUMT.WinForm.MingFolding();
        }
    }
}
}
";
            
            //textEditor.SetHighlighting("C#");
            //textEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            textEditor.Encoding = System.Text.Encoding.UTF8;
            textEditor.Font = new Font("Hack",12);
            textEditor.Document.FoldingManager.FoldingStrategy = new JackWangCUMT.WinForm.MingFolding();
            textEditor.Text = sampleCode;

            //自定义代码高亮
            string path = Application.StartupPath+ "\\HighLighting";
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(path))
            {
                fsmp = new FileSyntaxModeProvider(path);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                textEditor.SetHighlighting("JackC#");
                

            }
        }
    }
}
