#pragma checksum "C:\Users\Kanan\Desktop\Projects\TaskManagerApp\Manage\Areas\Admin\Views\Shared\_SidebarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d1aefb0e224e3dbb8599399814b0ca70fc4b730"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__SidebarPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_SidebarPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Kanan\Desktop\Projects\TaskManagerApp\Manage\Areas\Admin\Views\_ViewImports.cshtml"
using Manage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d1aefb0e224e3dbb8599399814b0ca70fc4b730", @"/Areas/Admin/Views/Shared/_SidebarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"137311206b85a00e0f53ecafb49b76f7a59ab03e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Shared__SidebarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Sidebar -->
<ul class=""navbar-nav main-background sidebar sidebar-dark accordion"" id=""accordionSidebar"">

    <!-- Sidebar - Brand -->
    <a class=""sidebar-brand d-flex align-items-center justify-content-center"">
        <div class=""sidebar-brand-text mx-3 text-white"">
            TASK MANAGER
        </div>
    </a>

         <li class=""nav-item"">
            <a");
            BeginWriteAttribute("class", " class=\"", 382, "\"", 495, 2);
            WriteAttributeValue("", 390, "nav-link", 390, 8, true);
#nullable restore
#line 12 "C:\Users\Kanan\Desktop\Projects\TaskManagerApp\Manage\Areas\Admin\Views\Shared\_SidebarPartial.cshtml"
WriteAttributeValue(" ", 398, ViewContext.RouteData.Values["Controller"].ToString().ToLower() == "home" ? "text-white" : "", 399, 96, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/admin\">\r\n                <span>Dashboard</span>\r\n            </a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a");
            BeginWriteAttribute("class", " class=\"", 631, "\"", 745, 2);
            WriteAttributeValue("", 639, "nav-link", 639, 8, true);
#nullable restore
#line 17 "C:\Users\Kanan\Desktop\Projects\TaskManagerApp\Manage\Areas\Admin\Views\Shared\_SidebarPartial.cshtml"
WriteAttributeValue(" ", 647, ViewContext.RouteData.Values["Controller"].ToString().ToLower() == "staff" ? "text-white" : "", 648, 97, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/admin/staff\">\r\n                <span>Staffs</span>\r\n            </a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a");
            BeginWriteAttribute("class", " class=\"", 884, "\"", 1003, 2);
            WriteAttributeValue("", 892, "nav-link", 892, 8, true);
#nullable restore
#line 22 "C:\Users\Kanan\Desktop\Projects\TaskManagerApp\Manage\Areas\Admin\Views\Shared\_SidebarPartial.cshtml"
WriteAttributeValue(" ", 900, ViewContext.RouteData.Values["Controller"].ToString().ToLower() == "assignment" ? "text-white" : "", 901, 102, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/admin/assignment\">\r\n                <span>Tasks</span>\r\n            </a>\r\n        </li>\r\n</ul>\r\n<!-- End of Sidebar -->\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
