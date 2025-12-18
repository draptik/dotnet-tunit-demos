# Showcase using the official TUnit templates

## One-Time-Setup: Install the official TUnit templates

```bash
dotnet new install TUnit.Templates
```

## Setup

```bash
# Create a solution
dotnet new sln --format slnx -n Demo1

# Create a C# TUnit project
dotnet new TUnit -n "Demo1CSharpTests"

# Create an F# TUnit project
dotnet new TUnit.FSharp -n "Demo1FSharpTests" --language F#

# Add projects to solution
dotnet sln add Demo1CSharpTests
dotnet sln add Demo1FSharpTests
```

Patch the templates to update the target framework from 8 to 10:

```bash
sed -i 's/net8/net10/g' ./Demo1CSharpTests/Demo1CSharpTests.csproj
sed -i 's/net8/net10/g' ./Demo1FSharpTests/Demo1FSharpTests.fsproj
```

Create a `global.json` with the following content:

```json
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestMajor",
    "allowPrerelease": true
  },
  "test": {
    "runner": "Microsoft.Testing.Platform"
  }
}
```

Run the tests:

```bash
dotnet restore
dotnet test
```

This outputs:

```bash
❯ dotnet test
/home/patrick/projects/dotnet-tunit-demos/demo1/Demo1FSharpTests/Demo1FSharpTests.fsproj : warning NU1504: Duplicate 'PackageReference' items found. Remove the duplicate items or use the Update functionality to ensure a consistent restore behavior. The duplicate 'PackageReference' items are: TUnit.Assertions.FSharp *, TUnit.Assertions.FSharp 1.5.60.
Running tests from Demo1FSharpTests/bin/Debug/net10.0/Demo1FSharpTests.dll (net10.0|x64)
Running tests from Demo1CSharpTests/bin/Debug/net10.0/Demo1CSharpTests.dll (net10.0|x64)
Demo1CSharpTests/bin/Debug/net10.0/Demo1CSharpTests.dll (net10.0|x64) passed (371ms)
Demo1FSharpTests/bin/Debug/net10.0/Demo1FSharpTests.dll (net10.0|x64) passed (410ms)

Test run summary: Passed!
  Demo1CSharpTests/bin/Debug/net10.0/Demo1CSharpTests.dll (net10.0|x64) passed (371ms)
  Demo1FSharpTests/bin/Debug/net10.0/Demo1FSharpTests.dll (net10.0|x64) passed (410ms)

  total: 104
  failed: 0
  succeeded: 104
  skipped: 0
  duration: 627ms
```
