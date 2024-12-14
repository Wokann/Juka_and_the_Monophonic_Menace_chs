@echo on
setlocal enabledelayedexpansion
:: 设置指令路径、工具路径、基础文件名
    set "WorkPath=%~dp0"
    cd /d %WorkPath%

    set "armips_main=.\Patch_For_Juka_and_the_Monophonic_Menace.asm"
    set "tool_armips=.\armips.exe"
    set Input_Rom=%1
    call set "Input_Rom_Name=%%~dpn1"

    set "Output_Rom=%Input_Rom_Name%_patched.gba"

    :: 检查原始rom是否存在
    if "%~1" == "" (
        @echo Input Rom is Not Exist!
	    goto :Exit
    )
    :: armips打补丁
    %tool_armips% %armips_main% ^
        -strequ Input_Rom  %Input_Rom% ^
        -strequ Output_Rom "%Output_Rom%" ^
        -erroronwarning ^
        || (
            @echo Error^^!
            goto :Exit
            )
    @echo Patched^^!
    goto :Exit


:Exit
    :: 3秒后自动关闭本窗口
    @echo off
    ping 127.0.0.1 -n 3 >nul

endlocal