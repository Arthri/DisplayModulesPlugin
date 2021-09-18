# DisplayModulesPlugin
DisplayModulesPlugin is a plugin for TShock that displays the current AppDomain's loaded modules

# Installation
1. Get the plugin from [releases](https://github.com/Arthri/DisplayModulesPlugin/releases/latest) 
2. Drag and drop the `.dll` file into the ServerPlugins folder
3. Start the server, or restart it if it's already running

# Usage
Say `/dmods` in chat

# Commands

## `displaymodules`

### Aliases
- `dmods`
- `showmods`

### Permissions
- `displaymodules.displaymodules`

### Description
Shows the current AppDomain's loaded modules. It uses `AppDomain.CurrentDomain.GetAssemblies()` to get them

# Building

## Prequisites
- .NET 5 or higher
- .NET 4.7.2 targetting pack

## Steps
- Run `dotnet tool restore` to restore tools
- Run `dotnet paket restore` to restore packages
- Run `dotnet build` to build. Alternatively use Ctrl + F5 in Visual Studio

# License
[MIT-0](https://github.com/Arthri/DisplayModulesPlugin/blob/LICENSE)
