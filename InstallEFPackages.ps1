$packages = @(
    "Microsoft.AspNetCore.Identity.EntityFrameworkCore",
    "Microsoft.EntityFrameworkCore",
    "Microsoft.EntityFrameworkCore.Relational",
    "Microsoft.EntityFrameworkCore.Abstractions",
    "Microsoft.EntityFrameworkCore.Design",
    "Microsoft.EntityFrameworkCore.SqlServer",
    "Microsoft.EntityFrameworkCore.Tools",
    "Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore");

$projects = Get-ChildItem -Directory;

foreach($project in $projects) {
    foreach($package in $packages) {
        dotnet add $project package $package
    }
}

Read-Host