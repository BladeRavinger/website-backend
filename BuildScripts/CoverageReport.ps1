python .\Build.py --onlyBuild any;
nuget install .\UKSFWebsite.api.tests\packages.config -outputDirectory .\packages;
dotnet publish .\UKSFWebsite.api.tests -o .\build_tests --framework net451 --runtime any;
ls;
.\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe -target:"packages\xunit.extensibility.execution\2.2.0\lib\netstandard1.1\xunit.execution.dotnet.dll" -targetargs:"build_tests\UKSFWebsite.api.tests.dll" -excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" -register:user -output:"_CodeCoverageResult.xml";
.\packages\ReportGenerator\2.5.8\tools\ReportGenerator.exe "-reports:_CodeCoverageResult.xml" "-targetdir:_CodeCoverageReport"
