Imports System
Imports System.IO
Imports Microsoft.AspNetCore ' Core
Imports Microsoft.AspNetCore.Mvc ' Super Mvc Core
Imports Microsoft.AspNetCore.Builder ' WebAppBuilder Need
Imports Microsoft.AspNetCore.Hosting ' Set Content Root Folder
Imports Microsoft.Extensions.DependencyInjection ' For builder.Service Need
Imports Microsoft.Extensions.Hosting ' Check if Dev or Prod or Etc

Module Program
    Sub Main(args As String())
        Dim app as WebApplication = BuildWebHost(args)

        If Not app.Environment.IsDevelopment() Then
            app.UseExceptionHandler("/Home/Error")
            ' The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts()
        End If
        
        app.UseStaticFiles()
        app.UseRouting()
        app.UseAuthorization()

        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
        
        app.Run()
    End Sub

    Function BuildWebHost(args As String()) As WebApplication
        Dim builder as WebApplicationBuilder = WebApplication.CreateBuilder(args)
        builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory())
        builder.Services.AddControllersWithViews()
        Return builder.build()
    End Function
End Module
