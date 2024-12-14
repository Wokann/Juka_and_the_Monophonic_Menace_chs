
setlocal enabledelayedexpansion
 set INIT_PATH=%cd%
 cd /d %~dp0
 dotnet clean
 del /Q ".\Final(JuKa).exe"
 dotnet build Final(JuKa).sln
 copy ".\Final(JuKa)\bin\Debug\Final(JuKa).exe" ".\"
 cd %INIT_PATH%
endlocal
pause