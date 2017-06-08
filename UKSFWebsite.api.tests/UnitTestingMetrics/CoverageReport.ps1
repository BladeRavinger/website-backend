python .\Build.py --onlyBuild any;
nuget install .\UKSFWebsite.api.tests\packages.config -outputDirectory .\packages;
dotnet publish .\UKSFWebsite.api.tests -o .\build_tests --framework net451 --runtime any;
ls;
.\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:"packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" -targetargs:"build_tests\UKSFWebsite.api.tests.dll" -filter:"+[UKSFWebsite.api]UKSFWebsite.api*" -excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" -register:user -output:"_CodeCoverageResult.xml";
.\packages\ReportGenerator.2.5.8\tools\ReportGenerator.exe "-reports:_CodeCoverageResult.xml" "-targetdir:_CodeCoverageReport"

.\packages\coveralls.net.0.7.0\tools\csmacnz.Coveralls.exe  --opencover -i .\CodeCoverageResult.xml --useRelativePaths  