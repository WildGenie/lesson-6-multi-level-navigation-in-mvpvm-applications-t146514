Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports MvpvmNavigation.Model

Namespace MvpvmNavigation.Services
    Public Interface IModuleTypesResolver
        Function GetName(ByVal moduleType As ModuleType) As String
        Function GetCaption(ByVal moduleType As ModuleType) As String
        Function GetTypeName(ByVal moduleType As ModuleType) As String
    End Interface
    Friend Class ModuleTypesResolver
        Implements IModuleTypesResolver

        Public Function GetName(ByVal moduleType As ModuleType) As String Implements IModuleTypesResolver.GetName
            If moduleType = MvpvmNavigation.Model.ModuleType.None Then
                Return Nothing
            End If
            Return moduleType.ToString()
        End Function
        Public Function GetCaption(ByVal moduleType As ModuleType) As String Implements IModuleTypesResolver.GetCaption
            If moduleType = MvpvmNavigation.Model.ModuleType.None Then
                Return Nothing
            End If
            Return DevExpress.XtraEditors.EnumDisplayTextHelper.GetDisplayText(moduleType)
        End Function
        Public Function GetTypeName(ByVal moduleType As ModuleType) As String Implements IModuleTypesResolver.GetTypeName
            If moduleType = MvpvmNavigation.Model.ModuleType.None Then
                Return Nothing
            End If
            Select Case moduleType
                Case MvpvmNavigation.Model.ModuleType.ModuleA
                    Return "View1"
                Case MvpvmNavigation.Model.ModuleType.ModuleB
                    Return "View2"
                Case MvpvmNavigation.Model.ModuleType.ModuleA_EditForm
                    Return "View1EditForm"
                Case MvpvmNavigation.Model.ModuleType.ModuleB_EditForm
                    Return "View2EditForm"
            End Select
            Throw New NotSupportedException()
        End Function
    End Class
End Namespace
