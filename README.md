To learn more about the design details visit https://github.com/abhijeetd/Agile-done-criteria-evaluator/wiki/Agile-DONE-criteria-evaluation-tool-design

DONE criteria evaluation tool
=============================
Burn-downs charts are among the most common sprint tracking mechanisms used by Agile practitioners. 
Though their application and usage varies (some plot a burn-down chart using story points, whereas others use task count), 
plotting burn-down using effort remaining is the most effective and efficient way of using burn-down charts. 
Daily updating task status and remaining efforts are the key activities involved in any Scrum project. 
Without this the burn down chart will show incorrect status. At times teams struggle to keep everyone motivated to update
the status on daily basis. This results in incorrect project tracking and frustration.

This DONE criteria evaluation utility solves this exact problem. 

On daily basis it verifies if the Scrum team member has updated the task status and efforts. It has inbuilt set of rules (you can also add your custom rule using the pluggable architecture)
which are verified for every user story of the current sprint. 

The tool also support sending notifications to multiple listeners - e.g. Email listener such that an email is sent
to respective team member as reminder if any rule is not complied to. This ensures entire team is giving necessary attention to updating task status and efforts. 

The standard process can be configured as per your project's DONE criteria.

### Sample email notification sent to an individual team member
![Alt text](https://github.com/abhijeetd/Agile-done-criteria-evaluator/blob/master/DoneEvaluator/DoneEvaluator/Documentation/TimeMachineEmailNotification.png?raw=true "Sample email notification sent to an individual team member")

Features
--------
1. Ability to define and enforce custom DONE criteria
2. Connect to any work tracking system that exposes data via API - In this version TFS support has been implemented, but it can be extended for other systems like Rally, Jira, etc.)
3. Ability to send analysis report to multiple consumers like 
* Email to individual teammember
* Dump in MongoDB
* Store data in RDBMS (for later analysis to discover patterns, etc. )

Configurations
--------------
The application is highly configurable. The application configurations are defined in a file named: TimeLogManagerManifest.xml

The configuration file consists of following sections:
* Organization - Title
* Project - Title
* IterationPath - Iteration path against which data needs to be analyzed
* Milestones - Define project milestones like "Code completion date", "Code freeze date", etc. Note all this configured data is available to analyzers - this helps developers use this information for custom logic/analysis.
* TeamProfiles - list of all team members
* Plugins - custom plugins to for 
* * retreiving data source
* * Pushing analysis data to multiple listeners
* * Data formatter to present data in any format required (Defauly HTML formatter is already implemented)
* * Analyzers that gets workitem and it's associated tasks with misc. details that can then by analyzed to implement DONE criteria
