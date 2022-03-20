Imports Microsoft.AspNetCore.Mvc

Namespace Controllers 
    Public Class HomeController 
        Inherits Controller

        Public Function Index() As IActionResult
            Return View()
        End Function

        Public Function Another() As IActionResult
            Return Ok("Ah Hello")
        End Function 
    End Class
End Namespace