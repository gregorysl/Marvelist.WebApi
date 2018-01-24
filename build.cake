#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");

Task("Default")
	.IsDependentOn("xUnit");

Task("Build")
  .Does(() =>
{
  MSBuild("Marvelist.sln");
});

Task("xUnit")
	.IsDependentOn("Build")
		.Does(() =>
{
    MSTest("./Marvelist.Tests/bin/Debug/Marvelist.Tests.dll");
});

RunTarget(target);