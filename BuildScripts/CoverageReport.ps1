dotnet restore;
nuget restore;
dotnet restore --packages .\packages;
nuget restore -PackagesDirectory .\packages;
dotnet publish .\UKSFWebsite.api.xtests -o ..\build_tests --framework netcoreapp1.1 -c Testing;
ls;
.\packages\opencover\4.6.519\tools\OpenCover.Console.exe -target:"C:\Program Files\dotnet\dotnet.exe" -targetargs:"vstest UKSFWebsite.api.xtests.dll" -targetdir:"build_tests" -oldStyle -register:user -output:"_CodeCoverageResult.xml" -filter:"+[UKSFWebsite.api]*";
.\packages\ReportGenerator\2.5.8\tools\ReportGenerator.exe "-reports:_CodeCoverageResult.xml" "-targetdir:_CodeCoverageReport";
