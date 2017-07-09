ECHO OFF
CLS

REM Adapted from: https://magenic.com/thinking/using-opencover-and-reportgenerator-to-get-unit-testing-code-coverage-metrics-in-net

REM Project names.
SET PROJECT_NAME=InputComponents
SET TEST_PROJECT_NAME=InputComponents_Test

REM Build configuration.
SET BUILD_CONFIGURATION=Debug

REM Package path (packages are stored with the solution)
SET SOLUTION_PATH=..\..\
SET PACKAGES_PATH=%SOLUTION_PATH%packages\

REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"

REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0%PROJECT_NAME%.trx" del "%~dp0%PROJECT_NAME%.trx%"

REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

REM Generate the report output based on the test results
if %errorlevel% equ 0 (
  call :RunReportGeneratorOutput
)

REM Launch the report
if %errorlevel% equ 0 (
  call :RunLaunchReport
)
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"%~dp0%PACKAGES_PATH%OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%~dp0%PACKAGES_PATH%NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" ^
-targetargs:"\"%~dp0bin\%BUILD_CONFIGURATION%\%TEST_PROJECT_NAME%.dll\"" ^
-targetdir:"%~dp0bin\%BUILD_CONFIGURATION%" ^
-filter:"+[%PROJECT_NAME%]* -[%TEST_PROJECT_NAME%]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\%PROJECT_NAME%.xml"
exit /b %errorlevel%

:RunReportGeneratorOutput
"%~dp0%PACKAGES_PATH%ReportGenerator.2.5.8\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\%PROJECT_NAME%.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%

:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"

REM Give use a chance to pause to view any errors before closing.
echo.
choice /T 5 /D N /M "Keep this window open?"
if %errorlevel% == 1 (
  echo.
  pause
)

exit /b %errorlevel%