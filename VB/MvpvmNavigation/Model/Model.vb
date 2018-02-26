Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ComponentModel.DataAnnotations

Namespace MvpvmNavigation.Model
    Public Enum ModuleType
        None
        <Display(Name := "Module A")>
        ModuleA
        <Display(Name := "Module B")>
        ModuleB
        <Display(Name := "Module A Edit Form")>
        ModuleA_EditForm
        <Display(Name := "Module B Edit Form")>
        ModuleB_EditForm
    End Enum
End Namespace
