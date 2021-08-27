<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128629936/10.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3056)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MyGridControl.cs](./CS/Custom%20GridView/MyGridControl.cs) (VB: [MyGridControl.vb](./VB/Custom%20GridView/MyGridControl.vb))
* [MyGridHandler.cs](./CS/Custom%20GridView/MyGridHandler.cs) (VB: [MyGridHandler.vb](./VB/Custom%20GridView/MyGridHandler.vb))
* [MyGridRegistration.cs](./CS/Custom%20GridView/MyGridRegistration.cs) (VB: [MyGridRegistration.vb](./VB/Custom%20GridView/MyGridRegistration.vb))
* [MyGridView.cs](./CS/Custom%20GridView/MyGridView.cs) (VB: [MyGridView.vb](./VB/Custom%20GridView/MyGridView.vb))
* [MyGridViewInfo.cs](./CS/Custom%20GridView/MyGridViewInfo.cs) (VB: [MyGridViewInfo.vb](./VB/Custom%20GridView/MyGridViewInfo.vb))
* [MyScrollInfo.cs](./CS/Custom%20GridView/MyScrollInfo.cs) (VB: [MyScrollInfo.vb](./VB/Custom%20GridView/MyScrollInfo.vb))
* **[Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))**
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
* [TouchScrollHelper.cs](./CS/TouchScrollHelper.cs) (VB: [TouchScrollHelper.vb](./VB/TouchScrollHelper.vb))
<!-- default file list end -->
# How to implement touch scrolling in GridView


<p>This example demonstrates how to provide the capability to scroll GridView by dragging its rows to be able to use GridView on touch devices. The helper class implements a basic scrolling behavior and some type of inertial scrolling when you drag a row fast. You can modify the helper class logic based on your application requirements. In addition, in this example we created a custom GridView which allows you to increase the scrollbar's width to adapt it for touch scrolling. If you do not need this functionality in your real application, it is not necessary to use a custom View. Just copy the helper class to your application.</p><p><strong>This example is outdated</strong></p><p><i>In the latest version of our components, GridControl supports touch scrolling out of the box. So, you don't need to add any helper or change any property.  This helper was created when this functionality was not supported by default.  You can utilize the helper class from this example in case you are using an older version of our components or, for example, want to implement custom touch scrolling behavior.</i></p><br />
<br />


<br/>


