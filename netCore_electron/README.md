# Usage:

To activate and communicate with the "native" (sort of native...) Electron API include the [ElectronNET.API NuGet package](https://www.nuget.org/packages/ElectronNET.API/) in your ASP.NET Core app.

````
dotnet add package ElectronNET.API --version 0.0.7
````
## Program.cs

You start Electron.NET up with an `UseElectron` WebHostBuilder-Extension. 

```csharp
public static IWebHost BuildWebHost(string[] args)
{
    return WebHost.CreateDefaultBuilder(args)
        .UseElectron(args)
        .UseStartup<Startup>()
        .Build();
}
```

## Startup.cs

Open the Electron Window in the Startup.cs file: 

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
    }

    app.UseStaticFiles();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });

    // Open the Electron-Window here
    Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
}
```

__Please note:__ Currently it is important to use ASP.NET Core with MVC. If you are working with the dotnet CLI, use

    dotnet new mvc

## Start the Application

For the tooling you will need your dotnet-electronize package [ElectronNET.CLI NuGet package](https://www.nuget.org/packages/ElectronNET.CLI/). This package __must__ be referenced in the .csproj like this:

```
    <ItemGroup>
         <DotNetCliToolReference Include="ElectronNET.CLI" Version="*" />
    </ItemGroup>
```
After you edited the .csproj-file, you need to restore your NuGet packages within your Project. Run the follwoing command in your ASP.NET Core folder:

```
    dotnet restore
```

* Make sure you have __node.js v8.6.0__ and on __macOS/Linux__ the electron-packager installed! 
    
    sudo npm install electron-packager --global

At the first time, you need an Electron.NET project initialization. Type the following command in your ASP.NET Core folder:

```
    dotnet electronize init
```

* Now a electronnet.manifest.json should appear in your ASP.NET Core project
* Now run the following:

```
    dotnet electronize start
```

## Build

Here you need the Electron.NET CLI too. Type following command in your ASP.NET Core folder:

```
    dotnet electronize build
```

In your default setting we just build the application for the OS you are running (Windows builds Windows, macOS builds macOS etc.), but this can be changed with:

```
    dotnet electronize build win
    dotnet electronize build osx
    dotnet electronize build linux
```

The end result should be an electron app under your __/bin/desktop__ folder.

