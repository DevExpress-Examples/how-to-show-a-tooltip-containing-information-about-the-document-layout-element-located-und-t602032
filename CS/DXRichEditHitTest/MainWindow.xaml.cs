using DevExpress.Xpf.Ribbon;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXRichEditHitTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            richEditControl1.LoadDocument("Documents//Grimm.docx");
        }
        ToolTip toolTip = new ToolTip();
        private void RichEditControl_MouseMove(object sender, MouseEventArgs e)
        {
            #region #HitTest
            //Obtain the mouse cursor's layout position on the page and the current page index:
            Point wPoint = e.GetPosition(richEditControl1);

            PageLayoutPosition pageLayoutPosition = richEditControl1.ActiveView.GetDocumentLayoutPosition
                (new System.Drawing.Point((int)wPoint.X, (int)wPoint.Y));
            if (pageLayoutPosition == null)
                return;

            System.Drawing.Point point = pageLayoutPosition.Position;
            int pageIndex = pageLayoutPosition.PageIndex;
            LayoutPage layoutPage = richEditControl1.DocumentLayout.GetPage(pageIndex);

            //Create a HitTestManager instance: 
            HitTestManager hitTest = new HitTestManager(richEditControl1.DocumentLayout);

            //Perform the hit test and pass the result to the RichEditHitTestResult object:
            RichEditHitTestResult result = hitTest.HitTest(layoutPage, point);
            if (result != null)
            {
                //Retrieve the current layout element type:
                LayoutElement element = result.LayoutElement;
                string text = element.Type.ToString();

                //Obtain the the text character and its bounds under the mouse position              
                if (element.Type == LayoutType.CharacterBox)
                {
                    text += String.Format(" : \"{0}\"", (element as CharacterBox).Text);
                    text += GetBounds(element);
                    if (element.Parent.Type == LayoutType.PlainTextBox)
                    {
                        text += String.Format("\r\nPlainTextBox : \"{0}\"", (element.Parent as PlainTextBox).Text);
                        text += GetBounds(element.Parent);
                    }
                }
                else
                {
                    //Get the hovered element's bounds:
                    text += GetBounds(element);
                }

                //Get the element's location:
                string title = GetLocation(element);

                //Display all retrieved information in the tooltip:
                toolTip.IsOpen = true;
                toolTip.Content = text+"\r\n" + title;

            }
            #endregion #HitTest
        }
        string GetBounds(LayoutElement element)
        {
            return String.Format("\r\nBounds : {0}", element.Bounds);
        }
        string GetLocation(LayoutElement element)
        {
            while (element != null)
            {
                switch (element.Type)
                {
                    case LayoutType.CommentsArea:
                        return "Comments Area Location";
                    case LayoutType.Header:
                        return "Header Location";
                    case LayoutType.Footer:
                        return "Footer Location";
                }
                element = element.Parent;
            }
            return "Page Location";
        }
    }
}