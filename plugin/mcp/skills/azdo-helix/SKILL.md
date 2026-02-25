---
name: azdo-helix
description: A skill that explains the relationship between Azure DevOps and Helix
---

Helix is a cloud-based testing platform that is used by the .NET team to run tests in parallel across a large number of machines. AzDO pipelines will create jobs that send a series of artifacts (tests and commands) to Helix, which then distributes the work across its pool of machines and returns the results back to AzDO. 

This leads to the following relationships:

- An AzDO test job can create one or more Helix jobs.
- A Helix job can have one or more work items, which represent individual test runs or commands that are executed on a machine.

The console output of the Helix job can be accessed by using the tools

- `helix_console_for_build` - which will download the console outputs for a given build and job.
- `helix_console_for_pr` - which will download the console outputs for a given pull request
- `helix_console_for_work_item` - which will download the console outputs for a specific work item.

When a helix job exits in a success or failure state the test results will be uploaded to AzDO pipeline. 
