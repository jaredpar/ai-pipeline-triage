
set PIPELINE_ROOT=%~dp0
set PIPELINE_CONFIGDIR=%PIPELINE_ROOT%\artifacts\.copilot
set PIPELINE_PLUGINPATH=%PIPELINE_ROOT%\artifacts\plugin
del /S /Q %PIPELINE_PLUGINPATH%\*
mkdir %PIPELINE_PLUGINPATH%
robocopy %PIPELINE_ROOT%\plugin\mcp\ %PIPELINE_PLUGINPATH% /E /NFL /NDL /NJH /NJS /NC /NS /NP
call copilot plugin uninstall --config-dir %PIPELINE_CONFIGDIR% pipeline-triage
call copilot plugin install --config-dir %PIPELINE_CONFIGDIR% %PIPELINE_PLUGINPATH%
call copilot --config-dir %PIPELINE_CONFIGDIR% %*