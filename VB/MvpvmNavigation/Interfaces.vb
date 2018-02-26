Imports DevExpress.XtraBars.Ribbon

Namespace MvpvmNavigation
    Public Interface IRibbonModule
        ReadOnly Property Ribbon() As RibbonControl
    End Interface
    Public Interface ISupportTransitions
        Sub StartTransition(ByVal forward As Boolean, ByVal waitParameter As Object)
        Sub EndTransition()
    End Interface
    Public Interface ISupportViewModel
        ReadOnly Property ViewModel() As Object
    End Interface
End Namespace