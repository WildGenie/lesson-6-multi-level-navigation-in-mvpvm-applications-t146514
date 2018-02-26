Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Mvvm

Namespace MvpvmNavigation.ViewModels
    Public NotInheritable Class ViewModelHelper

        Private Sub New()
        End Sub

        Public Shared Sub EnsureModuleViewModel(ByVal view As Object, ByVal parentViewModel As Object, Optional ByVal parameter As Object = Nothing)
            Dim viewModelSupport As ISupportViewModel = TryCast(view, ISupportViewModel)
            If viewModelSupport IsNot Nothing Then
                EnsureViewModel(viewModelSupport.ViewModel, parentViewModel, parameter)
            End If
        End Sub
        Public Shared Sub EnsureViewModel(ByVal viewModel As Object, ByVal parentViewModel As Object, Optional ByVal parameter As Object = Nothing)
            Dim parentViewModelSupport As ISupportParentViewModel = TryCast(viewModel, ISupportParentViewModel)
            If parentViewModelSupport IsNot Nothing Then
                parentViewModelSupport.ParentViewModel = parentViewModel
            End If
            Dim parameterSupport As ISupportParameter = TryCast(viewModel, ISupportParameter)
            If parameterSupport IsNot Nothing AndAlso parameter IsNot Nothing Then
                parameterSupport.Parameter = parameter
            End If
        End Sub
    End Class
End Namespace
