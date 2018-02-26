Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Threading.Tasks

Namespace MvpvmNavigation.Services
    Public Interface IModuleActivator
        Function CreateModule(ByVal moduleTypeName As String) As Object
    End Interface
    '
    Friend Class ModuleActivator
        Implements IModuleActivator

        Private moduleAssembly As System.Reflection.Assembly
        Private rootNamespace As String
        Public Sub New(ByVal moduleAssembly As System.Reflection.Assembly, ByVal rootNamespace As String)
            Me.moduleAssembly = moduleAssembly
            Me.rootNamespace = rootNamespace
        End Sub
        Public Function CreateModule(ByVal moduleTypeName As String) As Object Implements IModuleActivator.CreateModule
            Return Activator.CreateInstance(moduleAssembly.GetType(rootNamespace & "."c & moduleTypeName))
        End Function
    End Class
End Namespace
