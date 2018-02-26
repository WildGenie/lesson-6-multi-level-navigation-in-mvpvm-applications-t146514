Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Mvvm
Imports MvpvmNavigation.Model

Namespace MvpvmNavigation.Services
    Public Interface IModuleLocator
        Function IsModuleLoaded(ByVal moduleType As ModuleType) As Boolean
        Function GetModule(ByVal moduleType As ModuleType) As Object
        Sub ReleaseModule(ByVal [module] As Object)
    End Interface
    '
    Friend Class ModuleLocator
        Implements IModuleLocator

        Private serviceContainer As IServiceContainer
        Private modulesCache As IDictionary(Of ModuleType, WeakReference)
        Public Sub New(ByVal serviceContainer As DevExpress.Mvvm.IServiceContainer)
            Me.serviceContainer = serviceContainer
            Me.modulesCache = New Dictionary(Of ModuleType, WeakReference)()
        End Sub
        Public Function IsModuleLoaded(ByVal moduleType As ModuleType) As Boolean Implements IModuleLocator.IsModuleLoaded
            Return modulesCache.ContainsKey(moduleType)
        End Function
        Public Function GetModule(ByVal moduleType As ModuleType) As Object Implements IModuleLocator.GetModule
            If moduleType = MvpvmNavigation.Model.ModuleType.None Then
                Return Nothing
            End If
            Dim moduleReference As WeakReference = Nothing
            If (Not modulesCache.TryGetValue(moduleType, moduleReference)) OrElse moduleReference.Target Is Nothing Then
                Dim resolver = serviceContainer.GetService(Of IModuleTypesResolver)()
                Dim moduleTypeName As String = resolver.GetTypeName(moduleType)
                Dim activator = serviceContainer.GetService(Of IModuleActivator)()
                Dim [module] = activator.CreateModule(moduleTypeName)
                If moduleReference Is Nothing Then
                    moduleReference = New WeakReference([module])
                    modulesCache.Add(moduleType, moduleReference)
                Else
                    moduleReference.Target = [module]
                End If
            End If
            Return moduleReference.Target
        End Function
        Public Sub ReleaseModule(ByVal [module] As Object) Implements IModuleLocator.ReleaseModule
            Dim key As ModuleType = ModuleType.None
            For Each item In modulesCache
                If Not Object.Equals(item.Value.Target, [module]) Then
                    Continue For
                End If
                key = item.Key
                Exit For
            Next item
            modulesCache.Remove(key)
        End Sub
    End Class
End Namespace
