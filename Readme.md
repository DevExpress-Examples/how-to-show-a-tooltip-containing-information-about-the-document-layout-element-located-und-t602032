<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128607875/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T602032)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/DXRichEditHitTest/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXRichEditHitTest/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXRichEditHitTest/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXRichEditHitTest/MainWindow.xaml.vb))
<!-- default file list end -->
#  How to: show a ToolTip containing information about the document layout element located under the cursor position


This example demonstrates how to use the <a href="https://documentation.devexpress.com/#corelibraries/clsDevExpressXtraRichEditHitTestManagertopic">HitTestManager</a> class to obtain document layout elements located under the specific point and show this information in the ToolTip.<br>Use the <a href="https://documentation.devexpress.com/#corelibraries/DevExpressXtraRichEditHitTestManagerMembersTopicAll">HitTestManager.HitTest</a> method to get the <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditRichEditHitTestResulttopic">RichEditHitTestResult</a> object providing information about a specific document element which is located under the test point. Retrieve the layout element using the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditRichEditHitTestResult_LayoutElementtopic">RichEditHitTestResult.LayoutElement</a> property or obtain the hit information about the element positioned next to the current hit element using the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditRichEditHitTestResult_Nexttopic">RichEditHitTestResult.Next</a> property. After that, display the required information about the document layout element in the ToolTip.

<br/>


