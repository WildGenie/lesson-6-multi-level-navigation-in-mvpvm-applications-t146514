Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace MvpvmNavigation.Services
    Public Interface ITransitionService
        Sub StartTransition(ByVal forward As Boolean, ByVal waitParameter As Object)
        Sub EndTransition()
    End Interface
    Friend Class TransitionService
        Implements ITransitionService

        Private supportTransitions As ISupportTransitions
        Public Sub New(ByVal supportTransitions As ISupportTransitions)
            Me.supportTransitions = supportTransitions
        End Sub
        Public Sub StartTransition(ByVal forward As Boolean, ByVal waitParameter As Object) Implements ITransitionService.StartTransition
            supportTransitions.StartTransition(forward, waitParameter)
        End Sub
        Public Sub EndTransition() Implements ITransitionService.EndTransition
            supportTransitions.EndTransition()
        End Sub
    End Class
    Public Module TransitionServiceExtension
        <System.Runtime.CompilerServices.Extension> _
        Public Function EnterTransition(ByVal service As ITransitionService, Optional ByVal effective As Boolean = True, Optional ByVal forward As Boolean = True, Optional ByVal waitParameter As Object = Nothing) As IDisposable
            Return New TransitionBatch(If(effective, service, Nothing), forward, waitParameter)
        End Function
        Private Class TransitionBatch
            Implements IDisposable

            Private service As ITransitionService
            Public Sub New(ByVal service As ITransitionService, ByVal forward As Boolean, ByVal waitParameter As Object)
                Me.service = service
                If service IsNot Nothing Then
                    service.StartTransition(forward, waitParameter)
                End If
            End Sub
            Public Sub Dispose() Implements IDisposable.Dispose
                If service IsNot Nothing Then
                    service.EndTransition()
                End If
            End Sub
        End Class
    End Module
End Namespace
