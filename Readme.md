#  How to: show a ToolTip containing information about the document layout element located under the cursor position


This example demonstrates how to use the <a href="https://documentation.devexpress.com/#corelibraries/clsDevExpressXtraRichEditHitTestManagertopic">HitTestManager</a> class to obtain document layout elements located under the specific point and show this information in the ToolTip.<br>Use the <a href="https://documentation.devexpress.com/#corelibraries/DevExpressXtraRichEditHitTestManagerMembersTopicAll">HitTestManager.HitTest</a> method to get the <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditRichEditHitTestResulttopic">RichEditHitTestResult</a> object providing information about a specific document element which is located under the test point. Retrieve the layout element using the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditRichEditHitTestResult_LayoutElementtopic">RichEditHitTestResult.LayoutElement</a> property or obtain the hit information about the element positioned next to the current hit element using the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditRichEditHitTestResult_Nexttopic">RichEditHitTestResult.Next</a> property. After that, display the required information about the document layout element in the ToolTip.

<br/>


