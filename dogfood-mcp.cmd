@echo off
set PIPELINE_ROOT=%~dp0
set PIPELINE_CONFIGDIR=%PIPELINE_ROOT%\artifacts\.copilot
copy %PIPELINE_ROOT%\plugin\plugin-mcp.json %PIPELINE_ROOT%\artifacts\plugin.json
call copilot --configDir %PIPELINE_CONFIGDIR% uninstall pipeline-triage
call copilot --configDir %PIPELINE_CONFIGDIR% plugin install %PIPELINE_ROOT%\artifacts
call copilot --configDir %PIPELINE_CONFIGDIR% %*