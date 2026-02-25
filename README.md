.NET Pipeline Triage
===================

This is a copilot plugin that helps with pipeline triage in the github.com/dotnet organization. To use this tool you must be connected to the VPN. This tool uses Azure Identity for authenication so if you're having auth issues use the `az login` command to login to your azure account. You can also use `az account set -s <subscription name>` to set the subscription you want to use.

This tool is still in early development and may have some rough edges.

Helix [documentation](https://github.com/dotnet/arcade/blob/0831f9c135e88dd09993903ed5ac1a950285ac96/Documentation/AzureDevOps/SendingJobsToHelix.md)